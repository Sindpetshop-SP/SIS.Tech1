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
    public class TipoPessoaApp : ITipoPessoaApp
    {
        private readonly ITipoPessoaBo _tipoPessoaBo;

        public TipoPessoaApp(ITipoPessoaBo tipoPessoaBo)
        {
            _tipoPessoaBo = tipoPessoaBo;
        }

        public int AlterarTipoPessoa(TipoPessoa tipoPessoa)
        {
            return _tipoPessoaBo.AlterarTipoPessoa(tipoPessoa);
        }

        public int ExcluirTipoPessoa(int codTipoPessoa, string quem)
        {
            return _tipoPessoaBo.ExcluirTipoPessoa(codTipoPessoa, quem);
        }

        public int InserirTipoPessoa(TipoPessoa tipoPessoa)
        {
            return _tipoPessoaBo.InserirTipoPessoa(tipoPessoa);
        }

        public List<TipoPessoa> ListarTipoPessoa()
        {
            return _tipoPessoaBo.ListarTipoPessoa();
        }

        public List<TipoPessoa> ListarTipoPessoaFiltro(string codTipoPessoa, string descricao)
        {
            return _tipoPessoaBo.ListarTipoPessoaFiltro(codTipoPessoa, descricao);
        }

        public TipoPessoa ObterTipoPessoa(int codTipoPessoa)
        {
            return _tipoPessoaBo.ObterTipoPessoa(codTipoPessoa);
        }
    }
}
