using SIS.Tech.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.IDomain
{
    public interface IPessoaBo
    {
        List<Pessoa> ListarPessoa();

        List<Pessoa> ListarPessoaFiltro(string codPessoa, string razaoSocial);

        Pessoa ObterPessoa(int codPessoa);

        int IncluirPessoa(Pessoa pessoa);

        void AlterarPessoa(Pessoa codPessoa);

        int ExcluirPessoa(int codPessoa, string quem);

        List<PessoaCategoria> ListarPessoaCategoria();
    }
}
