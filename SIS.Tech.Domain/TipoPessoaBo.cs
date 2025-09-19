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
    public class TipoPessoaBo : ITipoPessoaBo
    {
        private readonly ITipoPessoaRepository _tipoPessoaRepository;

        public TipoPessoaBo(ITipoPessoaRepository tipoPessoaRepository)
        {
            _tipoPessoaRepository = tipoPessoaRepository;
        }

        public int AlterarTipoPessoa(TipoPessoa tipoPessoa)
        {
            return _tipoPessoaRepository.AlterarTipoPessoa(tipoPessoa);
        }

        public int ExcluirTipoPessoa(int codTipoPessoa, string quem)
        {
            return _tipoPessoaRepository.ExcluirTipoPessoa(codTipoPessoa, quem);
        }

        public int InserirTipoPessoa(TipoPessoa tipoPessoa)
        {
            return _tipoPessoaRepository.InserirTipoPessoa(tipoPessoa);
        }

        public List<TipoPessoa> ListarTipoPessoa()
        {
            return _tipoPessoaRepository.ListarTipoPessoa();
        }
        public List<TipoPessoa> ListarTipoPessoaFiltro(string codTipoPessoa, string descricao)
        {
            return _tipoPessoaRepository.ListarTipoPessoaFiltro(codTipoPessoa, descricao);
        }
        public TipoPessoa ObterTipoPessoa(int codTipoPessoa)
        {
            return _tipoPessoaRepository.ObterTipoPessoa(codTipoPessoa);
        }
    }

}
