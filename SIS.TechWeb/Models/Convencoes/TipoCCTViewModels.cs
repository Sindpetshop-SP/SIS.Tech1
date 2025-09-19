using SIS.Tech.Domain.Model;

namespace SIS.Tech.Models.Convencoes
{
  public class TipoCCTViewModels
  {
    public int CodTipoCCT { get; set; }

    public string Descricao { get; set; }

    public List<TipoCCTViewModels> lstTipoCCT { get; set; }

  }
}
