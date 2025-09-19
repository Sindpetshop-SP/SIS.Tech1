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
    public class AgendaBo : IAgendaBo
    {
        private readonly IAgendaRepository _agendaRepository;

        public AgendaBo(IAgendaRepository agendaRepository)
        {
            _agendaRepository = agendaRepository;
        }
        public int AlterarAgenda(Agenda agenda)
        {
            return _agendaRepository.AlterarAgenda(agenda);
        }

        public int ExcluirAgenda(int codAgenda, string quem)
        {
            return ExcluirAgenda(codAgenda, quem);
        }

        public int InserirAgenda(Agenda agenda)
        {
            return InserirAgenda(agenda);
        }

        public List<Agenda> ListarAgendaFiltro(string codPessoa, DateTime dtInicio, DateTime dtTermino)
        {
            return ListarAgendaFiltro(codPessoa, dtInicio, dtTermino);
        }

        public List<Agenda> ListarAgendas()
        {
            return ListarAgendas();
        }

        public Agenda ObterAgenda(int codAgenda)
        {
            return ObterAgenda(codAgenda);
        }
    }

}
