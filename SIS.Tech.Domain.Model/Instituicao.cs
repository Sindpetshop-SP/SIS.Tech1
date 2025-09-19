using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Domain.Model
{
     [Serializable]
    public class Instituicao
    {
        [Required(ErrorMessage = "O campo é obrigatório. ")]
        public int CodInstituicao { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório. ")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres")]
        [MinLength(3, ErrorMessage = "Mínimo 3 caracteres")]
        public string Descricao { get; set; }

        public string Quem { get; set; }

        public IEnumerable<Instituicao> lstInstituicoes { get; set; }
    }
}
