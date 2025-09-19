using SISFramework.Validacao;
using System.ComponentModel.DataAnnotations;

namespace SIS.Tech.Models.Login
{
  public class UsuarioViewModels
  {
    [MaxLength(150, ErrorMessage = "Nome - Tamanho superior a 150")]
    [Required(ErrorMessage = "Nome - Campo obrigatório.")]
    [RegularExpression(RegexValidacao.ConstantesValidacao.Nome)]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Cpf - Campo obrigatório.")]
    [RegularExpression("[0-9]{3}[.][0-9]{3}[.][0-9]{3}[-][0-9]{2}", ErrorMessage = "Cpf com formato inválido.")]
    [StringLength(14, ErrorMessage = "Cpf - Tamanho deve ser 14.")]
    [ValidaCpf(ErrorMessage = "Cpf inválido.")]
    public string Cpf { get; set; }

    [Required(ErrorMessage = "E-mail - Campo obrigatório.")]
    [MaxLength(150, ErrorMessage = "E-mail - Tamanho superior a 150.")]
    [RegularExpression(RegexValidacao.ConstantesValidacao.Email)]
    public string Email { get; set; }

  }
}
