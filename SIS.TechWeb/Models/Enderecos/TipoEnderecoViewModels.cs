using SIS.Tech.Domain.Model;

namespace SIS.Tech.Models.Enderecos
{
  public class TipoEnderecoViewModels
  {
    public TipoEndereco TipoEndereco { get; set; }

    public IEnumerable<TipoEndereco> lstTipoEndereco { get; set; }
  }
}
