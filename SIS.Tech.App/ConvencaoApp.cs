using SIS.Tech.Domain.Model;
using SIS.Tech.IApp;
using SIS.Tech.IDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.App
{
    public class ConvencaoApp : IConvencaoApp
    {
        private readonly IConvencaoBo _convencaoBo;

        public ConvencaoApp(IConvencaoBo convencaoBo)
        {
            _convencaoBo = convencaoBo;
        }       
       
        public int InserirConvencao(Convencao convencao)
        {
            return _convencaoBo.InserirConvencao(convencao);
        }

        public int AlterarConvencao(Convencao convencao)
        {
            return _convencaoBo.AlterarConvencao(convencao);
        }

        public void ExcluirConvencao(int codConvencao, string quem)
        {
            _convencaoBo.ExcluirConvencao(codConvencao, quem);
        }

        public List<Convencao> ListarConvencao(string nomeConvencao, int codTipoCCT, int codStatusCCT, string anoVigenciaInicial, string anoVigenciaFinal)
        {
            return _convencaoBo.ListarConvencao(nomeConvencao, codTipoCCT, codStatusCCT, anoVigenciaInicial, anoVigenciaFinal);
        }

        public Convencao ObterConvencao(int codConvencao)
        {
            return _convencaoBo.ObterConvencao(codConvencao);
        }

        public List<string> ObterTotaisCCT()
        {
            return _convencaoBo.ObterTotaisCCT();
        }
        
    }
}
