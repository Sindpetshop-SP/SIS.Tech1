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
    public class TipoEnderecoApp : ITipoEnderecoApp
    {

        private readonly ITipoEnderecoBo _tipoEnderecoBo;

        public TipoEnderecoApp(ITipoEnderecoBo tipoEnderecoBo)
        {
            _tipoEnderecoBo = tipoEnderecoBo;
        }

        public void AlterarTipoEndereco(TipoEndereco tipoEndereco)
        {
            AlterarTipoEndereco(tipoEndereco);
        }

        public void ExcluirTipoEndereco(int codTipoEndereco, string quem)
        {
            ExcluirTipoEndereco(codTipoEndereco, quem);
        }

        public int InserirTipoEndereco(TipoEndereco tipoEndereco)
        {
            return InserirTipoEndereco(tipoEndereco);
        }

        public List<TipoEndereco> ListarTipoEndereco()
        {
            return ListarTipoEndereco();
        }

        public List<TipoEndereco> ListarTipoEnderecoFiltro(string codTipoEndereco, string descricao)
        {
            return ListarTipoEnderecoFiltro(codTipoEndereco, descricao);
        }

        public TipoEndereco ObterTipoEndereco(int codTipoEndereco)
        {
            return ObterTipoEndereco(codTipoEndereco);
        }
    }
}
