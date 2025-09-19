using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Domain.Model
{    
    [Serializable]
    public class RamoAtividade
    {
        [Required(ErrorMessage = "O campo Ramo de Atividade é obrigatório. ")]
        public int CodRamoAtividade { get; set; }

        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres")]
        [MinLength(1, ErrorMessage = "Mínimo 1 caracteres")]
        public string Descricao { get; set; }

        public string Quem { get; set; }

        public List<RamoAtividade> lstRamoAtividades { get; set; }
    }
}
