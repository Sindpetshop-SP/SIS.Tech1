using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Domain.Model
{
    [Serializable]
    public class EmpresaContabilidade
    {
        public int CodEmpresa { get; set; }

        public int CodContabilidade { get; set; }

        public string Quem { get; set; }

        public List<EmpresaContabilidade> lstEmpresaContabilidade { get; set; }
    }
}
