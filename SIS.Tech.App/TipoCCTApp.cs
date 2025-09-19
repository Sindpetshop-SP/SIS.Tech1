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
    public class TipoCCTApp : ITipoCCTApp
    {
        private readonly ITipoCCTBo _tipoCCTBo;

        public TipoCCTApp(ITipoCCTBo tipoCCTBo)
        {
            _tipoCCTBo = tipoCCTBo;
        }

        public List<TipoCCT> ListarTipoCCT()
        {
            return _tipoCCTBo.ListarTipoCCT();
        }

        public List<TipoCCT> ListarTipoCCTFiltro(string codTipoCCT, string descricao)
        {
            return _tipoCCTBo.ListarTipoCCTFiltro(codTipoCCT, descricao);
        }

        public TipoCCT ObterTipoCCT(int codTipoCCT)
        {
            return _tipoCCTBo.ObterTipoCCT(codTipoCCT);
        }

        public int InserirTipoCCT(TipoCCT TipoCCT)
        {
            return _tipoCCTBo.InserirTipoCCT(TipoCCT);
        }


        public int AlterarTipoCCT(TipoCCT TipoCCT)
        {
            return _tipoCCTBo.AlterarTipoCCT(TipoCCT);
        }

        public int ExcluirTipoCCT(int codTipoCCT, string quem)
        {
            return _tipoCCTBo.ExcluirTipoCCT(codTipoCCT, quem);
        }

      
    }
}
