using PIS.Core.DTOs.StrRozv;

namespace PIS.Core.Repositories.GLPRs;

public interface IStrRozvsRepository
{
    Task<StrRozvDto> CreateStrRozvAsync(StrRozvCreationDto dto);
}
