using SIS.Tech.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.IApp
{
    public interface ITipoSenhaApp
    {
        List<TipoSenha> ListarTipoSenha();

        List<TipoSenha> ListarTipoSenhaFiltro(string codTipoSenha, string descricao);

        TipoSenha ObterTipoSenha(int codTipoSenha);

        int InserirTipoSenha(TipoSenha tipoSenha);

        int AlterarTipoSenha(TipoSenha tipoSenha);

        int ExcluirTipoSenha(int codTipoSenha, string quem);
    }
}
