using SIS.Tech.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.IRepository
{
    public interface IRamoAtividadeRepository 
    {
        List<RamoAtividade> ListarRamoAtividade();

        List<RamoAtividade> ListarRamoAtividadeFiltro(string codRamoAtividade, string descricao);

        RamoAtividade ObterRamoAtividade(int codRamoAtividade);

        int InserirRamoAtividade(RamoAtividade RamoAtividade);

        void AlterarRamoAtividade(RamoAtividade RamoAtividade);

        void ExcluirRamoAtividade(int codRamoAtividade, string quem);
    }
}
