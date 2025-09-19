using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Domain.Model
{
    [Serializable]
    public class TipoPessoa
    {
        [Required(ErrorMessage = "O campo Tipo Pessoa é obrigatório.")]
        public int CodTipoPessoa { get; set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        [MaxLength(80, ErrorMessage = "Máximo 80 caracteres")]
        [MinLength(1, ErrorMessage = "Mínimo 1 caracteres")]
        public string Descricao { get; set; }

        public string Quem { get; set; }

        public List<TipoPessoa> lstTipoPessoa { get; set; }
    }
}
