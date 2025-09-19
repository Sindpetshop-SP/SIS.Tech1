using SIS.Tech.Domain.Model;
using SISFramework.Validacao;

namespace SIS.Tech.Models.Empresas
{
  public class InsertEditViewModel
  {
    public int CodEmpresa { get; set; }

    public RamoAtividade RamoAtividade { get; set; }

    [ValidaCnpj(ErrorMessage = "CNPJ inválido.")]
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

    public decimal ValorTotalFolha { get; set; }

    public decimal CapitalSocial { get; set; }

    public string Observacao { get; set; }

    public bool Ativo { get; set; }

  }
}
