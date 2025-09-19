using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using SIS.ControleAcesso.Model;
using SIS.Tech.Models.Login;

namespace SIS.Tech.Controllers.System
{
    public class BaseController : Controller
    {

        #region Constutores

        public BaseController()
        {

        }

        #endregion Construtores

        #region Propriedade UsuarioLogado

        internal UsuarioSistemaPerfilInfo UsuarioLogado
        {
            get
            {
                if (GetSessionUser != null)
                {
                    var user = GetSessionUser();

                    return (UsuarioSistemaPerfilInfo)user;
                }

                return null;
            }
            set
            {
                SetSessionUser(value);
                //Session[SessoesViewModels.Logado] = value;
                //Session[SessoesViewModels.Usuario] = value.mUsuario.nmeUsuario;
            }
        }

        #endregion Propriedade UsuarioLogado

        #region Método VerificaSession

        public IActionResult SetSessionUser(object sessionValue)
        {
            HttpContext.Session.LoadAsync();

            HttpContext.Session.SetString(SessoesViewModels.Logado, JsonConvert.SerializeObject(sessionValue));

            return Ok();
        }

        public UsuarioSistemaPerfilInfo GetSessionUser()
        {
            HttpContext.Session.LoadAsync();

            var sessionUser = JsonConvert.DeserializeObject<UsuarioSistemaPerfilInfo>(HttpContext.Session.GetString(SessoesViewModels.Logado));

            return sessionUser;
        }


        internal bool VerificaSession()
        {
            if (HttpContext.Session.GetString(SessoesViewModels.Logado) == null)
                return false;

            if (UsuarioLogado == null)
                return false;

            var usuario = UsuarioLogado;

            return string.IsNullOrEmpty(usuario.mUsuario.msgErro);

        }

        internal bool ClienteEstaAutenticado()
        {
            if (HttpContext.Session.GetString(SessoesViewModels.Logado) != null)
            {
                var sessionUser = JsonConvert.DeserializeObject<UsuarioSistemaPerfilInfo>(HttpContext.Session.GetString(SessoesViewModels.Logado));

                if (string.IsNullOrEmpty(sessionUser.mUsuario.msgErro))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion Método VerificaSession

        #region Método VerificarPermissaoControle

        public bool VerificarPermissaoControle(string nomeFormulario, string nomeControle)
        {
            bool retorno = false;

            if (GetSessionUser() != null)
            {
                //var usuario = (UsuarioSistemaPerfilInfo)Session[SessoesViewModels.Logado];

                //if (usuario.mUsuario.mControle.FirstOrDefault(x => x.mFormulario.nmeFormulario.Equals(nomeFormulario) && x.mControle.nmeControle.Equals(nomeControle)) != null)
                //    retorno = true;

                var sessionUser = JsonConvert.DeserializeObject<UsuarioSistemaPerfilInfo>(HttpContext.Session.GetString(SessoesViewModels.Logado));

                if (string.IsNullOrEmpty(sessionUser.mUsuario.msgErro))
                {

                    if (!string.IsNullOrEmpty(nomeFormulario))
                    {
                        if (sessionUser.mUsuario.mControle.FirstOrDefault(x => x.mFormulario.nmeFormulario.Equals(nomeFormulario) && x.mControle.nmeControle.Equals(nomeControle)) != null)
                            retorno = true;
                    }
                    else
                    {
                        if (sessionUser.mUsuario.mControle.FirstOrDefault(x => x.mControle.nmeControle.Equals(nomeControle)) != null)

                            retorno = true;
                    }

                    return true;
                }
                else
                    retorno = false;



                //if (((SIS.ControleAcesso.Model.UsuarioSistemaPerfilInfo)Session[SessoesViewModels.Logado]).mUsuario.msgErro == null)
                //{
                //  var usuario = (UsuarioSistemaPerfilInfo)Session[SessoesViewModels.Logado];

                //  if (!string.IsNullOrEmpty(nomeFormulario))
                //  {
                //    if (usuario.mUsuario.mControle.FirstOrDefault(x => x.mFormulario.nmeFormulario.Equals(nomeFormulario) && x.mControle.nmeControle.Equals(nomeControle)) != null)
                //      retorno = true;
                //  }
                //  else
                //  {
                //    if (usuario.mUsuario.mControle.FirstOrDefault(x => x.mControle.nmeControle.Equals(nomeControle)) != null)

                //      retorno = true;
                //  }
                //}
                //else
                //  retorno = false;
            }

            return retorno;
        }

        #endregion Método VerificarPermissaoControle
    }
}
