using ECommerce.Api.Core.Database.Entities;

namespace PIS.Core.Database.Entities;

public class StrRozv
{
    public string CdVyr { get; set; }
    public GLPR Vyr { get; set; }
    public string CdSb { get; set; }
    public GLPR Sb { get; set; }
    public string CdKp { get; set; }
    public GLPR Kp { get; set; }
    public int QtyKp { get; set; }
    public int RivNb { get; set; }
}
