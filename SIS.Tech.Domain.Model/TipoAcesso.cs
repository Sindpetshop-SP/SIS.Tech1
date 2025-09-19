using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Domain.Model
{
    public enum TipoAcesso
    {
        NenhumAcesso = 0,
        Consulta = 1,
        Inclusao = 2,
        Alteracao = 3,
        Exclusao = 4,
        Total = 5
    }
}