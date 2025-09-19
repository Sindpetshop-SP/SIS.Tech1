using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Domain.Model
{
    [Serializable]
    public class ContaTipo
    {
        [Required(ErrorMessage = "O campo é obrigatório. ")]
        public int CodContaTipo { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório. ")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres")]
        [MinLength(5, ErrorMessage = "Mínimo 5 caracteres")]
        public string Descricao { get; set; }

        public string Quem { get; set; }

        public List<ContaTipo> lstContaTipos { get; set; }

    }
}
