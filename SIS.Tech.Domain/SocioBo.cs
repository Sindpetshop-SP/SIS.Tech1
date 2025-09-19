using SIS.Tech.Domain.Model;
using SIS.Tech.IDomain;
using SIS.Tech.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Domain
{
    public class SocioBo : ISocioBo
    {
        private readonly ISocioRepository _socioRepository;

        public SocioBo(ISocioRepository socioRepository)
        {
            _socioRepository = socioRepository;
        } 
        public int AlterarSocios(Socios socios)
        {
            return _socioRepository.AlterarSocios(socios);
        }

        public int ExcluirSocios(int codSocios, string quem)
        {
            return _socioRepository.ExcluirSocios(codSocios, quem);
        }

        public int IncluirSocios(Socios socios)
        {
            return _socioRepository.IncluirSocios(socios);
        }

        public List<Socios> ListarSocios(int codSocio, string nome, string cpf)
        {
            return _socioRepository.ListarSocios(codSocio, nome, cpf);
        }

        public Socios ObterSocios(int codSocios)
        {
            return _socioRepository.ObterSocios(codSocios);
        }
    }
}
