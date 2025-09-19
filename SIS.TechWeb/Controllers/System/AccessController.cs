using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SIS.ControleAcesso.Model;
using SIS.Tech.App;
using SIS.Tech.Domain.Model;
using SIS.Tech.IApp;
using SIS.Tech.Models;
using SIS.Tech.Models.Access;
using SIS.Tech.Models.Login;
using SISFramework.Parameter.DerivedParameter;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace SIS.Tech.Controllers.System
{
  public class AccessController : BaseController
  {
    private readonly ILogger<AccessController> _logger;
    private readonly IAccessApp _accessApp;
    private readonly ILoginApp _loginApp;
    
    public AccessController(ILogger<AccessController> logger, IAccessApp accessApp, ILoginApp loginApp)
    {
      _logger = logger;
      _accessApp = accessApp;
      _loginApp = loginApp;
    }

    public IActionResult Permission(string nomeUsuario, string nmeLoginUsuario, string codPerfil)
    {
      if (!VerificaSession())
      {
        return RedirectToAction("Login", "Auth");
      }

      ViewBag.PermitidoPesquisar = VerificarPermissaoControle("Permission", "Pesquisar");

      ListarPerfis();

      Permissions permission = new Permissions();

      permission.lstPermissions = _accessApp.ListarPermissoesAcessos(nomeUsuario, nmeLoginUsuario, codPerfil);

      return View(permission);
    }

    
    [HttpGet]
    public ActionResult Controls(string nomeUsuario, string nmeLoginUsuario, string codPerfil)
    {
      if (!VerificaSession())
      {
        return RedirectToAction("Login", "Auth");
      }

      int codPerfilAux = 0;

      ViewBag.PermitidoPesquisar = VerificarPermissaoControle("Controls", "Pesquisar");
      ViewBag.PermitidoLiberarAcessoControle = VerificarPermissaoControle("Controls", "LiberarAcessoControle");
      ViewBag.PermitidoBloquearAcessoControle = VerificarPermissaoControle("Controls", "BloquearAcessoControle");

      try
      {
        ListarPerfis();

        ControleAcessoViewModels controles = new ControleAcessoViewModels();
        controles.ControleAcesso = new Domain.Model.ControleAcessoSGE();

        if (String.IsNullOrEmpty(codPerfil))
        {
          controles.ControleAcesso.lstControleAcessos = _accessApp.ListarControleAcessos(0, 0, nomeUsuario, nmeLoginUsuario);
        }
        else
        {
          codPerfilAux = Convert.ToInt32(codPerfil);

          controles.ControleAcesso.lstControleAcessos = _accessApp.ListarControleAcessos(codPerfilAux, 0, nomeUsuario, nmeLoginUsuario);
        }


        return View(controles);
      }
      catch (Exception ex)
      {
        //Log.GravaLog(string.Empty, GetClientIp(), Types.Aplicativo.DaycambioWeb, Types.TipoLog.Erro, Types.TipoDescricaoLog.Html, "DayCambio.Mvc.Web.Core - Login Controller", "WEB", string.Empty, ex.ToString());
        return RedirectToAction("Index", "Erro");
      }

      return RedirectToAction("ListarUsuarios", "Login");
    }


    public void ListarPerfis()
    {
      PerfilViewModels perfil = new PerfilViewModels();
      perfil.Perfil = new Perfil();

      perfil.Perfil.lstPerfis = _accessApp.ListarPerfis();

      ViewBag.ViewPerfis = new SelectList(perfil.Perfil.lstPerfis, "CodPerfil", "NmePerfil");
    }


    public IActionResult Roles()
    {
      if (!VerificaSession())
      {
        return RedirectToAction("Login", "Auth");
      }

      ViewBag.PermitidoLiberarAcessoPerfil = VerificarPermissaoControle("Roles", "LiberarAcessoPerfil");
      ViewBag.PermitidoBloquearAcessoPerfil = VerificarPermissaoControle("Roles", "BloquearAcessoPerfil");
            
      Perfil perfil = new Perfil();
      perfil.lstPerfis = _accessApp.ListarPerfis();

      Roles roles = new Roles();

      var listRoles = new List<Roles>();

      if (perfil != null)
      {
        if (perfil.lstPerfis.Count > 0)
        {
          for (int i = 0; i < perfil.lstPerfis.Count; i++)
          {
            Roles _item = new Roles();

            _item = _accessApp.ListarRoles(perfil.lstPerfis[i].CodPerfil);

            if (_item.CodPerfil > 0)
            {
              if (_item.CodUsuario == UsuarioLogado.mUsuario.codUsuario)
              {
                ViewBag.CodUsuario = UsuarioLogado.mUsuario.codUsuario;
                ViewBag.CodPerfilUsuario = _item.CodPerfil;
              }

              listRoles.Add(_item);
            }                      
          }
        }
      }

      roles.lstRoles = listRoles; 

      return View(roles);
    }


    [HttpGet]
    public ActionResult BloquearAcessoPorPerfil(int codPerfil, int ativo)
    {
      if (!VerificaSession())
      {
        return RedirectToAction("Login", "Auth");
      }

      try
      {
        bool ativoAux = true;

        if (codPerfil != 1)
        {
          if (ativo == 0)
            ativoAux = false;

          var codSistema = new LocalMachine().LerParametro("SINDPETSHOP", "Configuracoes", "CodSistema").Valor;

          _accessApp.AlterarControleUsuarioPorPerfil(codPerfil, ativoAux, UsuarioLogado.nmeLoginUsuario.ToString());

          if (ativo == 0)
            TempData["MSG"] = "success|Acesso bloqueado com sucesso! ";
          else
            TempData["MSG"] = "success|Acesso liberado com sucesso! ";
          
        }
        else
        {
          TempData["MSG"] = "info|Função de BLOQUEAR ACESSO, não considerado para Diretoria!";
        }
      }
      catch (Exception ex)
      {
        //Log.GravaLog(string.Empty, GetClientIp(), Types.Aplicativo.DaycambioWeb, Types.TipoLog.Erro, Types.TipoDescricaoLog.Html, "DayCambio.Mvc.Web.Core - Login Controller", "WEB", string.Empty, ex.ToString());
        return RedirectToAction("Index", "Erro");
      }

      return RedirectToRoute(new { controller = "Access", action = "Roles" });
    }



    [HttpGet]
    public ActionResult BloquearAcesso(int codFormulario, int codControle, int codPerfil, int codUsusario)
    {
      if (!VerificaSession())
      {
        return RedirectToAction("Login", "Auth");
      }

      try
      {
        var codSistema = new LocalMachine().LerParametro("SINDPETSHOP", "Configuracoes", "CodSistema").Valor;

        if (codFormulario > 0 && codControle == 0)
        {
          _accessApp.AlterarControleUsuarioPorFormulario(codFormulario, false, codPerfil, UsuarioLogado.nmeLoginUsuario.ToString(), codUsusario);
        }
        else
        {
          if (codControle > 0 && codFormulario == 0)
          {
            _accessApp.AlterarControleUsuarioPorControle(codControle, false, codPerfil, UsuarioLogado.nmeLoginUsuario.ToString(), codUsusario);
          }
        }

         TempData["MSG"] = "success|Acesso bloqueado com sucesso! ";

      }
      catch (Exception ex)
      {
        //Log.GravaLog(string.Empty, GetClientIp(), Types.Aplicativo.DaycambioWeb, Types.TipoLog.Erro, Types.TipoDescricaoLog.Html, "DayCambio.Mvc.Web.Core - Login Controller", "WEB", string.Empty, ex.ToString());
        return RedirectToAction("Index", "Erro");
      }

      return RedirectToRoute(new { controller = "Access", action = "Controls" });

    }


    [HttpGet]
    public ActionResult LiberarAcesso(int codFormulario, int codControle, int codPerfil, int codUsusario)
    {
      if (!VerificaSession())
      {
        return RedirectToAction("Login", "Auth");
      }

      try
      {
        var codSistema = new LocalMachine().LerParametro("SINDPETSHOP", "Configuracoes", "CodSistema").Valor;

        if (codFormulario > 0 && codControle == 0)
        {
          _accessApp.AlterarControleUsuarioPorFormulario(codFormulario, true, codPerfil, UsuarioLogado.nmeLoginUsuario.ToString(), codUsusario);
        }
        else
        {
          if (codControle > 0 && codFormulario == 0)
          {
            _accessApp.AlterarControleUsuarioPorControle(codControle, true, codPerfil, UsuarioLogado.nmeLoginUsuario.ToString(), codUsusario);
          }
        }

        //TempData["MSG"] = "success|Acesso liberado com sucesso! ";

      }
      catch (Exception ex)
      {
        //Log.GravaLog(string.Empty, GetClientIp(), Types.Aplicativo.DaycambioWeb, Types.TipoLog.Erro, Types.TipoDescricaoLog.Html, "DayCambio.Mvc.Web.Core - Login Controller", "WEB", string.Empty, ex.ToString());
        return RedirectToAction("Index", "Erro");
      }

      return RedirectToRoute(new { controller = "Access", action = "Controls" });
    }


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
  }
}
