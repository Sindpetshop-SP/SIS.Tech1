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
    public class TipoContatoApp : ITipoContatoApp
    {

        private readonly ITipoContatoBo _tipoContatoBo;

        public TipoContatoApp(ITipoContatoBo tipoContatoBo)
        {
            _tipoContatoBo = tipoContatoBo;
        }

        public void AlterarTipoContato(TipoContato tipoContato)
        {
            _tipoContatoBo.AlterarTipoContato(tipoContato);
        }

        public void ExcluirTipoContato(int codTipoContato, string quem)
        {
            _tipoContatoBo.ExcluirTipoContato(codTipoContato, quem);
        }

        public int InserirTipoContato(TipoContato tipoContato)
        {
            return _tipoContatoBo.InserirTipoContato(tipoContato);
        }

        public List<TipoContato> ListarTipoContato()
        {
            return _tipoContatoBo.ListarTipoContato();
        }

        public List<TipoContato> ListarTipoContatoFiltro(string codTipoContato, string descricao)
        {
            return _tipoContatoBo.ListarTipoContatoFiltro(codTipoContato, descricao);
        }

        public TipoContato ObterTipoContato(int codTipoContato)
        {
            return _tipoContatoBo.ObterTipoContato(codTipoContato);
        }
    }
}
