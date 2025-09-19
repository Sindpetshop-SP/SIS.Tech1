using SIS.Tech.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.IApp
{
    public interface ITipoPessoaApp
    {
        List<TipoPessoa> ListarTipoPessoa();

        List<TipoPessoa> ListarTipoPessoaFiltro(string codTipoPessoa, string descricao);

        TipoPessoa ObterTipoPessoa(int codTipoPessoa);

        int InserirTipoPessoa(TipoPessoa tipoPessoa);

        int AlterarTipoPessoa(TipoPessoa tipoPessoa);

        int ExcluirTipoPessoa(int codTipoPessoa, string quem);
    }
}
