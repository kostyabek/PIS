using ECommerce.Api.Core.Database;
using ECommerce.Api.Core.Database.Entities;
using Microsoft.EntityFrameworkCore;
using PIS.Core.DTOs.GLPR;

namespace PIS.Core.Repositories.GLPRs;

public class GLPRsRepository : IGLPRsRepository
{
    private readonly AppDbContext _dbContext;

    public GLPRsRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<GLPRDto> CreateGLPRAsync(GLPRCreationDto dto)
    {
        var glpr = new GLPR { CdPr = dto.CdPr, NmPr = dto.NmPr, CdTp = dto.CdTp };
        _dbContext.GLPRs.Add(glpr);
        await _dbContext.SaveChangesAsync();
        return new GLPRDto(glpr.CdPr, glpr.NmPr, glpr.CdTp);
    }

    public Task<GLPRDto?> GetGLPRAsync(string CdPr)
    {
        return _dbContext.GLPRs
            .Where(e => e.CdPr == CdPr)
            .Select(e => new GLPRDto(e.CdPr, e.NmPr, e.CdTp))
            .SingleOrDefaultAsync();
    }
}
