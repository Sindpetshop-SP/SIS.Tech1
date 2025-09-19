using SIS.Tech.IDomain;
using SIS.Tech.Domain.Model;
using SIS.Tech.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Domain
{
    public class TipoSenhaBo : ITipoSenhaBo
    {
        private readonly ITipoSenhaRepository _tipoSenhaRepository;

        public TipoSenhaBo(ITipoSenhaRepository tipoSenhaRepository)
        {
            _tipoSenhaRepository = tipoSenhaRepository;
        }

        public List<TipoSenha> ListarTipoSenha()
        {
            return _tipoSenhaRepository.ListarTipoSenha();
        }

        public List<TipoSenha> ListarTipoSenhaFiltro(string codTipoSenha, string descricao)
        {
            return _tipoSenhaRepository.ListarTipoSenhaFiltro(codTipoSenha, descricao);
        }

        public TipoSenha ObterTipoSenha(int codTipoSenha)
        {
            return _tipoSenhaRepository.ObterTipoSenha(codTipoSenha);
        }
        public int InserirTipoSenha(TipoSenha tipoSenha)
        {
            return _tipoSenhaRepository.InserirTipoSenha(tipoSenha);
        }

        public int AlterarTipoSenha(TipoSenha tipoSenha)
        {
            return _tipoSenhaRepository.AlterarTipoSenha(tipoSenha);
        }

        public int ExcluirTipoSenha(int codTipoSenha, string quem)
        {
            return _tipoSenhaRepository.ExcluirTipoSenha(codTipoSenha, quem);
        }

    }

}
