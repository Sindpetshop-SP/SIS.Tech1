using SIS.Tech.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.IApp
{
    public interface ITipoContatoApp
    {
        List<TipoContato> ListarTipoContato();

        List<TipoContato> ListarTipoContatoFiltro(string codTipoContato, string descricao);

        TipoContato ObterTipoContato(int codTipoContato);

        int InserirTipoContato(TipoContato tipoContato);

        void AlterarTipoContato(TipoContato tipoContato);

        void ExcluirTipoContato(int codTipoContato, string quem);
    }
}
