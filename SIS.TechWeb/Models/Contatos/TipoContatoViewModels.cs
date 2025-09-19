using SIS.Tech.Domain.Model;

namespace SIS.Tech.Models.Contatos
{
  public class TipoContatoViewModels
  {
    public TipoContato TipoContato { get; set; }

    public IEnumerable<TipoContato> lstTipoContatos { get; set; }
  }
}
