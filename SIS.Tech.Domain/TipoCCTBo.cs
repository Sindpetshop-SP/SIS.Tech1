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
    public class TipoCCTBo : ITipoCCTBo
    {
        private readonly ITipoCCTRepository _tipoCCTRepository;

        public TipoCCTBo(ITipoCCTRepository tipoCCTRepository)
        {
            _tipoCCTRepository = tipoCCTRepository;
        }

        public List<TipoCCT> ListarTipoCCT()
        {
            return _tipoCCTRepository.ListarTipoCCT();
        }

        public List<TipoCCT> ListarTipoCCTFiltro(string codTipoCCT, string descricao)
        {
            return _tipoCCTRepository.ListarTipoCCTFiltro(codTipoCCT, descricao);
        }

        public TipoCCT ObterTipoCCT(int codTipoCCT)
        {
            return _tipoCCTRepository.ObterTipoCCT(codTipoCCT);
        }
        public int InserirTipoCCT(TipoCCT TipoCCT)
        {
            return _tipoCCTRepository.InserirTipoCCT(TipoCCT);
        }

        public int AlterarTipoCCT(TipoCCT TipoCCT)
        {
            return _tipoCCTRepository.AlterarTipoCCT(TipoCCT);
        }

        public int ExcluirTipoCCT(int codTipoCCT, string quem)
        {
            return _tipoCCTRepository.ExcluirTipoCCT(codTipoCCT, quem);
        }

    }

}
