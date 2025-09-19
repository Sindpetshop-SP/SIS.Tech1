using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Domain.Model
{
    [Serializable]
    public class Roles
    {
        public int CodRoles { get; set; }

        public int CodPerfil { get; set; }

        public string NmePerfil { get; set; }

        public int CodUsuario { get; set; }

        public string NmeUsuario { get; set; }

        public int QtdeUsuario { get; set; }

        public int QtdeControlesAtivos { get; set; }
                
        public List<Roles> lstRoles { get; set; }
    }
}
