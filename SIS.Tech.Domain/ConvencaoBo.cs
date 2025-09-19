using SIS.Tech.Domain.Model;
using SIS.Tech.IDomain;
using SIS.Tech.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Domain
{
    public class ConvencaoBo: IConvencaoBo
    {
        private readonly IConvencaoRepository _convencaoRepository;

        public ConvencaoBo(IConvencaoRepository convencaoRepository)
        {
            _convencaoRepository = convencaoRepository;
        }

        public int InserirConvencao(Convencao convencao)
        {
            return _convencaoRepository.InserirConvencao(convencao);
        }

        public int AlterarConvencao(Convencao convencao)
        {
            return _convencaoRepository.AlterarConvencao(convencao);
        }

        public void ExcluirConvencao(int codConvencao, string quem)
        {
            _convencaoRepository.ExcluirConvencao(codConvencao, quem);
        }

        public List<Convencao> ListarConvencao(string nomeConvencao, int codTipoCCT, int codStatusCCT, string anoVigenciaInicial, string anoVigenciaFinal)
        {
            return _convencaoRepository.ListarConvencao(nomeConvencao, codTipoCCT, codStatusCCT, anoVigenciaInicial, anoVigenciaFinal);
        }

        public Convencao ObterConvencao(int codConvencao)
        {
            return _convencaoRepository.ObterConvencao(codConvencao);
        }

        public List<string> ObterTotaisCCT()
        {
            return _convencaoRepository.ObterTotaisCCT();
        }
    }
}
