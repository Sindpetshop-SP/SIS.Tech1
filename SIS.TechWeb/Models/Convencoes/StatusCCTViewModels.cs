using SIS.Tech.Domain.Model;

namespace SIS.Tech.Models.Convencoes
{
  public class StatusCCTViewModels
  {
    public int CodStatusCCT { get; set; }

    public string Descricao { get; set; }

    public List<StatusCCTViewModels> lstStatusCCT { get; set; }

  }
}
