using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Domain.Model
{
    [Serializable]
    public class EmpresaSocios
    {
        public int CodEmpresa { get; set; }

        public int CodSocios { get; set; }
 
        public string Quem { get; set; }

        public List<EmpresaSocios> lstEmpresaSocios { get; set; }
    }
}
