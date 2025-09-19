using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Domain.Model
{
    [Serializable]
    public class UserTotalizadores
    {
        public int TotalGeral { get; set; }
        public int TotalAtivo { get; set; }
        public int TotalInativo { get; set; }
        public int TotalBloqueado { get; set; }
    }
}
