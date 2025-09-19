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
    public class TipoContato 
    {
        [Required(ErrorMessage = "O campo Tipo do Contato é obrigatório. ")]
        public int CodTipoContato { get; set; }


        [MaxLength(80, ErrorMessage = "Máximo 80 caracteres")]
        [MinLength(1, ErrorMessage = "Mínimo 1 caracteres")]
        public string Descricao { get; set; }

        public string Quem { get; set; }

        public List<TipoContato> lstTipoContatos { get; set; }


    }
}
