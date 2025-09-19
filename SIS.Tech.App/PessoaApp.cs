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
    public class PessoaApp : IPessoaApp
    {
        private readonly IPessoaBo _pessoaBo;

        public PessoaApp(IPessoaBo pessoaBo)
        {
            _pessoaBo = pessoaBo;
        }

        public void AlterarPessoa(Pessoa codPessoa)
        {
            _pessoaBo.AlterarPessoa(codPessoa);
        }

        public int ExcluirPessoa(int codPessoa, string quem)
        {
            return _pessoaBo.ExcluirPessoa(codPessoa, quem);
        }

        public int IncluirPessoa(Pessoa pessoa)
        {
            return _pessoaBo.IncluirPessoa(pessoa);
        }

        public List<Pessoa> ListarPessoa()
        {
            return _pessoaBo.ListarPessoa();
        }
        
        public List<PessoaCategoria> ListarPessoaCategoria()
        {
            return _pessoaBo.ListarPessoaCategoria();
        }

        
        public List<Pessoa> ListarPessoaFiltro(string codPessoa, string nome)
        {
            return _pessoaBo.ListarPessoaFiltro(codPessoa, nome);
        }

        public Pessoa ObterPessoa(int codPessoa)
        {
            return _pessoaBo.ObterPessoa(codPessoa);
        }

        


    }
}
