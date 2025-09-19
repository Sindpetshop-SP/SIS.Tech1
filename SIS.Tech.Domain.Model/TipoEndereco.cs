using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Domain.Model
{
    [Serializable]
    public class TipoEndereco
    {
        [Required(ErrorMessage = "O campo Tipo de Endereço é obrigatório. ")]
        public int CodTipoEndereco { get; set; }


        [MaxLength(80, ErrorMessage = "Máximo 80 caracteres")]
        [MinLength(1, ErrorMessage = "Mínimo 1 caracteres")]
        public string Descricao { get; set; }

        public string Quem { get; set; }

        public List<TipoEndereco> lstTipoEndereco { get; set; }        
    }
}
