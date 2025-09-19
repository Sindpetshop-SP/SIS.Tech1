using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Domain.Model
{
  [Serializable]
  public class Departamento
  {
    [Display(Name = "Departamento")]
    [Required(ErrorMessage = "O campo é obrigatório.")]
    public int CodDepartamento { get; set; }

    public string Descricao { get; set; }

    public List<Departamento> lstDepartamentos { get; set; }
  }
}
