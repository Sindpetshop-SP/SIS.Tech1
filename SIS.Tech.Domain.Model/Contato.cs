using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Domain.Model
{
    [Serializable]
    public class Contato
    {
        public int CodContato { get; set; }

        public int CodEmpresa { get; set; }

        public int CodPessoa { get; set; }

        public TipoContato TipoContato { get; set; }

        public string Ddd { get; set; }

        [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
        [StringLength(15, ErrorMessage = "O tamanho máximo são 15 caracteres.")]        
        public string Telefone { get; set; }
        
        [Required(ErrorMessage = "O campo E-mail é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "E-mail em formato inválido")]        
        public string Email { get; set; }

        public string Quem { get; set; }

        public List<Contato> lstContatos { get; set; }

    }
}
