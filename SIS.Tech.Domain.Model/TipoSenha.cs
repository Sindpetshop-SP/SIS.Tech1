using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Domain.Model
{
    [Serializable]
    public class TipoSenha
    {
        public int CodTipoSenha { get; set; }
        
        public string Descricao { get; set; }

        public string Quem { get; set; }

        public List<TipoSenha> lstTipoSenha { get; set; }

    }
}
