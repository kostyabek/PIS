using ECommerce.Api.Core.Database;
using ECommerce.Api.Core.Database.Entities;
using PIS.Core.DTOs.TypePr;

namespace PIS.Core.Repositories.GLPRs;

public class TypePrsRepository : ITypePrsRepository
{
    private readonly AppDbContext _dbContext;

    public TypePrsRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TypePrDto> CreateTypePrAsync(TypePrCreationDto dto)
    {
        var typePr = new TypePr { NmTp = dto.NmTp };
        _dbContext.TypePrs.Add(typePr);
        await _dbContext.SaveChangesAsync();
        return new TypePrDto(typePr.CdTp, typePr.NmTp);
    }
}
