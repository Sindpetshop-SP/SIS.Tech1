using SIS.Tech.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.IRepository
{
    public interface ISenhaBancoRepository 
    {
        List<SenhaBanco> ListarSenhaBanco(string usuario);

        List<SenhaBanco> ListarSenhaBancoFiltro(string codInstituicao, string usuario);

        SenhaBanco ObterSenhaBanco(int codSenhaBanco, string usuario);

        int InserirSenhaBanco(SenhaBanco SenhaBanco);

        int AlterarSenhaBanco(SenhaBanco SenhaBanco);

        int ExcluirSenhaBanco(int codSenhaBanco, string quem);
    }
}
