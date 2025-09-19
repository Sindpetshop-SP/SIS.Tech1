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
    public class Endereco
    {
        public int CodEndereco { get; set; }

        public int CodEmpresa { get; set; }

        public int CodPessoa { get; set; }

        public TipoEndereco TipoEndereco { get; set; }


        [Required(ErrorMessage = "O campo Cep é obrigatório. ")]
        [MinLength(9, ErrorMessage = "O tamanho mínimo do nome são 9 caracteres.")]
        [StringLength(9, ErrorMessage = "O tamanho máximo são 9 caracteres.")]        
        public string Cep { get; set; }


        [Required(ErrorMessage = "O campo Endereço é obrigatório. ")]
        [MinLength(10, ErrorMessage = "O tamanho mínimo do nome são 10 caracteres.")]
        [StringLength(150, ErrorMessage = "O tamanho máximo são 150 caracteres.")]        
        public string Logradouro { get; set; }


        [Required(ErrorMessage = "O campo Endereço é obrigatório. ")]
        public string Numero { get; set; }


        public string Complemento { get; set; }


        [Required(ErrorMessage = "O campo Bairro é obrigatório. ")]
        [StringLength(80, ErrorMessage = "O tamanho máximo são 80 caracteres.")]
        public string Bairro { get; set; }


        [Required(ErrorMessage = "O campo Cidade é obrigatório. ")]
        [StringLength(80, ErrorMessage = "O tamanho máximo são 80 caracteres.")]
        public string Cidade { get; set; }


        [Required(ErrorMessage = "O campo Estado é obrigatório. ")]
        [StringLength(80, ErrorMessage = "O tamanho máximo são 80 caracteres.")]
        public string Estado { get; set; }


        public string Quem { get; set; }
                

        public List<Endereco> lstEnderecos { get; set; }

    }
}
