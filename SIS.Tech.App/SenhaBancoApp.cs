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
    public class SenhaBancoApp : ISenhaBancoApp
    {
        private readonly ISenhaBancoBo _senhaBancoBo;

        public SenhaBancoApp(ISenhaBancoBo senhaBancoBo)
        {
            _senhaBancoBo = senhaBancoBo;
        }

        public List<SenhaBanco> ListarSenhaBancoFiltro(string codInstituicao, string usuario)
        {
            return _senhaBancoBo.ListarSenhaBancoFiltro(codInstituicao, usuario);
        }

        public List<SenhaBanco> ListarSenhaBanco(string usuario)
        {
            return _senhaBancoBo.ListarSenhaBanco(usuario);
        }


        public SenhaBanco ObterSenhaBanco(int codSenhaBanco, string usuario)
        {
            return _senhaBancoBo.ObterSenhaBanco(codSenhaBanco, usuario);
        }
              

        public int InserirSenhaBanco(SenhaBanco senhaBanco)
        {
            return _senhaBancoBo.InserirSenhaBanco(senhaBanco);
        }

        public int AlterarSenhaBanco(SenhaBanco senhaBanco)
        {
            return _senhaBancoBo.AlterarSenhaBanco(senhaBanco);
        }

        public int ExcluirSenhaBanco(int codSenhaBanco, string quem)
        {
            return _senhaBancoBo.ExcluirSenhaBanco(codSenhaBanco, quem);
        }

    }
}
