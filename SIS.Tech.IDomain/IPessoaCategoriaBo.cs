using SIS.Tech.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.IDomain
{
    public interface IPessoaCategoriaBo
    {
        List<PessoaCategoria> ListarPessoaCategoria();

        List<PessoaCategoria> ListarPessoaCategoriaFiltro(string codPessoaCategoria, string descricao);

        PessoaCategoria ObterPessoaCategoria(int codPessoaCategoria);

        int InserirPessoaCategoria(PessoaCategoria pessoaCategoria);

        void AlterarPessoaCategoria(PessoaCategoria pessoaCategoria);

        void ExcluirPessoaCategoria(int codPessoaCategoria, string quem);
    }
}
