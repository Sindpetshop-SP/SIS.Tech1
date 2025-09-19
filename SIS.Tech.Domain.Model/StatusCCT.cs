using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Domain.Model
{
    [Serializable]
    public class StatusCCT
    {
        public int CodStatusCCT { get; set; }
        
        [NotMapped]
        public string Descricao { get; set; }


        [NotMapped]
        public List<StatusCCT> lstStatusCCT { get; set; }

    }
}
