using SIS.Tech.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.IRepository
{
    public interface ISocioRepository
    {
        int IncluirSocios(Socios Socios);

        int AlterarSocios(Socios Socios);

        int ExcluirSocios(int codSocios, string quem);

        List<Socios> ListarSocios(int codSocio, string nome, string cpf);

        Socios ObterSocios(int codSocios);

    }
}
