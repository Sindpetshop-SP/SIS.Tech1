using SIS.Tech.Domain.Model;
using SIS.Tech.IApp;
using SIS.Tech.IDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.App
{
    public class SocioApp : ISocioApp
    {
        private readonly ISocioBo _socioBo;

        public SocioApp(ISocioBo socioBo)
        {
            _socioBo = socioBo;
        }

        public int AlterarSocios(Socios socios)
        {
            return _socioBo.AlterarSocios(socios);
        }

        public int ExcluirSocios(int codSocios, string quem)
        {
            return _socioBo.ExcluirSocios(codSocios, quem);
        }

        public int IncluirSocios(Socios socios)
        {
            return _socioBo.IncluirSocios(socios);
        }

        public List<Socios> ListarSocios(int codSocio, string nome, string cpf)
        {
            return _socioBo.ListarSocios(codSocio, nome, cpf);
        }

        public Socios ObterSocios(int codSocios)
        {
            return _socioBo.ObterSocios(codSocios);
        }
    }
}
