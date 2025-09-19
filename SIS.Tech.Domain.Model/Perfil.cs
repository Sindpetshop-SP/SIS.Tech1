using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Domain.Model
{
  [Serializable]
  public class Perfil
  {
    public int CodPerfil { get; set; }

    public string NmePerfil { get; set; }

    public List<Perfil> lstPerfis { get; set; }

  }
}
