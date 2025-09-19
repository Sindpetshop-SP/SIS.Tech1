using SIS.Tech.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.IApp
{
    public interface IFuncionarioApp
    {
        int IncluirFuncionario(Funcionario funcionario);

        int AlterarFuncionario(Funcionario funcionario);

        int ExcluirFuncionario(int codFuncionario, string quem);

        List<Funcionario> ListarFuncionario();

        List<Funcionario> ListarFuncionarioFiltro(string cpf, string nome, int codEmpresa);

        Funcionario ObterFuncionario(int codFuncionario);
    }
}
