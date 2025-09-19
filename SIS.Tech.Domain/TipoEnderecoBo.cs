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
    public class TipoEnderecoBo: ITipoEnderecoBo
    {
        private readonly ITipoEnderecoRepository _tipoEnderecoRepository;

        public TipoEnderecoBo(ITipoEnderecoRepository tipoEnderecoRepository)
        {
            _tipoEnderecoRepository = tipoEnderecoRepository;
        }

        public void AlterarTipoEndereco(TipoEndereco tipoEndereco)
        {
            _tipoEnderecoRepository.AlterarTipoEndereco(tipoEndereco);
        }

        public void ExcluirTipoEndereco(int codTipoEndereco, string quem)
        {
            _tipoEnderecoRepository.ExcluirTipoEndereco(codTipoEndereco, quem);
        }

        public int InserirTipoEndereco(TipoEndereco tipoEndereco)
        {
            return _tipoEnderecoRepository.InserirTipoEndereco(tipoEndereco);
        }

        public List<TipoEndereco> ListarTipoEndereco()
        {
            return _tipoEnderecoRepository.ListarTipoEndereco();
        }
        public List<TipoEndereco> ListarTipoEnderecoFiltro(string codTipoEndereco, string descricao)
        {
            return _tipoEnderecoRepository.ListarTipoEnderecoFiltro(codTipoEndereco, descricao);
        }
        public TipoEndereco ObterTipoEndereco(int codTipoEndereco)
        {
            return _tipoEnderecoRepository.ObterTipoEndereco(codTipoEndereco);
        }
    }
}
