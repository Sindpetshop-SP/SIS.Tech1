using SIS.Tech.IDomain;
using SIS.Tech.Domain.Model;
using SIS.Tech.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Domain
{
    public class ContaTipoBo : IContaTipoBo
    {
        private readonly IContaTipoRepository _contaTipoRepository;

        public ContaTipoBo(IContaTipoRepository contaTipoRepository)
        {
            _contaTipoRepository = contaTipoRepository;
        }

        public int AlterarContaTipo(ContaTipo contaTipo)
        {
            return _contaTipoRepository.AlterarContaTipo(contaTipo);
        }

        public int ExcluirContaTipo(int codContaTipo, string quem)
        {
            return _contaTipoRepository.ExcluirContaTipo(codContaTipo, quem);
        }

        public int InserirContaTipo(ContaTipo contaTipo)
        {
            return _contaTipoRepository.InserirContaTipo(contaTipo);
        }

        public List<ContaTipo> ListarContaTipo()
        {
            return _contaTipoRepository.ListarContaTipo();
        }
        public List<ContaTipo> ListarContaTipoFiltro(string codContaTipo, string descricao)
        {
            return _contaTipoRepository.ListarContaTipoFiltro(codContaTipo, descricao);
        }
        public ContaTipo ObterContaTipo(int codContaTipo)
        {
            return _contaTipoRepository.ObterContaTipo(codContaTipo);
        }
    }

}
