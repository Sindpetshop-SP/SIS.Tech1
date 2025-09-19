using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SIS.Tech.App;
using SIS.Tech.Domain;
using SIS.Tech.Domain.Model;
using SIS.Tech.IApp;
using SIS.Tech.Models;
using SIS.Tech.Models.Login;
using SIS.Tech.Models.User;
using SISFramework.Parameter.DerivedParameter;
using SISFramework.Security.Criptografia;
using System.Diagnostics;

namespace SIS.Tech.Controllers.System;

public class UserController : BaseController
{

    private readonly ILogger<UserController> _logger;
    private readonly ILoginApp _loginApp;
    private readonly IUsuarioApp _usuarioApp;
    private readonly IMailApp _mailApp;

    public UserController(ILogger<UserController> logger, ILoginApp loginApp, IUsuarioApp usuarioApp, IMailApp mailApp)
    {
        _logger = logger;
        _loginApp = loginApp;
        _usuarioApp = usuarioApp;
        _mailApp = mailApp;
    }

    #region Lista de Usuarios

    [HttpGet]
    public ActionResult List(string nomeUsuario, string nmeLoginUsuario, string codDepartamento, string numeroCpf)
    {


        if (!VerificaSession())
        {
            return RedirectToAction("Login", "Auth");
        }

        ViewBag.PermitidoPesquisar = VerificarPermissaoControle("User", "Pesquisar");
        ViewBag.PermitidoBloqueiaUsuario = VerificarPermissaoControle("User", "BloqueiaUsuario");
        ViewBag.PermitidoDesbloqueiaUsuario = VerificarPermissaoControle("User", "DesbloqueiaUsuario");
        ViewBag.PermitidoResetarSenha = VerificarPermissaoControle("User", "ResetarSenha");

        try
        {
            CarregarCombos();

            string nomeUsuarioAux = string.Empty;
            string nmeLoginUsuarioAux = string.Empty;
            int codDepartamentoAux = 0;
            string numeroCpfAux = string.Empty;

            if (!string.IsNullOrEmpty(nomeUsuario))
                nomeUsuarioAux = nomeUsuario;

            if (!string.IsNullOrEmpty(nmeLoginUsuario))
                nmeLoginUsuarioAux = nmeLoginUsuario;

            if (!string.IsNullOrEmpty(codDepartamento))
                codDepartamentoAux = Convert.ToInt32(codDepartamento);

            if (!string.IsNullOrEmpty(numeroCpf))
                numeroCpfAux = numeroCpf;

            UsuarioLoginViewModels usuarioLogin = new UsuarioLoginViewModels();
            usuarioLogin.UsuarioLogin = new Domain.Model.UsuarioLogin();
            usuarioLogin.UsuarioLogin.Departamento = new Domain.Model.Departamento();

            var codSistema = new LocalMachine().LerParametro("SINDPETSHOP", "Configuracoes", "CodSistema").Valor;

            usuarioLogin.UsuarioLogin.lstUsuariosLogin = _usuarioApp.ListarUsuariosFiltro(nomeUsuarioAux, nmeLoginUsuarioAux, codDepartamentoAux, numeroCpfAux, Convert.ToInt32(codSistema));

            usuarioLogin.UsuarioLogin.UserTotalizadores = _usuarioApp.ObterUserTotalizadores(Convert.ToInt32(codSistema));

            return View(usuarioLogin);
        }
        catch (Exception ex)
        {
            //Log.GravaLog(string.Empty, GetClientIp(), Types.Aplicativo.DaycambioWeb, Types.TipoLog.Erro, Types.TipoDescricaoLog.Html, "DayCambio.Mvc.Web.Core - Login Controller", "WEB", string.Empty, ex.ToString());
            return RedirectToAction("MiscError", "Error");
        }
    }


    #endregion

    #region Alterar Senha

    [HttpGet]
    public ActionResult AlterarSenha()
    {
        if (!VerificaSession())
        {
            return RedirectToAction("Login", "Auth");
        }

        AlterarSenhaViewModels senha = new AlterarSenhaViewModels();
        senha.CodUsuario = UsuarioLogado.mUsuario.codUsuario;

        return View(senha);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult AlterarSenha(AlterarSenhaViewModels model)
    {
        if (!VerificaSession())
        {
            return RedirectToAction("Login", "Auth");
        }

        try
        {
            if (String.IsNullOrEmpty(model.newPassword) || String.IsNullOrEmpty(model.confirmPassword))
            {
                TempData["MSG"] = "warning|Todos os campos devem ser preenchidos!";
            }
            else
            {
                var codSistema = new LocalMachine().LerParametro("SINDPETSHOP", "Configuracoes", "CodSistema").Valor;

                var senhaCrypto = Helper.Criptografar(model.newPassword, EncryptAlgorithm.EncryptionAlgorithm.Rijndael);

                model.newPassword = senhaCrypto;

                _loginApp.AlterarSenhaUsuario(model.CodUsuario, Convert.ToInt32(codSistema), model.newPassword, UsuarioLogado.nmeLoginUsuario.ToString());

                return RedirectToAction("Login", "Auth");
            }
        }
        catch (Exception ex)
        {
            TempData["MSG"] = "error|Registro com Erro, favor ligar para o Helpdesk";
        }

        return RedirectToRoute(new { controller = "User", action = "AlterarSenha" });

    }

    #endregion

    #region BloqueiaUsuario

    [HttpGet]
    public ActionResult BloqueiaUsuario(int codUsuario)
    {

        if (!VerificaSession())
        {
            return RedirectToAction("Login", "Auth");
        }

        try
        {
            var codSistema = new LocalMachine().LerParametro("SINDPETSHOP", "Configuracoes", "CodSistema").Valor;

            _loginApp.BloqueiaDesbloqueiaUsuario(codUsuario, Convert.ToInt32(codSistema), 0, UsuarioLogado.nmeLoginUsuario.ToString());

            TempData["MSG"] = "success|Bloqueio realizado com Sucesso! ";

        }
        catch (Exception ex)
        {
            //Log.GravaLog(string.Empty, GetClientIp(), Types.Aplicativo.DaycambioWeb, Types.TipoLog.Erro, Types.TipoDescricaoLog.Html, "DayCambio.Mvc.Web.Core - Login Controller", "WEB", string.Empty, ex.ToString());
            return RedirectToAction("MiscError", "Error");
        }

        return RedirectToAction("List", "User");
    }

    #endregion

    #region DesbloqueiaUsuario

    [HttpGet]
    public ActionResult DesbloqueiaUsuario(int codUsuario)
    {

        if (!VerificaSession())
        {
            return RedirectToAction("Login", "Auth");
        }

        try
        {
            var codSistema = new LocalMachine().LerParametro("SINDPETSHOP", "Configuracoes", "CodSistema").Valor;

            _loginApp.BloqueiaDesbloqueiaUsuario(codUsuario, Convert.ToInt32(codSistema), 1, UsuarioLogado.nmeLoginUsuario.ToString());

            TempData["MSG"] = "success|Desbloqueio realizado com Sucesso! ";

        }
        catch (Exception ex)
        {
            //Log.GravaLog(string.Empty, GetClientIp(), Types.Aplicativo.DaycambioWeb, Types.TipoLog.Erro, Types.TipoDescricaoLog.Html, "DayCambio.Mvc.Web.Core - Login Controller", "WEB", string.Empty, ex.ToString());
            return RedirectToAction("MiscError", "Error");
        }

        return RedirectToAction("List", "User");
    }

    #endregion

    #region ResetarSenha


    [HttpGet]
    public ActionResult ResetarSenha(int codUsuario)
    {

        if (!VerificaSession())
        {
            return RedirectToAction("Login", "Auth");
        }

        try
        {
            var codSistema = new LocalMachine().LerParametro("SINDPETSHOP", "Configuracoes", "CodSistema").Valor;

            var senhaNew = _loginApp.ResetarSenhaUsuario(codUsuario, Convert.ToInt32(codSistema), UsuarioLogado.nmeLoginUsuario.ToString());

            string mailFrom = "daniel.ti@sindpetshop.org.br";
            string subjectMail = "Senha temporária";
            string tipoMail = "bodyConfirmForgotPassword";

            var usuario = _loginApp.ObtemDadosUsuarioParaEmail(codUsuario.ToString());

            _mailApp.sendMail(mailFrom, usuario.Email, subjectMail, tipoMail, string.Empty, usuario.NmeUsuario, senhaNew, string.Empty);

            TempData["MSG"] = "info|O Profissional receberá um e-mail com a nova Senha!";

        }
        catch (Exception ex)
        {
            //Log.GravaLog(string.Empty, GetClientIp(), Types.Aplicativo.DaycambioWeb, Types.TipoLog.Erro, Types.TipoDescricaoLog.Html, "DayCambio.Mvc.Web.Core - Login Controller", "WEB", string.Empty, ex.ToString());
            return RedirectToAction("MiscError", "Error");
        }

        return RedirectToAction("List", "User");
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


    #endregion

    public IActionResult ViewAccount()
    {

        if (!VerificaSession())
        {
            return RedirectToAction("Login", "Auth");
        }

        return View();
    }

    public IActionResult ViewBilling()
    {


        if (!VerificaSession())
        {
            return RedirectToAction("Login", "Auth");
        }

        return View();
    }

    public IActionResult ViewConnections()
    {


        if (!VerificaSession())
        {
            return RedirectToAction("Login", "Auth");
        }

        return View();
    }

    public IActionResult ViewNotifications()
    {


        if (!VerificaSession())
        {
            return RedirectToAction("Login", "Auth");
        }

        return View();
    }

    public IActionResult ViewSecurity()
    {


        if (!VerificaSession())
        {
            return RedirectToAction("Login", "Auth");
        }

        return View();
    }

    public IActionResult AccountSettings()
    {


        if (!VerificaSession())
        {
            return RedirectToAction("Login", "Auth");
        }

        return View();
    }

    public IActionResult AccountSettingsBilling()
    {


        if (!VerificaSession())
        {
            return RedirectToAction("Login", "Auth");
        }

        return View();
    }

    public IActionResult AccountSettingsConnections()
    {


        if (!VerificaSession())
        {
            return RedirectToAction("Login", "Auth");
        }

        return View();
    }

    public IActionResult AccountSettingsNotifications()
    {


        if (!VerificaSession())
        {
            return RedirectToAction("Login", "Auth");
        }

        return View();
    }

    public IActionResult AccountSettingsSecurity()
    {


        if (!VerificaSession())
        {
            return RedirectToAction("Login", "Auth");
        }

        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    } 
}
