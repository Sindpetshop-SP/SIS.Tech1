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
    public class PessoaCategoriaApp : IPessoaCategoriaApp
    {
        private readonly IPessoaCategoriaBo _pessoaCategoriaBo;

        public PessoaCategoriaApp(IPessoaCategoriaBo pessoaCategoriaBo)
        {
            _pessoaCategoriaBo = pessoaCategoriaBo;
        }

        public void AlterarPessoaCategoria(PessoaCategoria pessoaCategoria)
        {
            _pessoaCategoriaBo.AlterarPessoaCategoria(pessoaCategoria);
        }

        public void ExcluirPessoaCategoria(int codPessoaCategoria, string quem)
        {
            _pessoaCategoriaBo.ExcluirPessoaCategoria(codPessoaCategoria, quem);
        }

        public int InserirPessoaCategoria(PessoaCategoria pessoaCategoria)
        {
            return _pessoaCategoriaBo.InserirPessoaCategoria(pessoaCategoria);
        }

        public List<PessoaCategoria> ListarPessoaCategoria()
        {
            return _pessoaCategoriaBo.ListarPessoaCategoria();
        }

        public List<PessoaCategoria> ListarPessoaCategoriaFiltro(string codPessoaCategoria, string descricao)
        {
            return _pessoaCategoriaBo.ListarPessoaCategoriaFiltro(codPessoaCategoria, descricao);
        }

        public PessoaCategoria ObterPessoaCategoria(int codPessoaCategoria)
        {
            return _pessoaCategoriaBo.ObterPessoaCategoria(codPessoaCategoria);
        }
    }
}
