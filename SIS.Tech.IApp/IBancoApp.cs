using SIS.Tech.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.IApp
{
    public interface IBancoApp
    {
        List<Banco> ListarBanco();

        List<Banco> ListarBancoFiltro(string codBanco, string nomeBanco);

        Banco ObterBanco(int codBanco);

        int InserirBanco(Banco Banco);

        int AlterarBanco(Banco Banco);

        int ExcluirBanco(int codBanco, string quem);
    }
}
