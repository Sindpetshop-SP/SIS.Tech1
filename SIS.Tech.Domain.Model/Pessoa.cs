using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Domain.Model
{

    [Serializable]
    public class Pessoa
    {
        [Required]
        [Display(Name = "Pessoa")]
        public int CodPessoa { get; set; }

        public PessoaCategoria PessoaCategoria { get; set; }

        //Sempre Fisica Juridica
        public TipoPessoa TipoPessoa { get; set; }

        public Contato Contato { get; set; }

        public Endereco Endereco { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório. ")]
        [MaxLength(150, ErrorMessage = "Máximo 150 caracteres")]
        [MinLength(5, ErrorMessage = "Mínimo 5 caracteres")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "O campo Cpf é obrigatório. ")]
        [StringLength(14, ErrorMessage = "O tamanho máximo são 14 caracteres.")]
        public string Cpf { get; set; }


        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "E-mail em formato inválido")]
        public string Email { get; set; }
        
        
        [MaxLength(255, ErrorMessage = "Máximo 255 caracteres")]
        [MinLength(5, ErrorMessage = "Mínimo 5 caracteres")]
        public string Observacao { get; set; }

        public bool Ativo { get; set; }

        public string Quem { get; set; }

        public List<Pessoa> lstPessoas { get; set; }
    }
}
