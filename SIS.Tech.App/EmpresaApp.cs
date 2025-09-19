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
    public class EmpresaApp : IEmpresaApp
    {
        private readonly IEmpresaBo _empresaBo;

        public EmpresaApp(IEmpresaBo empresaBo)
        {
            _empresaBo = empresaBo;
        }

        public int AlterarEmpresa(Empresa empresa)
        {
            return _empresaBo.AlterarEmpresa(empresa);
        }

        public int ExcluirEmpresa(int codEmpresa, string quem)
        {
            return _empresaBo.ExcluirEmpresa(codEmpresa, quem);
        }

        public int IncluirEmpresa(Empresa empresa)
        {
            return _empresaBo.IncluirEmpresa(empresa);
        }

        public List<Empresa> ListarEmpresa()
        {
            return _empresaBo.ListarEmpresa();
        }

        public List<Empresa> ListarEmpresaFiltro(string cnpj, string nome, string nomeFantasia)
        {
            return _empresaBo.ListarEmpresaFiltro(cnpj, nome, nomeFantasia);
        }

        public Empresa ObterEmpresa(int codEmpresa)
        {
            return _empresaBo.ObterEmpresa(codEmpresa);
        }
    }
}
