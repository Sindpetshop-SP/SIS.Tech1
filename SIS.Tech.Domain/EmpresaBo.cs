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
    public class EmpresaBo : IEmpresaBo
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaBo(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public int AlterarEmpresa(Empresa empresa)
        {
            return _empresaRepository.AlterarEmpresa(empresa);
        }

        public int ExcluirEmpresa(int codEmpresa, string quem)
        {
            return _empresaRepository.ExcluirEmpresa(codEmpresa, quem);
        }

        public int IncluirEmpresa(Empresa empresa)
        {
            return _empresaRepository.IncluirEmpresa(empresa);
        }

        public List<Empresa> ListarEmpresa()
        {
            return _empresaRepository.ListarEmpresa();
        }

        public List<Empresa> ListarEmpresaFiltro(string cnpj, string nome, string nomeFantasia)
        {
            return _empresaRepository.ListarEmpresaFiltro(cnpj, nome, nomeFantasia);
        }

        public Empresa ObterEmpresa(int codEmpresa)
        {
            return _empresaRepository.ObterEmpresa(codEmpresa);
        }
    }
}
