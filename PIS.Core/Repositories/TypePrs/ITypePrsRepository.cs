using PIS.Core.DTOs.TypePr;

namespace PIS.Core.Repositories.GLPRs;

public interface ITypePrsRepository
{
    Task<TypePrDto> CreateTypePrAsync(TypePrCreationDto dto);
}
