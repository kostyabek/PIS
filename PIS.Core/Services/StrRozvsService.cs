using PIS.Core.DTOs;
using PIS.Core.DTOs.GLPR;
using PIS.Core.DTOs.Spec;
using PIS.Core.DTOs.StrRozv;
using PIS.Core.Repositories.GLPRs;
using PIS.Core.Repositories.Specs;

namespace PIS.Core.Services;

public class StrRozvsService : IStrRozvsService
{
    private readonly IGLPRsRepository _glprsRepository;
    private readonly ISpecsRepository _specsRepository;

    public StrRozvsService(
        IGLPRsRepository glprsRepository,
        ISpecsRepository specsRepository)
    {
        _glprsRepository = glprsRepository;
        _specsRepository = specsRepository;
    }

    public async Task<List<StrRozvDto>> GenerateStrRozvAsync()
    {
        int rootCdTp = 1;
        List<GLPRDto> rootParts = await _glprsRepository.GetGLPRsAsync(rootCdTp);
        var specs = new List<SpecDto>();
        foreach (GLPRDto rootPart in rootParts)
        {
            specs = specs.Concat(await _specsRepository.GetSpecsAsync(rootPart.CdPr)).ToList();
        }

        var strRozvs = new List<StrRozvDto>();
        foreach (SpecDto spec in specs)
        {
            strRozvs.Add(new StrRozvDto(
                spec.CdSb,
                spec.CdSb,
                spec.CdKp,
                spec.QtyKp,
                1));
        }

        foreach (StrRozvDto strRozv in strRozvs)
        {
            IEnumerable<StrRozvDto> generated = await StepIntoAsync(strRozv.CdVyr, strRozv.CdKp, 2, new List<StrRozvDto>());
            strRozvs = strRozvs.Concat(generated).ToList();
        }

        return strRozvs.OrderBy(e => e.RivNb).OrderBy(e => e.CdVyr).ToList();
    }
    
    public async Task<IEnumerable<StrRozvDto>> StepIntoAsync(string cdVyr, string cdKp, int rivNb, IEnumerable<StrRozvDto> initial)
    {
        List<ComponentDto> detailComponents = await _specsRepository.GetComponentsForDetailAsync(cdKp);
        if (!detailComponents.Any())
        {
            return initial;
        }

        List<StrRozvDto> newStrRozvs = detailComponents.Select(e => ToStrRozv(cdVyr, cdKp, rivNb, e)).ToList();
        List<StrRozvDto> result = initial.Concat(newStrRozvs).ToList();

        foreach (StrRozvDto newStrRozv in newStrRozvs)
        {
            List<StrRozvDto> resultsFromStepBelow = (await StepIntoAsync(cdVyr, newStrRozv.CdKp, rivNb + 1, result)).ToList();

            List<StrRozvDto> newResultsFromStepBelow = resultsFromStepBelow
                .Where(e => !result.Any(r => r.CdVyr == e.CdVyr && r.CdSb == e.CdSb && r.CdKp == e.CdKp))
                .ToList();

            result.AddRange(newResultsFromStepBelow);
        }

        return result;
    }

    private StrRozvDto ToStrRozv(string cdVyr, string cdSb, int rivNb, ComponentDto component)
        => new(cdVyr, cdSb, component.CdKp, component.QtyKp, rivNb);
}
