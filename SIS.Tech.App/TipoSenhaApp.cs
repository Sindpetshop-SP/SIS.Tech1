using SIS.Tech.IDomain;
using SIS.Tech.Domain.Model;
using SIS.Tech.IApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.App
{
    public class TipoSenhaApp : ITipoSenhaApp
    {
        private readonly ITipoSenhaBo _tipoSenhaBo;

        public TipoSenhaApp(ITipoSenhaBo tipoSenhaBo)
        {
            _tipoSenhaBo = tipoSenhaBo;
        }

        public List<TipoSenha> ListarTipoSenha()
        {
            return _tipoSenhaBo.ListarTipoSenha();
        }

        public List<TipoSenha> ListarTipoSenhaFiltro(string codTipoSenha, string descricao)
        {
            return _tipoSenhaBo.ListarTipoSenhaFiltro(codTipoSenha, descricao);
        }

        public TipoSenha ObterTipoSenha(int codTipoSenha)
        {
            return _tipoSenhaBo.ObterTipoSenha(codTipoSenha);
        }

        public int InserirTipoSenha(TipoSenha tipoSenha)
        {
            return _tipoSenhaBo.InserirTipoSenha(tipoSenha);
        }


        public int AlterarTipoSenha(TipoSenha tipoSenha)
        {
            return _tipoSenhaBo.AlterarTipoSenha(tipoSenha);
        }

        public int ExcluirTipoSenha(int codTipoSenha, string quem)
        {
            return _tipoSenhaBo.ExcluirTipoSenha(codTipoSenha, quem);
        }

      
    }
}
