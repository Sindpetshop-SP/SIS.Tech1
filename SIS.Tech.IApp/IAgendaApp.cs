using SIS.Tech.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.IApp
{
    public interface IAgendaApp
    {
        List<Agenda> ListarAgendas();

        List<Agenda> ListarAgendaFiltro(string codPessoa, DateTime dtInicio, DateTime dtTermino);

        Agenda ObterAgenda(int codAgenda);

        int InserirAgenda(Agenda agenda);

        int AlterarAgenda(Agenda agenda);

        int ExcluirAgenda(int codAgenda, string quem);

    }
}
