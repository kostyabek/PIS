using PIS.Core.DTOs.GLPR;

namespace PIS.Core.Repositories.GLPRs;

public interface IGLPRsRepository
{
    Task<GLPRDto> CreateGLPRAsync(GLPRCreationDto dto);

    Task<GLPRDto?> GetGLPRAsync(string CdPr);
}
