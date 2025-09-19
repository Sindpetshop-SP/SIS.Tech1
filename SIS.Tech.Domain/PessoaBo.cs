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
    public class PessoaBo : IPessoaBo
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaBo(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public void AlterarPessoa(Pessoa codPessoa)
        {
            _pessoaRepository.AlterarPessoa(codPessoa);
        }

        public int ExcluirPessoa(int codPessoa, string quem)
        {
            return _pessoaRepository.ExcluirPessoa(codPessoa, quem);
        }

        public int IncluirPessoa(Pessoa pessoa)
        {
            return _pessoaRepository.IncluirPessoa(pessoa);
        }

        public List<Pessoa> ListarPessoa()
        {
            return _pessoaRepository.ListarPessoa();
        }

        public List<PessoaCategoria> ListarPessoaCategoria()
        {
            return _pessoaRepository.ListarPessoaCategoria();
        }

        public List<Pessoa> ListarPessoaFiltro(string codPessoa, string nome)
        {
            return _pessoaRepository.ListarPessoaFiltro(codPessoa, nome);
        }

        public Pessoa ObterPessoa(int codPessoa)
        {
            return _pessoaRepository.ObterPessoa(codPessoa);
        }
      
    }
}
