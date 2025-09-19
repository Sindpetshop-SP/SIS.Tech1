using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Domain.Model
{
    [Serializable]
    public class Permissions
    {

        public int CodSistema { get; set; }

        public int CodUsuario { get; set; }

        public string NmeUsuario { get; set; }

        public string NroCnpjCpf { get; set; }

        public string DscEmail { get; set; }

        public bool FlgAtivo { get; set; }

        public int CodDepartamento { get; set; }

        public string NmeDepto { get; set; }

        public int CodFormulario { get; set; }

        public string NmeFormulario { get; set; }

        public int CodControle { get; set; }

        public string NmeControle { get; set; }

        public bool FlgTemAcesso { get; set; }

        public int CodPerfil { get; set; }

        public string NmePerfil { get; set; }

        public List<Permissions> lstPermissions { get; set; }
    }
}
