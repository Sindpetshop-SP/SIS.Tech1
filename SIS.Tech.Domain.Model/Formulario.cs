using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Domain.Model
{
    [Serializable]
    public class Formulario
    {
        public int CodFormulario { get; set; }

        public string NmeFormulario { get; set; }

        public Controle Controle { get; set; }
    }
}

