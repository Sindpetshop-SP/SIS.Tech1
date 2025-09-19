using SIS.Tech.Domain.Model;
using SIS.Tech.IApp;
using SIS.Tech.IDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.App
{
    public class AgendaApp : IAgendaApp
    {
        private readonly IAgendaBo _agendaBo;

        public AgendaApp(IAgendaBo agendaBo)
        {
            _agendaBo = agendaBo;
        }

        public int AlterarAgenda(Agenda agenda)
        {
            return _agendaBo.AlterarAgenda(agenda);
        }

        public int ExcluirAgenda(int codAgenda, string quem)
        {
            return _agendaBo.ExcluirAgenda(codAgenda, quem);
        }

        public int InserirAgenda(Agenda agenda)
        {
            return _agendaBo.InserirAgenda(agenda);
        }

        public List<Agenda> ListarAgendaFiltro(string codPessoa, DateTime dtInicio, DateTime dtTermino)
        {
            return _agendaBo.ListarAgendaFiltro(codPessoa, dtInicio, dtTermino);
        }

        public List<Agenda> ListarAgendas()
        {
            return _agendaBo.ListarAgendas();
        }

        public Agenda ObterAgenda(int codAgenda)
        {
            return _agendaBo.ObterAgenda(codAgenda);
        }
    }
}
