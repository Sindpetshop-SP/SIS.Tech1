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
    public class Contabilidade
    {
        public int CodContabilidade { get; set; }

        public string Nome { get; set; }

        public string Cnpj { get; set; }

        public string Responsavel { get; set; }
        
        public DateTime DataCadastro { get; set; }

        public string Observacao { get; set; }

        public bool Ativo { get; set; }

        public string Quem { get; set; }

        public List<Contabilidade> lstContabilidade { get; set; }

    }
}
