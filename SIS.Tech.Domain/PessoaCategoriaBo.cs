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
    public class PessoaCategoriaBo : IPessoaCategoriaBo
    {
        private readonly IPessoaCategoriaRepository _pessoaCategoriaRepository;

        public PessoaCategoriaBo(IPessoaCategoriaRepository pessoaCategoriaRepository)
        {
            _pessoaCategoriaRepository = pessoaCategoriaRepository;
        }

        public void AlterarPessoaCategoria(PessoaCategoria pessoaCategoria)
        {
            _pessoaCategoriaRepository.AlterarPessoaCategoria(pessoaCategoria);
        }

        public void ExcluirPessoaCategoria(int codPessoaCategoria, string quem)
        {
            _pessoaCategoriaRepository.ExcluirPessoaCategoria(codPessoaCategoria, quem);
        }

        public int InserirPessoaCategoria(PessoaCategoria pessoaCategoria)
        {
            return _pessoaCategoriaRepository.InserirPessoaCategoria(pessoaCategoria);
        }

        public List<PessoaCategoria> ListarPessoaCategoria()
        {
            return _pessoaCategoriaRepository.ListarPessoaCategoria();
        }

        public List<PessoaCategoria> ListarPessoaCategoriaFiltro(string codPessoaCategoria, string descricao)
        {
            return _pessoaCategoriaRepository.ListarPessoaCategoriaFiltro(codPessoaCategoria, descricao);
        }

        public PessoaCategoria ObterPessoaCategoria(int codPessoaCategoria)
        {
            return _pessoaCategoriaRepository.ObterPessoaCategoria(codPessoaCategoria);
        }
    }
}
