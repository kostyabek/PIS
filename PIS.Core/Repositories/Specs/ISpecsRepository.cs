using PIS.Core.DTOs;
using PIS.Core.DTOs.Spec;

namespace PIS.Core.Repositories.Specs;

public interface ISpecsRepository
{
    Task<SpecDto> CreateSpecAsync(SpecCreationDto dto);

    Task<List<ComponentDto>> GetComponentsForDetailAsync(string detailId);

    Task<List<DetailDto>> GetDetailsByComponentAsync(string componentId);
}
