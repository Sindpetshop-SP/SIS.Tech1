using SIS.Tech.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.IRepository
{
    public interface IAgendaStatusRepository
    {
        List<AgendaStatus> ListarAgendaStatus();

        List<AgendaStatus> ListarAgendaStatusFiltro(string codAgendaStatus, string descricao);

        AgendaStatus ObterAgendaStatus(int codAgendaStatus);
    }
}
