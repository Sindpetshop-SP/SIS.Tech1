using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Domain.Model
{
    [Serializable]
    public class EmpresaCnae
    {
        public int CodEmpresa { get; set; }

        public int CodCnae { get; set; }

        public bool Primario { get; set; }

        public bool Secundario { get; set; }

        public string Quem { get; set; }

        public List<EmpresaCnae> lstEmpresaCnae { get; set; }
    }
}
