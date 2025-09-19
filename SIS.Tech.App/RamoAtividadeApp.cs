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
    public class RamoAtividadeApp: IRamoAtividadeApp
    {
        private readonly IRamoAtividadeBo _RamoAtividadeBo;

        public RamoAtividadeApp(IRamoAtividadeBo RamoAtividadeBo)
        {
            _RamoAtividadeBo = RamoAtividadeBo;
        }

        public void AlterarRamoAtividade(RamoAtividade RamoAtividade)
        {
            _RamoAtividadeBo.AlterarRamoAtividade(RamoAtividade);
        }

        public void ExcluirRamoAtividade(int codRamoAtividade, string quem)
        {
            _RamoAtividadeBo.ExcluirRamoAtividade(codRamoAtividade, quem);
        }

        public int InserirRamoAtividade(RamoAtividade RamoAtividade)
        {
            return _RamoAtividadeBo.InserirRamoAtividade(RamoAtividade);
        }

        public List<RamoAtividade> ListarRamoAtividade()
        {
            return _RamoAtividadeBo.ListarRamoAtividade();
        }

        public List<RamoAtividade> ListarRamoAtividadeFiltro(string codRamoAtividade, string descricao)
        {
            return _RamoAtividadeBo.ListarRamoAtividadeFiltro(codRamoAtividade, descricao);
        }

        public RamoAtividade ObterRamoAtividade(int codRamoAtividade)
        {
            return _RamoAtividadeBo.ObterRamoAtividade(codRamoAtividade);
        }
    }
}
