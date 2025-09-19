using SIS.Tech.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.IRepository
{
    public interface IContatoRepository 
    {

        List<TipoContato> ListarTipoContato();

        Contato ObterContato(int codContato);

        void AlterarContato(Contato contato);


        //EMPRESA
        List<Contato> ListarContatosEmpresa(int codEmpresa);

        int InserirContatoEmpresa(Empresa Empresa);

        void ExcluirContatoEmpresa(int codEmpresa, int codContato, string quem);



        //PESSOA
        List<Contato> ListarContatosPessoa(int codPessoa);

        int InserirContatoPessoa(Pessoa pessoa);

        void ExcluirContatoPessoa(int codPessoa, int codContato, string quem);

    }
}
