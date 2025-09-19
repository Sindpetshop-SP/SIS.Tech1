using SIS.Tech.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.IDomain
{
    public interface IBancoBo
    {
        List<Banco> ListarBanco();

        List<Banco> ListarBancoFiltro(string codBanco, string nomeBanco);

        Banco ObterBanco(int codBanco);

        int InserirBanco(Banco banco);

        int AlterarBanco(Banco banco);

        int ExcluirBanco(int codBanco, string quem);
    }
}
