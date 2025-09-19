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
    public class RamoAtividadeBo : IRamoAtividadeBo
    {
        private readonly IRamoAtividadeRepository _RamoAtividadeRepository;

        public RamoAtividadeBo(IRamoAtividadeRepository RamoAtividadeRepository)
        {
            _RamoAtividadeRepository = RamoAtividadeRepository;
        }

        public void AlterarRamoAtividade(RamoAtividade RamoAtividade)
        {
            _RamoAtividadeRepository.AlterarRamoAtividade(RamoAtividade);
        }

        public void ExcluirRamoAtividade(int codRamoAtividade, string quem)
        {
            _RamoAtividadeRepository.ExcluirRamoAtividade(codRamoAtividade, quem);
        }

        public int InserirRamoAtividade(RamoAtividade RamoAtividade)
        {
            return _RamoAtividadeRepository.InserirRamoAtividade(RamoAtividade);
        }

        public List<RamoAtividade> ListarRamoAtividade()
        {
            return _RamoAtividadeRepository.ListarRamoAtividade();
        }

        public List<RamoAtividade> ListarRamoAtividadeFiltro(string codRamoAtividade, string descricao)
        {
            return _RamoAtividadeRepository.ListarRamoAtividadeFiltro(codRamoAtividade, descricao);
        }

        public RamoAtividade ObterRamoAtividade(int codRamoAtividade)
        {
            return _RamoAtividadeRepository.ObterRamoAtividade(codRamoAtividade);
        }
    }
}
