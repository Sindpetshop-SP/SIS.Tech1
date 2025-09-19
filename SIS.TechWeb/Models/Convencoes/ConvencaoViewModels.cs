using SIS.Tech.Domain.Model;
using System.ComponentModel.DataAnnotations;

namespace SIS.Tech.Models.Convencoes
{
  public class ConvencaoViewModels
  {
    public int CodConvencao { get; set; }

    public TipoCCTViewModels TipoCCT { get; set; }

    public StatusCCTViewModels StatusCCT { get; set; }

    [Display(Name = "Nome Convenção")]
    [Required(ErrorMessage = "O campo é obrigatório.")]
    [RegularExpression("^[a-zA-Z0-9]_$", ErrorMessage="Não pode contain caracteres especiais")] 
    [StringLength(150, ErrorMessage = "O tamanho máximo são 150 caracteres.")]    
    public string NomeConvencao { get; set; }


    [Display(Name = "Vigência Inicial")]
    [Required(ErrorMessage = "O campo é obrigatório.")]
    [StringLength(4, ErrorMessage = "O tamanho máximo são 4 caracteres.")]
    public string AnoVigenciaInicial { get; set; }


    [Display(Name = "Vigência Final")]
    [Required(ErrorMessage = "O campo é obrigatório.")]
    [StringLength(4, ErrorMessage = "O tamanho máximo são 4 caracteres.")]
    public string AnoVigenciaFinal { get; set; }

    [Display(Name = "Observação")]
    [MaxLength(255, ErrorMessage = "Máximo 255 caracteres")]
    [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
    public string Observacao { get; set; }

    public bool CCTAssinada { get; set; }

    public bool Ativo { get; set; }

    public int TotalGeral { get; set; }

    public int TotalAssinadas { get; set; }

    public int TotalEmNegociacao { get; set; }

    public int TotalGeralEmNegociacao { get; set; }

    public int TotalEmNegociacaoPacifico { get; set; }

    public int TotalEmNegociacaoJuridico { get; set; }

    public List<Convencao> lstConvencaoModel { get; set; }
    public List<ConvencaoViewModels> lstConvencaoViewModel { get; set; }

  }
}
