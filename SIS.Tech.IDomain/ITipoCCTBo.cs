using SIS.Tech.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.IDomain
{
    public interface ITipoCCTBo
    {
        List<TipoCCT> ListarTipoCCT();

        List<TipoCCT> ListarTipoCCTFiltro(string codTipoCCT, string descricao);

        TipoCCT ObterTipoCCT(int codTipoCCT);

        int InserirTipoCCT(TipoCCT TipoCCT);

        int AlterarTipoCCT(TipoCCT TipoCCT);

        int ExcluirTipoCCT(int codTipoCCT, string quem);
    }
}
