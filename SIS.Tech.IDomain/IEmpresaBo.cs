using SIS.Tech.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.IDomain
{
    public interface IEmpresaBo
    {
        int IncluirEmpresa(Empresa empresa);

        int AlterarEmpresa(Empresa empresa);

        int ExcluirEmpresa(int codEmpresa, string quem);

        List<Empresa> ListarEmpresa();

        List<Empresa> ListarEmpresaFiltro(string cnpj, string nome, string nomeFantasia);

        Empresa ObterEmpresa(int codEmpresa);
    }
}
