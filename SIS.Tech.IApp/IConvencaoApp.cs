using SIS.Tech.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.IApp
{
    public interface IConvencaoApp
    {
        int InserirConvencao(Convencao convencao);

        int AlterarConvencao(Convencao convencao);

        void ExcluirConvencao(int codConvencao, string quem);

        List<Convencao> ListarConvencao(string nomeConvencao, int codTipoCCT, int codStatusCCT, string anoVigenciaInicial, string anoVigenciaFinal);

        Convencao ObterConvencao(int codConvencao);

        List<string> ObterTotaisCCT();

    }
}
