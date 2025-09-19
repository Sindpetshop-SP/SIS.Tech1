using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Domain.Model
{
    [Serializable]
    public class ControleAcessoSGE
    {
        public int CodPerfil { get; set; }

        public string NmePerfil { get; set; }

        public int CodFormulario { get; set; }

        public string NmeFormulario { get; set; }

        public int CodControle { get; set; }

        public string NmeControle { get; set; }

        public bool FlgTemAcesso { get; set; }

        public string NomeUsuario { get; set; }

        public int CodUsuario { get; set; }

        public List<ControleAcessoSGE> lstControleAcessos { get; set; }
    }
}
