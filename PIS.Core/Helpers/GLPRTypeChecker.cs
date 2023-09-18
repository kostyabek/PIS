using PIS.Core.Enums;

namespace PIS.Core.Helpers;

public static class GLPRTypeChecker
{
    private static readonly IEnumerable<int> ComplexProducts = new List<int> { (int)TypePrIds.Product, (int)TypePrIds.Node };
    private static readonly IEnumerable<int> SimpleProducts = new List<int> { (int)TypePrIds.OwnedPart, (int)TypePrIds.BoughtItem };

    public static bool IsComplexProduct(int CdTp)
        => ComplexProducts.Any(e => e == CdTp);

    public static bool IsSimpleProduct(int CdTp)
        => SimpleProducts.Any(e => e == CdTp);
}
