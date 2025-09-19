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
    public class ContatoBo : IContatoBo
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoBo(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public void AlterarContato(Contato contato)
        {
            _contatoRepository.AlterarContato(contato);
        }

        public void ExcluirContatoEmpresa(int codEmpresa, int codContato, string quem)
        {
            _contatoRepository.ExcluirContatoEmpresa(codEmpresa, codContato, quem);
        }

        public void ExcluirContatoPessoa(int codPessoa, int codContato, string quem)
        {
            _contatoRepository.ExcluirContatoPessoa(codPessoa, codContato, quem);
        }

        public int InserirContatoEmpresa(Empresa Empresa)
        {
            return _contatoRepository.InserirContatoEmpresa(Empresa);
        }

        public int InserirContatoPessoa(Pessoa pessoa)
        {
            return _contatoRepository.InserirContatoPessoa(pessoa);
        }

        public List<Contato> ListarContatosEmpresa(int codEmpresa)
        {
            return _contatoRepository.ListarContatosEmpresa(codEmpresa);
        }

        public List<Contato> ListarContatosPessoa(int codPessoa)
        {
            return _contatoRepository.ListarContatosPessoa(codPessoa);
        }

        public List<TipoContato> ListarTipoContato()
        {
            return _contatoRepository.ListarTipoContato();
        }

        public Contato ObterContato(int codContato)
        {
            return _contatoRepository.ObterContato(codContato);
        }
    }
}
