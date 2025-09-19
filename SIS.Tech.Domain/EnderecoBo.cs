using System.Collections.Generic;
using SIS.Tech.IDomain;
using SIS.Tech.Domain.Model;
using SIS.Tech.IRepository;

namespace SIS.Tech.Domain
{
    public class EnderecoBo: IEnderecoBo
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoBo(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public void AlterarEndereco(Endereco endereco)
        {
            _enderecoRepository.AlterarEndereco(endereco);
        }

        public void ExcluirEnderecoEmpresa(int codEmpresa, int codEndereco, string quem)
        {
            _enderecoRepository.ExcluirEnderecoEmpresa(codEmpresa, codEndereco, quem);
        }

        public void ExcluirEnderecoPessoa(int codPessoa, int codEndereco, string quem)
        {
            _enderecoRepository.ExcluirEnderecoPessoa(codPessoa, codEndereco, quem);
        }

        public int InserirEnderecoEmpresa(Empresa empresa)
        {
            return _enderecoRepository.InserirEnderecoEmpresa(empresa);
        }

        public int InserirEnderecoPessoa(Pessoa pessoa)
        {
            return _enderecoRepository.InserirEnderecoPessoa(pessoa);
        }

        public List<Endereco> ListarEnderecosEmpresa(int codEmpresa)
        {
            return _enderecoRepository.ListarEnderecosEmpresa(codEmpresa);
        }

        public List<Endereco> ListarEnderecosPessoa(int codPessoa)
        {
            return _enderecoRepository.ListarEnderecosPessoa(codPessoa);
        }

        public List<TipoEndereco> ListarTipoEndereco()
        {
            return _enderecoRepository.ListarTipoEndereco();
        }

        public Endereco ObterEndereco(int codEndereco)
        {
           return _enderecoRepository.ObterEndereco(codEndereco);
        }
    }
}
