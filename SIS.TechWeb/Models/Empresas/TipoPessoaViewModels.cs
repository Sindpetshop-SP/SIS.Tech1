using SIS.Tech.Domain.Model;

namespace SIS.Tech.Models.Empresas
{
  public class TipoPessoaViewModels
  {
    public TipoPessoa TipoPessoa { get; set; }

    public IEnumerable<TipoPessoa> lstTipoPessoa { get; set; }
  }
}
