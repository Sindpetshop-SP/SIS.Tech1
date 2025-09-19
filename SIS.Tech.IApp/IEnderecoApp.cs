using SIS.Tech.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.IApp
{
    public interface  IEnderecoApp
    {
        List<TipoEndereco> ListarTipoEndereco();

        Endereco ObterEndereco(int codEndereco);

        void AlterarEndereco(Endereco endereco);


        //EMPRESA
        List<Endereco> ListarEnderecosEmpresa(int codEmpresa);

        int InserirEnderecoEmpresa(Empresa empresa);

        void ExcluirEnderecoEmpresa(int codEmpresa, int codEndereco, string quem);


        //FUNCIONARIO
        List<Endereco> ListarEnderecosPessoa(int codPessoa);

        int InserirEnderecoPessoa(Pessoa pessoa);

        void ExcluirEnderecoPessoa(int codPessoa, int codEndereco, string quem);

    }
}
