using SIS.Tech.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.IRepository
{
    public interface ITipoEnderecoRepository 
    {
        List<TipoEndereco> ListarTipoEndereco();

        List<TipoEndereco> ListarTipoEnderecoFiltro(string codTipoEndereco, string descricao);

        TipoEndereco ObterTipoEndereco(int codTipoEndereco);

        int InserirTipoEndereco(TipoEndereco tipoEndereco);

        void AlterarTipoEndereco(TipoEndereco tipoEndereco);

        void ExcluirTipoEndereco(int codTipoEndereco, string quem);
    }
}
