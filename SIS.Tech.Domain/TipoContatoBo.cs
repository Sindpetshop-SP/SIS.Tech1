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
    public class TipoContatoBo : ITipoContatoBo
    {
        private readonly ITipoContatoRepository _tipoContatoRepository;

        public TipoContatoBo(ITipoContatoRepository tipoContatoRepository)
        {
            _tipoContatoRepository = tipoContatoRepository;
        }

        public void AlterarTipoContato(TipoContato tipoContato)
        {
            _tipoContatoRepository.AlterarTipoContato(tipoContato);
        }

        public void ExcluirTipoContato(int codTipoContato, string quem)
        {
            _tipoContatoRepository.ExcluirTipoContato(codTipoContato, quem);
        }

        public int InserirTipoContato(TipoContato tipoContato)
        {
            return _tipoContatoRepository.InserirTipoContato(tipoContato);
        }

        public List<TipoContato> ListarTipoContato()
        {
            return _tipoContatoRepository.ListarTipoContato();
        }

        public List<TipoContato> ListarTipoContatoFiltro(string codTipoContato, string descricao)
        {
            return _tipoContatoRepository.ListarTipoContatoFiltro(codTipoContato, descricao);
        }

        public TipoContato ObterTipoContato(int codTipoContato)
        {
            return _tipoContatoRepository.ObterTipoContato(codTipoContato);
        }
    }
}
