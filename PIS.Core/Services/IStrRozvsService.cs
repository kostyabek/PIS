using PIS.Core.DTOs.StrRozv;

namespace PIS.Core.Services;

public interface IStrRozvsService
{
    Task<List<StrRozvDto>> GenerateStrRozvAsync();
}
