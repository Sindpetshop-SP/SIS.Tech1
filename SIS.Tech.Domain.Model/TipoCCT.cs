using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Domain.Model
{
    [Serializable]
    public class TipoCCT
    {
        public int CodTipoCCT { get; set; }

        [NotMapped]
        public string Descricao { get; set; }

        [NotMapped]
        public List<TipoCCT> lstTipoCCT { get; set; }

    }
}
