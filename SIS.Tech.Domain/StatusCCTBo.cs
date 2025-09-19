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
    public class StatusCCTBo : IStatusCCTBo
    {
        private readonly IStatusCCTRepository _statusCCTRepository;

        public StatusCCTBo(IStatusCCTRepository statusCCTRepository)
        {
            _statusCCTRepository = statusCCTRepository;
        }

        public List<StatusCCT> ListarStatusCCT()
        {
            return _statusCCTRepository.ListarStatusCCT();
        }

        public List<StatusCCT> ListarStatusCCTFiltro(string codStatusCCT, string descricao)
        {
            return _statusCCTRepository.ListarStatusCCTFiltro(codStatusCCT, descricao);
        }

        public StatusCCT ObterStatusCCT(int codStatusCCT)
        {
            return _statusCCTRepository.ObterStatusCCT(codStatusCCT);
        }
        public int InserirStatusCCT(StatusCCT StatusCCT)
        {
            return _statusCCTRepository.InserirStatusCCT(StatusCCT);
        }

        public int AlterarStatusCCT(StatusCCT StatusCCT)
        {
            return _statusCCTRepository.AlterarStatusCCT(StatusCCT);
        }

        public int ExcluirStatusCCT(int codStatusCCT, string quem)
        {
            return _statusCCTRepository.ExcluirStatusCCT(codStatusCCT, quem);
        }

    }

}
