using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SIS.ControleAcesso.Model;
using SIS.Tech.App;
using SIS.Tech.Domain.Model;
using SIS.Tech.IApp;
using SIS.Tech.IServices;
using SIS.Tech.Models;
using SIS.Tech.Models.Login;
using SISFramework.Parameter.DerivedParameter;
using SISFramework.Security.Criptografia;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Controllers.System
{
    public class AuthController : BaseController
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IControleAcesso _iControleAcesso;
        private readonly IUsuarioApp _usuarioApp;
        private readonly ILoginApp _loginApp;
        private readonly IMailApp _mailApp;

        public AuthController(ILogger<AuthController> logger, IControleAcesso iControleAcesso, ILoginApp loginApp, IMailApp mailApp, IUsuarioApp usuarioApp)
        {
            _logger = logger;
            _iControleAcesso = iControleAcesso;
            _loginApp = loginApp;
            _mailApp = mailApp;
            _usuarioApp = usuarioApp;
        }

        #region Login

        [HttpGet]
        public IActionResult Login()
        {


            var login = new LoginViewModels();

            return View(login);
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        //[OutputCache(NoStore = true, Duration = 0, VaryByParam = "*", Location = OutputCacheLocation.None)]
        public async Task<ActionResult> EfetuarLogin(LoginViewModels login)
        {


            try
            {
                if (ModelState.IsValid)
                {
                    var codSistema = new LocalMachine().LerParametro("SINDPETSHOP", "Configuracoes", "CodSistema").Valor;
                    //var codSistema = ConfigurationManager.AppSettings["CodSistema"].ToString();

                    var usuario = _iControleAcesso.LoginUsuario(int.Parse(codSistema), login.Usuario, login.Senha, string.Empty);

                    if (usuario == null)
                    {
                        TempData["MSG"] = "warning|Verifique seu usuário e senha!";

                        return RedirectToAction("Login", "Auth");
                    }
                    else
                    {
                        UsuarioLogado = await usuario;

                        if (UsuarioLogado != null)
                        {
                            if (!string.IsNullOrEmpty(UsuarioLogado.mUsuario.msgErro))
                            {
                                TempData["MSG"] = "warning|" + UsuarioLogado.mUsuario.msgErro;

                                return RedirectToAction("Login", "Auth");
                            }
                        }
                    }

                }
                else
                {
                    TempData["MSG"] = "info|Favor digitar usuário e senha!";

                    return RedirectToAction("Login", "Auth");
                }

                // If we got this far, something failed, redisplay form
                return RedirectToAction("Index", "Home");

            }
            catch (Exception ex)
            {
                //Log.GravaLog(string.Empty, GetClientIp(), Types.Aplicativo.DaycambioWeb, Types.TipoLog.Erro, Types.TipoDescricaoLog.Html, "DayCambio.Mvc.Web.Core - Login Controller", "WEB", string.Empty, ex.ToString());
                return RedirectToAction("ErroLogin");

            }

        }


        #endregion

        #region Esqueceu Senha

        [HttpGet]
        public IActionResult ForgotPassword()
        {


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(ForgotPasswordViewModels model)
        {


            var codSistema = new LocalMachine().LerParametro("SINDPETSHOP", "Configuracoes", "CodSistema").Valor;

            try
            {
                if (String.IsNullOrEmpty(model.Email))
                {
                    TempData["MSG"] = "warning|Favor informar o e-mail de cadastro!";
                }
                else
                {
                    string mailFrom = "daniel.ti@sindpetshop.org.br";
                    string subjectMail = "Seu recebeu o código para redefinir sua senha!";
                    string tipoMail = "bodyForgotPassword";

                    string codForamtado = _loginApp.GeraCodigoParaEsqueceuSenha(model.Email);

                    string nomeUsuario = _usuarioApp.ObterNomeUsuario(model.Email);

                    _mailApp.sendMail(mailFrom, model.Email, subjectMail, tipoMail, codForamtado, nomeUsuario, string.Empty, string.Empty);

                    TempData["MSG"] = "info|Favor verificar seu e-mail corporativo!";

                    return RedirectToAction("Login", "Auth");

                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "error|Registro com Erro, favor ligar para o Helpdesk";
            }

            return RedirectToAction("Login", "Auth");

        }

        public IActionResult TwoStepsCover()
        {


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TwoStepsCover(TwoStepsCoverViewModels model)
        {
            try
            {


                if (String.IsNullOrEmpty(model.codigo1) || String.IsNullOrEmpty(model.codigo2) || String.IsNullOrEmpty(model.codigo3) || String.IsNullOrEmpty(model.codigo4)
                  || String.IsNullOrEmpty(model.codigo5) || String.IsNullOrEmpty(model.codigo6))
                {
                    TempData["MSG"] = "warning|Favor informar o código completo!";
                }
                else
                {
                    //string codigo1 = model.codigo1;
                    //string codigo2 = model.codigo2;
                    //string codigo3 = model.codigo3;
                    //string codigo4 = model.codigo4;
                    //string codigo5 = model.codigo5;
                    //string codigo6 = model.codigo6;

                    string codForamtado = model.codigo1 + " - " + model.codigo2 + " - " + model.codigo3 + " - " + model.codigo4 + " - " + model.codigo5 + " - " + model.codigo6;

                    UsuarioLogin usuario = _loginApp.ValidaCodigoParaEsqueceuSenha(codForamtado);

                    if (usuario.CodUsuario > 0)
                    {
                        TempData["MSG"] = "info|Favor verificar seu e-mail corporativo com a nova senha!";

                        string mailFrom = "daniel.ti@sindpetshop.org.br";
                        string subjectMail = "Senha temporária";
                        string tipoMail = "bodyConfirmForgotPassword";

                        _mailApp.sendMail(mailFrom, usuario.Email, subjectMail, tipoMail, codForamtado, usuario.NmeUsuario, usuario.senhaCryptoNew, string.Empty);
                    }
                    else
                        TempData["MSG"] = "error|Código não validado, favor repetir o processo!";

                    return RedirectToAction("Login", "Auth");

                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "error|Registro com Erro, favor ligar para o Helpdesk";
            }

            return RedirectToAction("Login", "Auth");
        }

        #endregion

        #region Logoff

        [HttpGet]
        [AllowAnonymous]
        //[OutputCache(NoStore = true, Duration = 0, VaryByParam = "*", Location = OutputCacheLocation.None)]
        public ActionResult EfetuarLogoff()
        {


            if (VerificaSession())
            {
                SetSessionUser(null);
            }

            return RedirectToAction("Login", "Auth");
        }

        #endregion

        #region Registro

        [HttpGet]
        public IActionResult RegisterCover()
        {


            CarregarCombos();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterCover(RegistroViewModels model)
        {


            try
            {
                TempData["Registro"] = model;

                if (model.CodDepartamento != 0 && !String.IsNullOrEmpty(model.NomeUsuario) && !String.IsNullOrEmpty(model.Cpf) && !String.IsNullOrEmpty(model.VlrSenhaUsuario) && !String.IsNullOrEmpty(model.Email))
                {

                    var codSistema = new LocalMachine().LerParametro("SINDPETSHOP", "Configuracoes", "CodSistema").Valor;

                    model.CodSistema = Convert.ToInt32(codSistema);

                    if (!String.IsNullOrEmpty(model.Cpf))
                    {
                        if (SIS.Tech.Util.FuncaoHelper.ValidarCpf(model.Cpf))
                        {
                            var senhaCrypto = SISFramework.Security.Criptografia.Helper.Criptografar(model.VlrSenhaUsuario, SISFramework.Security.Criptografia.EncryptAlgorithm.EncryptionAlgorithm.Rijndael);

                            model.VlrSenhaUsuario = senhaCrypto;

                            UsuarioLogin user = new UsuarioLogin();
                            user.Departamento = new Departamento();

                            user.CodSistema = model.CodSistema;
                            user.Departamento.CodDepartamento = model.CodDepartamento;
                            user.NmeUsuario = model.NomeUsuario;
                            user.Cpf = model.Cpf;
                            user.Email = model.Email;
                            user.VlrSenhaUsuario = model.VlrSenhaUsuario;

                            var retorno = _loginApp.InserirLoginUsuario(user);

                            if (retorno > 0 && retorno != 10001 && retorno != 10002 && retorno != 10003)
                            {
                                var nomeLogin = _loginApp.ObterNomeUsuarioLogin(retorno);

                                TempData["MSG"] = "success|Registro inserido com Sucesso! O seu Login é " + nomeLogin + " , mas encontra-se BLOQUEADO! Favor solicitar o desbloqueio para o responsável ";



                                string mailFrom = "daniel.ti@sindpetshop.org.br";
                                string subjectMail = "Login Bloqueado!";
                                string tipoMail = "bodyLoginBloqueado";

                                string nomeUsuario = _usuarioApp.ObterNomeUsuario(model.Email);

                                _mailApp.sendMail(mailFrom, model.Email, subjectMail, tipoMail, string.Empty, nomeUsuario, string.Empty, nomeLogin);

                                CarregarCombos();

                                //if (TempData["Registro"] != null)
                                //  return View((RegistroViewModels)TempData["Registro"]);

                                return RedirectToAction("Login", "Auth");

                            }
                            else if (retorno == 10001)
                                TempData["MSG"] = "info|Nome já existe no cadastro!";
                            else if (retorno == 10002)
                                TempData["MSG"] = "info|CPF já existe no cadastro!";
                            else if (retorno == 10003)
                                TempData["MSG"] = "info|Email já existe no cadastro!";
                            else
                                TempData["MSG"] = "warning|Registro não pode ser inserido!";

                            CarregarCombos();

                            RegistroViewModels usuario = new RegistroViewModels();

                            if (TempData["Registro"] != null)
                                return View((RegistroViewModels)TempData["Registro"]);
                        }
                        else
                        {
                            CarregarCombos();

                            TempData["MSG"] = "warning|CPF Inválido!";

                            //var retorno = RecarregaModel(TempData["Registro"]);

                            if (TempData["Registro"] != null)
                                return View((RegistroViewModels)TempData["Registro"]);
                        }
                    }

                }
                else
                {
                    TempData["MSG"] = "warning|Verficar os registros, todos os campos devem ser preenchidos!";

                    CarregarCombos();

                    if (TempData["Registro"] != null)
                        return View((RegistroViewModels)TempData["Registro"]);

                    //var retorno = RecarregaModel(TempData["Registro"]);

                    //return View(retorno);
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "error|Registro com Erro, favor ligar para o Helpdesk";
            }

            return RedirectToAction("Login", "Auth");

        }

        #endregion

        #region Verificar Email

        [HttpGet]
        public IActionResult VerifyEmailCover()
        {


            return View();
        }


        #endregion

        #region Reset Password

        [HttpGet]
        public IActionResult ResetPasswordCover()
        {


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPasswordCover(UsuarioLoginViewModels model)
        {


            var codSistema = new LocalMachine().LerParametro("SINDPETSHOP", "Configuracoes", "CodSistema").Valor;

            try
            {
                if (String.IsNullOrEmpty(model.UsuarioLogin.Email))
                {
                    TempData["MSG"] = "warning|Favor informar o email de cadastro!";
                }
                else
                {
                    _loginApp.ResetarSenhaPorEmailUsuario(model.UsuarioLogin.Email, Convert.ToInt32(codSistema), UsuarioLogado.nmeLoginUsuario.ToString());

                    TempData["MSG"] = "info|Sua senha foi resetada, favor verificar seu e-mail corporativo!";

                    return View(model);

                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "error|Registro com Erro, favor ligar para o Helpdesk";
            }

            return RedirectToAction("Index", "Login");

        }

        #endregion


        #region Metodos Genericos

        public void CarregarCombos()
        {
            ListarDepartamentos();
        }

        public void ListarDepartamentos()
        {
            UsuarioLoginViewModels usuarioLogin = new UsuarioLoginViewModels();
            usuarioLogin.UsuarioLogin = new Domain.Model.UsuarioLogin();
            usuarioLogin.UsuarioLogin.Departamento = new Domain.Model.Departamento();

            usuarioLogin.UsuarioLogin.Departamento.lstDepartamentos = _loginApp.ListarDepartamentos();

            ViewBag.ViewDepartamento = new SelectList(usuarioLogin.UsuarioLogin.Departamento.lstDepartamentos, "CodDepartamento", "Descricao");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private string ConvertTextEncoding(string originalString)
        {
            byte[] utf8Bytes = Encoding.UTF8.GetBytes(originalString);

            string decodedString = Encoding.UTF8.GetString(utf8Bytes);

            return decodedString;
        }

        #endregion

    }
}
