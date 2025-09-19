using SIS.Tech.Domain.Model;
using System.ComponentModel.DataAnnotations;

namespace SIS.Tech.Models.User
{
  public class AlterarSenhaViewModels
  {
      public int CodUsuario { get; set; }

      [Required(ErrorMessage = "Campo obrigatório.")]
      [StringLength(20, MinimumLength = 8, ErrorMessage = "A Senha deve ter entre 8 e 20 caracteres")]
      [RegularExpression(@"(?=^.{8,}$)((?=.*\d)(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "<ul style=\"text-align:left; font-size:10px; color:red;\">\r\n <div style=\"font-size:12px;\">A Senha deve conter:</div> \r\n <li>8 caracteres no mínimo</li>\r\n                        <li>1 Letra Maiúscula no mínimo</li>\r\n                        <li>1 Número no mínimo</li>\r\n                        <li>1 Símbolo no mínimo: $*&#...</li>\r\n                        <li>Não permitir sequência igual</li>\r\n                    </ul>")]
      [DataType(DataType.Password)]
      [Display(Name = "Senha")]
      public string newPassword { get; set; }

      [Required(ErrorMessage = "Campo obrigatório.")]
      [StringLength(20, MinimumLength = 8, ErrorMessage = "A Senha deve ter entre 8 e 20 caracteres")]
      [Display(Name = "Confirme a Senha")]
      [Compare("newPassword", ErrorMessage = "A senha e a senha de confirmação não coincidem.")]
      public string confirmPassword { get; set; }

  }
}
