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
    public class BancoApp : IBancoApp
    {
        private readonly IBancoBo _bancoBo;

        public BancoApp(IBancoBo bancoBo)
        {
            _bancoBo = bancoBo;
        }

        public int AlterarBanco(Banco banco)
        {
            return _bancoBo.AlterarBanco(banco);
        }

        public int ExcluirBanco(int codBanco, string quem)
        {
            return _bancoBo.ExcluirBanco(codBanco, quem);
        }

        public int InserirBanco(Banco banco)
        {
            return _bancoBo.InserirBanco(banco);
        }

        public List<Banco> ListarBanco()
        {
            return _bancoBo.ListarBanco();
        }

        public List<Banco> ListarBancoFiltro(string codBanco, string nomeBanco)
        {
            return _bancoBo.ListarBancoFiltro(codBanco, nomeBanco);
        }

        public Banco ObterBanco(int codBanco)
        {
            return _bancoBo.ObterBanco(codBanco);
        }
    }
}
