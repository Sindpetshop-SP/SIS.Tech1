using SIS.Tech.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.IRepository
{
    public interface IFuncionarioRepository
    {
        int IncluirFuncionario(Funcionario Funcionario);

        int AlterarFuncionario(Funcionario Funcionario);

        int ExcluirFuncionario(int codFuncionario, string quem);

        List<Funcionario> ListarFuncionario();

        List<Funcionario> ListarFuncionarioFiltro(string cnpj, string nome, int codEmpresa);

        Funcionario ObterFuncionario(int codFuncionario);

    }
}
