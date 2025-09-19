using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Domain.Model
{
    [Serializable]
    public class SenhaBanco
    {
        public int CodSenhaBanco { get; set; }

        public Instituicao Instituicao { get; set; }

        public Banco Banco { get; set; }

        public ContaTipo ContaTipo { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório. ")]
        [MaxLength(80, ErrorMessage = "Máximo 80 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        public string NumAgencia { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório. ")]
        [MaxLength(80, ErrorMessage = "Máximo 80 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        public string NumConta { get; set; }


        [Required(ErrorMessage = "O campo é obrigatório. ")]
        [StringLength(14, ErrorMessage = "O tamanho máximo são 14 caracteres.")]
        public string CpfTitular { get; set; }

        
        [Required(ErrorMessage = "O campo é obrigatório. ")]
        public string SenhaEletronica { get; set; }

        [MaxLength(255, ErrorMessage = "Máximo 255 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        public string Observacao { get; set; }

        public bool Ativo { get; set; }

        public string Quem { get; set; }

        public List<SenhaBanco> lstSenhaBancos { get; set; }


    }
}
