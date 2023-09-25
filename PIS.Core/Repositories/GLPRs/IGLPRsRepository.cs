using PIS.Core.DTOs.GLPR;

namespace PIS.Core.Repositories.GLPRs;

public interface IGLPRsRepository
{
    Task<GLPRDto> CreateGLPRAsync(GLPRCreationDto dto);
    Task<List<GLPRDto>> GetGLPRsAsync(int cdTp);
    Task<GLPRDto?> GetGLPRAsync(string CdPr);
}
