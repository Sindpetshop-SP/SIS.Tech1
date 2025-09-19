using SIS.Tech.Domain.Model;
using SIS.Tech.IDomain;
using SIS.Tech.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Domain
{
    public class FuncionarioBo : IFuncionarioBo
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioBo(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public int AlterarFuncionario(Funcionario Funcionario)
        {
            return _funcionarioRepository.AlterarFuncionario(Funcionario);
        }

        public int ExcluirFuncionario(int codFuncionario, string quem)
        {
            return _funcionarioRepository.ExcluirFuncionario(codFuncionario, quem);
        }

        public int IncluirFuncionario(Funcionario Funcionario)
        {
            return _funcionarioRepository.IncluirFuncionario(Funcionario);
        }

        public List<Funcionario> ListarFuncionario()
        {
            return _funcionarioRepository.ListarFuncionario();
        }

        public List<Funcionario> ListarFuncionarioFiltro(string cnpj, string nome, int codEmpresa)
        {
            return _funcionarioRepository.ListarFuncionarioFiltro(cnpj, nome, codEmpresa);
        }

        public Funcionario ObterFuncionario(int codFuncionario)
        {
            return _funcionarioRepository.ObterFuncionario(codFuncionario);
        }
    }
}
