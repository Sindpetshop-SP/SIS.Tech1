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
    public class ContatoApp: IContatoApp
    {
        private readonly IContatoBo _contatoBo;

        public ContatoApp(IContatoBo contatoBo)
        {
            _contatoBo = contatoBo;
        }

        public void AlterarContato(Contato contato)
        {
            AlterarContato(contato);
        }

        public void ExcluirContatoEmpresa(int codEmpresa, int codContato, string quem)
        {
            _contatoBo.ExcluirContatoEmpresa(codEmpresa, codContato, quem);
        }

        public void ExcluirContatoPessoa(int codPessoa, int codContato, string quem)
        {
            _contatoBo.ExcluirContatoPessoa(codPessoa, codContato, quem);
        }

        public int InserirContatoEmpresa(Empresa Empresa)
        {
            return _contatoBo.InserirContatoEmpresa(Empresa);
        }

        public int InserirContatoPessoa(Pessoa pessoa)
        {
            return _contatoBo.InserirContatoPessoa(pessoa);
        }

        public List<Contato> ListarContatosEmpresa(int codEmpresa)
        {
            return _contatoBo.ListarContatosEmpresa(codEmpresa);
        }

        public List<Contato> ListarContatosPessoa(int codPessoa)
        {
            return _contatoBo.ListarContatosPessoa(codPessoa);
        }

        public List<TipoContato> ListarTipoContato()
        {
            return _contatoBo.ListarTipoContato();
        }

        public Contato ObterContato(int codContato)
        {
            return _contatoBo.ObterContato(codContato);
        }
    }
}
