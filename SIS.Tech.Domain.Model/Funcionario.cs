using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Domain.Model
{
    [Serializable]
    public class Funcionario
    {
        public int CodFuncionario { get; set; }

        public TipoPessoa TipoPessoa { get; set; }

        public Empresa Empresa { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public int Idade { get; set; }

        public int Sexo { get; set; }

        public DateTime DataCadastro { get; set; }

        public bool Sindicalizado { get; set; }

        public  string Observacao { get; set; }
                
        public bool Ativo { get; set; }

        public string  Quem{ get; set; }

        public List<Funcionario> lstFuncionarios { get; set; }
    }
}

