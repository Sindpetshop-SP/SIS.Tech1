using SIS.Tech.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.IRepository
{
    public interface IContaTipoRepository 
    {
        List<ContaTipo> ListarContaTipo();

        List<ContaTipo> ListarContaTipoFiltro(string codContaTipo, string descricao);

        ContaTipo ObterContaTipo(int codContaTipo);

        int InserirContaTipo(ContaTipo contaTipo);

        int AlterarContaTipo(ContaTipo contaTipo);

        int ExcluirContaTipo(int codContaTipo, string quem);
    }
}
