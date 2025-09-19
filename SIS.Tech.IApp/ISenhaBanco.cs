using SIS.Tech.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.IApp
{
    public interface ISenhaBancoApp
    {
        List<SenhaBanco> ListarSenhaBanco(string usuario);

        List<SenhaBanco> ListarSenhaBancoFiltro(string codInstituicao, string usuario);

        SenhaBanco ObterSenhaBanco(int codSenhaBanco, string usuario);

        int InserirSenhaBanco(SenhaBanco senhaBanco);

        int AlterarSenhaBanco(SenhaBanco senhaBanco);

        int ExcluirSenhaBanco(int codSenhaBanco, string quem);
    }
}
