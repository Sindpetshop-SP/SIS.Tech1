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
    public class AgendaStatusBo : IAgendaStatusBo
    {
        private readonly IAgendaStatusRepository _AgendaStatusRepository;

        public AgendaStatusBo(IAgendaStatusRepository AgendaStatusRepository)
        {
            _AgendaStatusRepository = AgendaStatusRepository;
        }

        public List<AgendaStatus> ListarAgendaStatus()
        {
            return _AgendaStatusRepository.ListarAgendaStatus();
        }
        public List<AgendaStatus> ListarAgendaStatusFiltro(string codAgendaStatus, string descricao)
        {
            return _AgendaStatusRepository.ListarAgendaStatusFiltro(codAgendaStatus, descricao);
        }
        public AgendaStatus ObterAgendaStatus(int codAgendaStatus)
        {
            return _AgendaStatusRepository.ObterAgendaStatus(codAgendaStatus);
        }
    }

}
