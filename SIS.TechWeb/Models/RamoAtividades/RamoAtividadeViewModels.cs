using SIS.Tech.Domain.Model;

namespace SIS.Tech.Models.RamoAtividades
{
  public class RamoAtividadeViewModels
  {
    public RamoAtividade RamoAtividade { get; set; }

    public IEnumerable<RamoAtividade> lstRamoAtividade { get; set; }
  }
}
