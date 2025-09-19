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
    public class BancoBo : IBancoBo
    {
        private readonly IBancoRepository _bancoRepository;

        public BancoBo(IBancoRepository bancoRepository)
        {
            _bancoRepository = bancoRepository;
        }

        public int AlterarBanco(Banco banco)
        {
            return _bancoRepository.AlterarBanco(banco);
        }

        public int ExcluirBanco(int codBanco, string quem)
        {
            return _bancoRepository.ExcluirBanco(codBanco, quem);
        }

        public int InserirBanco(Banco banco)
        {
            return _bancoRepository.InserirBanco(banco);
        }

        public List<Banco> ListarBanco()
        {
            return _bancoRepository.ListarBanco();
        }
        public List<Banco> ListarBancoFiltro(string codBanco, string nomeBanco)
        {
            return _bancoRepository.ListarBancoFiltro(codBanco, nomeBanco);
        }
        public Banco ObterBanco(int codBanco)
        {
            return _bancoRepository.ObterBanco(codBanco);
        }
    }

}
