using SIS.Tech.IDomain;
using SIS.Tech.Domain.Model;
using SIS.Tech.IApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.App
{
    public class ContaTipoApp : IContaTipoApp
    {
        private readonly IContaTipoBo _contaTipoBo;

        public ContaTipoApp(IContaTipoBo contaTipoBo)
        {
            _contaTipoBo = contaTipoBo;
        }

        public int AlterarContaTipo(ContaTipo contaTipo)
        {
            return _contaTipoBo.AlterarContaTipo(contaTipo);
        }

        public int ExcluirContaTipo(int codContaTipo, string quem)
        {
            return _contaTipoBo.ExcluirContaTipo(codContaTipo, quem);
        }

        public int InserirContaTipo(ContaTipo contaTipo)
        {
            return _contaTipoBo.InserirContaTipo(contaTipo);
        }

        public List<ContaTipo> ListarContaTipo()
        {
            return _contaTipoBo.ListarContaTipo();
        }

        public List<ContaTipo> ListarContaTipoFiltro(string codContaTipo, string descricao)
        {
            return _contaTipoBo.ListarContaTipoFiltro(codContaTipo, descricao);
        }

        public ContaTipo ObterContaTipo(int codContaTipo)
        {
            return _contaTipoBo.ObterContaTipo(codContaTipo);
        }
    }
}
