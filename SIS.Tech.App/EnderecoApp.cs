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
    public class EnderecoApp : IEnderecoApp
    {
        private readonly IEnderecoBo _enderecoBo;

        public EnderecoApp(IEnderecoBo enderecoBo)
        {
            _enderecoBo = enderecoBo;
        }

        public void AlterarEndereco(Endereco endereco)
        {
            _enderecoBo.AlterarEndereco(endereco);
        }

        public void ExcluirEnderecoEmpresa(int codEmpresa, int codEndereco, string quem)
        {
            _enderecoBo.ExcluirEnderecoEmpresa(codEmpresa, codEndereco, quem);
        }

        public void ExcluirEnderecoPessoa(int codPessoa, int codEndereco, string quem)
        {
            _enderecoBo.ExcluirEnderecoPessoa(codPessoa, codEndereco, quem);
        }

        public int InserirEnderecoEmpresa(Empresa empresa)
        {
            return _enderecoBo.InserirEnderecoEmpresa(empresa);
        }

        public int InserirEnderecoPessoa(Pessoa pessoa)
        {
            return _enderecoBo.InserirEnderecoPessoa(pessoa);
        }

        public List<Endereco> ListarEnderecosEmpresa(int codEmpresa)
        {
            return _enderecoBo.ListarEnderecosEmpresa(codEmpresa);
        }

        public List<Endereco> ListarEnderecosPessoa(int codPessoa)
        {
            return _enderecoBo.ListarEnderecosPessoa(codPessoa);
        }

        public List<TipoEndereco> ListarTipoEndereco()
        {
            return _enderecoBo.ListarTipoEndereco();
        }

        public Endereco ObterEndereco(int codEndereco)
        {
            return _enderecoBo.ObterEndereco(codEndereco);
        }
    }
}
