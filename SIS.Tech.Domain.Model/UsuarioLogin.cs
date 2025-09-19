using System.ComponentModel.DataAnnotations;

namespace SIS.Tech.Domain.Model
{
    [Serializable]
    public class UsuarioLogin
    {
        [Display(Name = "Código Usuário")]
        public int CodUsuario { get; set; }


        [Display(Name = "Código Sistema")]
        public int CodSistema { get; set; }

        public Departamento Departamento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "O nome deve ter entre 10 e 50 caracteres")]
        public string NmeUsuario { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "A Senha deve ter entre 8 e 20 caracteres")]
        [RegularExpression(@"(?=^.{8,}$)((?=.*\d)(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "<ul style=\"text-align:left; font-size:10px; color:red;\">\r\n <div style=\"font-size:12px;\">A Senha deve conter:</div> \r\n <li>8 caracteres no mínimo</li>\r\n                        <li>1 Letra Maiúscula no mínimo</li>\r\n                        <li>1 Número no mínimo</li>\r\n                        <li>1 Símbolo no mínimo: $*&#...</li>\r\n                        <li>Não permitir sequência igual</li>\r\n                    </ul>")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string VlrSenhaUsuario { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "A Senha deve ter entre 8 e 20 caracteres")]
        [Display(Name = "Confirme a Senha")]
        [Compare("VlrSenhaUsuario", ErrorMessage = "A senha e a senha de confirmação não coincidem.")]
        public string ConfirmSenha { get; set; }

        public int FlgAtivo { get; set; }

        [Required(ErrorMessage = "O campo obrigatório. ")]
        [StringLength(18, ErrorMessage = "O tamanho máximo são 14 caracteres.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo E-mail é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "E-mail em formato inválido")]
        public string Email { get; set; }

        public string NmeLoginUsuario { get; set; }

        public string SitSenha { get; set; }

        public string senhaCryptoNew { get; set; }

        public Boolean terms { get; set; }

        public Boolean Ativo { get; set; }

        public UserTotalizadores UserTotalizadores { get; set; }

        public List<UsuarioLogin> lstUsuariosLogin { get; set; }
    }
}
