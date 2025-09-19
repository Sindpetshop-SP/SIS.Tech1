using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Domain.Model
{
    [Serializable]
    public class PessoaCategoria
    {
        [Display(Name = "Categoria da Pessoa")]
        [Required(ErrorMessage = "Categoria da Pessoa")]
        public int CodPessoaCategoria { get; set; }


        [Required(ErrorMessage = "O campo Descrição é obrigatório.  ")]
        [MaxLength(80, ErrorMessage = "Máximo 80 caracteres")]
        [MinLength(1, ErrorMessage = "Mínimo 1 caracteres")]
        public string Descricao { get; set; }


        [MaxLength(3, ErrorMessage = "Máximo 3 caracteres")]
        [MinLength(3, ErrorMessage = "Mínimo 3 caracteres")]
        public string Sigla { get; set; }

        public string Quem { get; set; }

        public List<PessoaCategoria> lstPessoaCategorias { get; set; }
    }
}
