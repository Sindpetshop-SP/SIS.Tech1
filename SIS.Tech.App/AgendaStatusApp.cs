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
    public class AgendaStatusApp : IAgendaStatusApp
    {
        private readonly IAgendaStatusBo _AgendaStatusBo;

        public AgendaStatusApp(IAgendaStatusBo AgendaStatusBo)
        {
            _AgendaStatusBo = AgendaStatusBo;
        }

        public List<AgendaStatus> ListarAgendaStatus()
        {
            return _AgendaStatusBo.ListarAgendaStatus();
        }

        public List<AgendaStatus> ListarAgendaStatusFiltro(string codAgendaStatus, string descricao)
        {
            return _AgendaStatusBo.ListarAgendaStatusFiltro(codAgendaStatus, descricao);
        }

        public AgendaStatus ObterAgendaStatus(int codAgendaStatus)
        {
            return _AgendaStatusBo.ObterAgendaStatus(codAgendaStatus);
        }
    }
}
