using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Domain.Model
{
    [Serializable]
    public class ContabilidadeContato
    {
        public int CodContabilidade  { get; set; }

        public int CodContato { get; set; }
         
        public string Quem { get; set; }

        public List<ContabilidadeContato> lstContabilidadeContato { get; set; }
    }
}
