using SIS.Tech.Domain.Model;
using SIS.Tech.IApp;
using SIS.Tech.IDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.App
{
    public class FuncionarioApp : IFuncionarioApp
    {
        private readonly IFuncionarioBo _funcionarioBo;

        public FuncionarioApp(IFuncionarioBo funcionarioBo)
        {
            _funcionarioBo = funcionarioBo;
        }

        public int AlterarFuncionario(Funcionario Funcionario)
        {
            return _funcionarioBo.AlterarFuncionario(Funcionario);
        }

        public int ExcluirFuncionario(int codFuncionario, string quem)
        {
            return _funcionarioBo.ExcluirFuncionario(codFuncionario, quem);
        }

        public int IncluirFuncionario(Funcionario Funcionario)
        {
            return _funcionarioBo.IncluirFuncionario(Funcionario);
        }

        public List<Funcionario> ListarFuncionario()
        {
            return _funcionarioBo.ListarFuncionario();
        }

        public List<Funcionario> ListarFuncionarioFiltro(string cpf, string nome, int codEmpresa)
        {
            return _funcionarioBo.ListarFuncionarioFiltro(cpf, nome, codEmpresa);
        }

        public Funcionario ObterFuncionario(int codFuncionario)
        {
            return _funcionarioBo.ObterFuncionario(codFuncionario);
        }
    }
}
