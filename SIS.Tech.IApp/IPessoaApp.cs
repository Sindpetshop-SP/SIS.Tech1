using SIS.Tech.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.IApp
{

    public interface IPessoaApp
    {
        List<Pessoa> ListarPessoa();

        List<Pessoa> ListarPessoaFiltro(string codPessoa, string nome);

        Pessoa ObterPessoa(int codPessoa);

        int IncluirPessoa(Pessoa pessoa);

        void AlterarPessoa(Pessoa codPessoa);

        int ExcluirPessoa(int codPessoa, string quem);
    }

}
