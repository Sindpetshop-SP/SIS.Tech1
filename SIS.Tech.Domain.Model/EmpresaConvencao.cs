using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Domain.Model
{
    [Serializable]
    public class EmpresaConvencao
    {
        public int CodEmpresa { get; set; }

        public int CodConvencao { get; set; }

        public string Quem { get; set; }

        public List<EmpresaConvencao> lstEmpresaConvencao { get; set; }
    }
}
