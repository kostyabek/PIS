using Microsoft.AspNetCore.Mvc;
using PIS.Api.Models.Request.GLPR;
using PIS.Core.DTOs.GLPR;
using PIS.Core.Repositories.GLPRs;

namespace PIS.Api.Controllers;

[Route("api/gl-prs")]
[ApiController]
public class GLPRsController : ControllerBase
{
    private readonly IGLPRsRepository _GLPRsRepository;

    public GLPRsController(IGLPRsRepository GLPRsRepository)
    {
        _GLPRsRepository = GLPRsRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateGLPRAsync([FromBody] CreateGLPRRequest request)
    {
        var dto = new GLPRCreationDto(request.CdPr, request.NmPr, request.CdTp);
        GLPRDto glpr = await _GLPRsRepository.CreateGLPRAsync(dto);
        return Ok(glpr);
    }
}
