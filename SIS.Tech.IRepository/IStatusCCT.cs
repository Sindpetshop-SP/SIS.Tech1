using SIS.Tech.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.IRepository
{
    public interface IStatusCCTRepository 
    {
        List<StatusCCT> ListarStatusCCT();

        List<StatusCCT> ListarStatusCCTFiltro(string codStatusCCT, string descricao);

        StatusCCT ObterStatusCCT(int codStatusCCT);

        int InserirStatusCCT(StatusCCT StatusCCT);

        int AlterarStatusCCT(StatusCCT StatusCCT);

        int ExcluirStatusCCT(int codStatusCCT, string quem);
    }
}
