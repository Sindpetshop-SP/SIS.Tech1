using SIS.Tech.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.IDomain
{
    public interface IContaTipoBo
    {
        List<ContaTipo> ListarContaTipo();

        List<ContaTipo> ListarContaTipoFiltro(string codContaTipo, string descricao);

        ContaTipo ObterContaTipo(int codContaTipo);

        int InserirContaTipo(ContaTipo ContaTipo);

        int AlterarContaTipo(ContaTipo ContaTipo);

        int ExcluirContaTipo(int codContaTipo, string quem);
    }
}
