using System.ComponentModel.DataAnnotations;

namespace SIS.Tech.Models.Login
{
  public class LoginViewModels
  {
    [Required(ErrorMessage = "Campo obrigatório.")]
    [StringLength(6, MinimumLength = 6, ErrorMessage = "O Nome do usuário deve ter 6 caracteres.")]
    [Display(Name = "Usuário")]
    public string Usuario { get; set; }

    [Required(ErrorMessage = "Campo obrigatório.")]
    [StringLength(20, MinimumLength = 1, ErrorMessage = "A Senha deve ter entre 10 e 20 caracteres")]
    [RegularExpression(@"[a-zA-Z0-9]*", ErrorMessage = "Na senha somente são permitidos caracteres alfanuméricos")]
    [DataType(DataType.Password)]
    [Display(Name = "Senha")]
    public string Senha { get; set; }

  }
}
