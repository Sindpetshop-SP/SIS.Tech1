using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SIS.Tech.Domain.Model
{
    [Serializable]
    public class AgendaStatus
    {
        public int CodAgendaStatus { get; set; }

        public string Descricao { get; set; }

        public List<AgendaStatus> lstAgendaStatus { get; set; }
    }
}
