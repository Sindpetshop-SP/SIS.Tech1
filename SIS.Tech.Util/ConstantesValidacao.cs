using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Util
{
    public class ConstantesValidacao
    {
        public const string CaracteresNaoPermitidos = "-+.;:|<>°º\\]}~^{[ª´`=()*&%$#@!¬§?\\\\£¢¹²";
        public const string CaracteresNãoPermitidosNome = "-+;:|<>°º\\]}~^{[ª´`=()*&%$#@!¬§?\\\\ £¢¹²";
        public const string CaracteresPermitidos = "-+.;:|<>°º\\]}~^{[ª´`=()*&%$#@!¬§?\\\\ £¢¹²";
        public const string CelNoveDigitos = "([(])(([1,9,8][1-9])|([2][1,2,4,7,8]))([)])9[4-9][0-9]{3}[-][0-9]{4}";
        public const string CelOitoDigitos = "^[(]([3-7][1-9])[)][4-9][0-9]{3}-[0-9]{4}";
        public const string Cep = "^[0-9]{5}[-][0-9]{3}$";
        public const string Cidade = "^(?=.*[A-Za-z])(?!.*(.)\\1\\1)[a-zA-ZéúçÇíóáÉÚÍÓÁèùìòàÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËY'ÜÏÖÄ0-9-/. ]{3,150}$";
        public const string Data = "^([0-3]{1}[0-9]{1}\\/[0-1]{1}[0-9]{1}\\/[1-9]{1}[0-9]{3})$";
        public const string Email = "^[a-z0-9._-]{1,}[@][a-z0-9._-]{1,}[.][a-z0-9._-]{2,5}([.][a-z0-9]{1,4})?$";
        public const string Endereco = "^(?=.*[A-Za-z])(?!.*(.)\\1\\1)[a-zA-ZéúçÇíóáÉÚÍÓÁèùìòàÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËY'ÜÏÖÄ0-9\\+\\;\\,\\:<>°º\\/\\\\ª=\\*&%$#@\\!§\\?£¢¹² -]{3,150}$";
        public const string IdNextel = "^(?=.*[*])(?!.*([*])\\1)([0-9]{1,10}[*][0-9*]+?)$";
        public const string NextelRegex = "(^[(][1][1][)][7]([7-9]|[0])[0-9]{2}-[0-9]{4}$)|(^[(](([1-2][2-9])|([2][1]))[)][7][7-9][0-9]{2}-[0-9]{4}$)";
        public const string Nome = "^(?=.*[A-Za-z])(?!.*(.)\\1\\1)[a-zA-ZéúçÇíóáÉÚÍÓÁèùìòàÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËY'ÜÏÖÄ ]{3,150}$";
        public const string QualquerCelular = "(([(])(([1,9,8][1-9])|([2][1,2,4,7,8]))([)])9[4-9][0-9]{3}[-][0-9]{4})|(^[(]([3-7][1-9])[)][4-9][0-9]{3}-[0-9]{4})|((^[(][1][1][)][7]([7-9]|[0])[0-9]{2}-[0-9]{4}$)|(^[(](([1-2][2-9])|([2][1]))[)][7][7-9][0-9]{2}-[0-9]{4}$))";
        public const string QualquerTelefone = "((([(])(([1,9,8][1-9])|([2][1,2,4,7,8]))([)])9[4-9][0-9]{3}[-][0-9]{4})|(^[(]([3-7][1-9])[)][4-9][0-9]{3}-[0-9]{4})|((^[(][1][1][)][7]([7-9]|[0])[0-9]{2}-[0-9]{4}$)|(^[(](([1-2][2-9])|([2][1]))[)][7][7-9][0-9]{2}-[0-9]{4}$)))|(^[(]([1-9]{2})[)]([2-5][0-9]{3}-[0-9]{4})$)";
        public const string RazaoSocial = "^(?=.*[A-Za-z])(?!.*(.)\\1\\1)[a-zA-ZéçÇúíóáÉÚÍÓÁèùìòàÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËY'ÜÏÖÄ0-9\\+\\;\\:<>°º\\/\\\\ª=\\*&%$#@\\!§\\?£¢¹² -]{3,150}$";
        public const string Senha = "^(?=.*[A-Za-z])(?=.*\\d)(?!.*(.)\\1\\1)[A-Za-z0-9]{6,10}$";
        public const string SenhaOutra = "^(?=.*[A-Za-z])(?!.*([.])\\1\\1)[a-zA-Z0-9@ $%]{6,10}$";
        public const string Sexo = "^(Feminino)$|^(Masculino)$|^(FEMININO)$|^(MASCULINO)$";
        public const string SexoSigla = "^[F|M]$";
        public const string TagsHtml = "<(?:.|\\n)*?>";
        public const string TelefoneRegex = "^[(]([1-9]{2})[)]([2-5][0-9]{3}-[0-9]{4})$";
        public const string TipoDestinatario = "(^(TO)$)|(^(CCO)$)|(^(CC)$)$";
        public static readonly string[] Lista;

        public const string tipoDestinatario = @"(^(TO)$)|(^(CCO)$)|(^(CC)$)$";
        public const string sexoSigla = @"^[F|M]$";
        public const string sexo = @"^(Feminino)$|^(Masculino)$|^(FEMININO)$|^(MASCULINO)$";
    }
}
