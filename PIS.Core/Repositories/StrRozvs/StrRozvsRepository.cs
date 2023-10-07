using ECommerce.Api.Core.Database;
using PIS.Core.Database.Entities;
using PIS.Core.DTOs.StrRozv;
using PIS.Core.Repositories.GLPRs;

namespace PIS.Core.Repositories.StrRozvs;

public class StrRozvsRepository : IStrRozvsRepository
{
    private readonly AppDbContext _dbContext;

    public StrRozvsRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task<StrRozvDto> CreateStrRozvAsync(StrRozvCreationDto dto)
    {
        var strRozv = new StrRozv
        {
            CdKp = dto.CdKp,
            CdSb = dto.CdSb,
            CdVyr = dto.CdVyr,
            QtyKp = dto.QtyKp,
            RivNb = dto.RivNb
        };

        _dbContext.StrRozvs.Add(strRozv);
        await _dbContext.SaveChangesAsync();
        return new StrRozvDto(strRozv.CdVyr, strRozv.CdSb, strRozv.CdKp, strRozv.QtyKp, strRozv.RivNb);
    }
}
