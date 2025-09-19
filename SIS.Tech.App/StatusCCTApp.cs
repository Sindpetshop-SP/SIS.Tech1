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
    public class StatusCCTApp : IStatusCCTApp
    {
        private readonly IStatusCCTBo _statusCCTBo;

        public StatusCCTApp(IStatusCCTBo statusCCTBo)
        {
            _statusCCTBo = statusCCTBo;
        }

        public List<StatusCCT> ListarStatusCCT()
        {
            return _statusCCTBo.ListarStatusCCT();
        }

        public List<StatusCCT> ListarStatusCCTFiltro(string codStatusCCT, string descricao)
        {
            return _statusCCTBo.ListarStatusCCTFiltro(codStatusCCT, descricao);
        }

        public StatusCCT ObterStatusCCT(int codStatusCCT)
        {
            return _statusCCTBo.ObterStatusCCT(codStatusCCT);
        }

        public int InserirStatusCCT(StatusCCT StatusCCT)
        {
            return _statusCCTBo.InserirStatusCCT(StatusCCT);
        }


        public int AlterarStatusCCT(StatusCCT StatusCCT)
        {
            return _statusCCTBo.AlterarStatusCCT(StatusCCT);
        }

        public int ExcluirStatusCCT(int codStatusCCT, string quem)
        {
            return _statusCCTBo.ExcluirStatusCCT(codStatusCCT, quem);
        }

      
    }
}
