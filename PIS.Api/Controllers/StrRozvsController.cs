using Microsoft.AspNetCore.Mvc;
using PIS.Core.DTOs.StrRozv;
using PIS.Core.Services;

namespace PIS.Api.Controllers;

[Route("api/str-rozvs")]
[ApiController]
public class StrRozvsController : ControllerBase
{
    private readonly IStrRozvsService _strRozvsService;

    public StrRozvsController(IStrRozvsService strRozvsService)
    {
        _strRozvsService = strRozvsService;
    }

    [HttpPost]
    public async Task<IActionResult> GenerateStrRozvsAsync()
    {
        List<StrRozvDto> strRozvs = await _strRozvsService.GenerateStrRozvAsync();
        return Ok(strRozvs);
    }
}
