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
    public class Agenda
    {
        public int CodAgenda { get; set; }

        public AgendaStatus AgendaStatus { get; set; }

        public Pessoa Pessoa { get; set; }

        public Empresa Empresa { get; set; }

        public DateTime DataVisita { get; set; }

        public string Descricao { get; set; }

        public string Quem { get; set; }

        public List<Agenda> lstAgendas { get; set; }

    }
}
