using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Domain.Model
{
    [Serializable]
    public class Socios
    {
        public int CodSocio { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Observacao { get; set; }

        public bool Ativo { get; set; }

        public string Quem { get; set; }

        public List<Socios> lstSocios { get; set; }

    }
}
