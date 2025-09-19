using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Domain.Model
{
    [Serializable]
    public class Banco
    {
        [Required(ErrorMessage = "O campo é obrigatório. ")]
        public int CodBanco { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório. ")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres")]
        [MinLength(1, ErrorMessage = "Mínimo 1 caracteres")]
        public string NumeroBanco { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório. ")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres")]
        [MinLength(5, ErrorMessage = "Mínimo 5 caracteres")]
        public string NomeBanco { get; set; }


        public string Quem { get; set; }

        public List<Banco> lstBancos { get; set; }

    }
}
