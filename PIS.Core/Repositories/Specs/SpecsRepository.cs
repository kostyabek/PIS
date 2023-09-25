using ECommerce.Api.Core.Database;
using ECommerce.Api.Core.Database.Entities;
using Microsoft.EntityFrameworkCore;
using PIS.Core.DTOs;
using PIS.Core.DTOs.GLPR;
using PIS.Core.DTOs.Spec;
using PIS.Core.Helpers;
using PIS.Core.Repositories.GLPRs;

namespace PIS.Core.Repositories.Specs;

public class SpecsRepository : ISpecsRepository
{
    private readonly AppDbContext _dbContext;
    private readonly IGLPRsRepository _GLPRsRepository;

    public SpecsRepository(
        AppDbContext dbContext,
        IGLPRsRepository gLPRsRepository)
    {
        _dbContext = dbContext;
        _GLPRsRepository = gLPRsRepository;
    }

    public async Task<SpecDto> CreateSpecAsync(SpecCreationDto dto)
    {
        GLPRDto? complexProduct = await _GLPRsRepository.GetGLPRAsync(dto.CdSb);
        if (complexProduct is null)
        {
            throw new ApplicationException("Detail not found.");
        }

        GLPRDto? simpleProduct = await _GLPRsRepository.GetGLPRAsync(dto.CdKp);
        if (simpleProduct is null)
        {
            throw new ApplicationException("Component not found.");
        }

        if (!GLPRTypeChecker.IsComplexProduct(complexProduct.CdTp))
        {
            throw new ApplicationException("Cannot use simple detail as complex!");
        }

        if (!GLPRTypeChecker.IsSimpleProduct(complexProduct.CdTp))
        {
            throw new ApplicationException("Cannot use complex detail as simple!");
        }

        var spec = new Spec { CdSb = dto.CdSb, CdKp = dto.CdKp, QtyKp = dto.QtyKp };
        _dbContext.Specs.Add(spec);
        await _dbContext.SaveChangesAsync();
        return new SpecDto(spec.CdSb, spec.CdKp, spec.QtyKp);
    }

    public Task<List<ComponentDto>> GetComponentsForDetailAsync(string detailId)
    {
        return _dbContext.Specs
            .Where(e => e.CdSb == detailId)
            .Select(e => new ComponentDto(e.CdKp, e.Kp.NmPr, e.QtyKp))
            .ToListAsync();
    }

    public Task<List<DetailDto>> GetDetailsByComponentAsync(string componentId)
    {
        return _dbContext.Specs
            .Where(e => e.CdKp == componentId)
            .Select(e => new DetailDto(e.CdSb, e.Sb.NmPr, e.QtyKp))
            .ToListAsync();
    }

    public Task<List<SpecDto>> GetSpecsAsync(string cdSb)
    {
        return _dbContext.Specs
            .AsNoTracking()
            .Where(e => e.CdSb == cdSb)
            .Select(e => new SpecDto(e.CdSb, e.CdKp, e.QtyKp))
            .ToListAsync();
    }
}
