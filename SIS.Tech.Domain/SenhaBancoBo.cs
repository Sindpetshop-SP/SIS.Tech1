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
    public class SenhaBancoBo : ISenhaBancoBo
    {
        private readonly ISenhaBancoRepository _senhaBancoRepository;

        public SenhaBancoBo(ISenhaBancoRepository senhaBancoRepository)
        {
            _senhaBancoRepository = senhaBancoRepository;
        }

        public List<SenhaBanco> ListarSenhaBanco(string usuario)
        {
            return _senhaBancoRepository.ListarSenhaBanco(usuario);
        }
        public List<SenhaBanco> ListarSenhaBancoFiltro(string codInstituicao, string usuario)
        {
            return _senhaBancoRepository.ListarSenhaBancoFiltro(codInstituicao, usuario);
        }
        public SenhaBanco ObterSenhaBanco(int codSenhaBanco, string usuario)
        {
            return _senhaBancoRepository.ObterSenhaBanco(codSenhaBanco, usuario);
        }

        public int InserirSenhaBanco(SenhaBanco senhaBanco)
        {
            return _senhaBancoRepository.InserirSenhaBanco(senhaBanco);
        }

        public int AlterarSenhaBanco(SenhaBanco senhaBanco)
        {
            return _senhaBancoRepository.AlterarSenhaBanco(senhaBanco);
        }

        public int ExcluirSenhaBanco(int codSenhaBanco, string quem)
        {
            return _senhaBancoRepository.ExcluirSenhaBanco(codSenhaBanco, quem);
        }


       
    }

}
