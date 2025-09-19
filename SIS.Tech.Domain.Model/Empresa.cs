using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Domain.Model
{
    [Serializable]
    public class Empresa
    {
        public int CodEmpresa { get; set; }

        public TipoPessoa TipoPessoa { get; set; }

        public RamoAtividade RamoAtividade { get; set; }

        public Contato Contato { get; set; }

        public Endereco Endereco { get; set; }

        public Funcionario Funcionario { get; set; }

        public Socios Socio { get; set; }

        public string Cnpj { get; set; }

        public string RazaoSocial { get; set; }

        public string NomeFantasia { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataAbertura { get; set; }

        public string InscricaoEstadual { get; set; }

        public string InscricaoMunicipal { get; set; }

        public bool Sindicalizada { get; set; }

        public bool EhMatrizFilial { get; set; }

        public int QuantidadeFUncionarios { get; set; }

        public decimal 		ValorTotalFolha				 { get; set; }

        public decimal CapitalSocial { get; set; }

        public string Observacao { get; set; }
        
        public bool Ativo { get; set; }

        public string Quem { get; set; }

        public List<Empresa> lstEmpresa { get; set; }
    }
}
