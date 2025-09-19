using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SIS.Tech.Domain.Model;
using SIS.Tech.IApp;
using SIS.Tech.Models.Convencoes;
using SISFramework.Parameter.DerivedParameter;

namespace SIS.Tech.Controllers.System
{
  public class ConvencaoController : BaseController
  {
    private readonly ILogger<UserController> _logger;
    private readonly IConvencaoApp _convencaoApp;
    private readonly ILoginApp _loginApp;
    private readonly IUsuarioApp _usuarioApp;
    private readonly IMailApp _mailApp;
    private readonly ITipoCCTApp _tipoCCTApp;
    private readonly IStatusCCTApp _statusCCTApp;


    public ConvencaoController(ILogger<UserController> logger, IConvencaoApp convencaoApp, ILoginApp loginApp, IUsuarioApp usuarioApp, IMailApp mailApp, ITipoCCTApp tipoCCTApp, IStatusCCTApp statusCCTApp)
    {
      _logger = logger;
      _convencaoApp = convencaoApp;
      _loginApp = loginApp;
      _usuarioApp = usuarioApp;
      _mailApp = mailApp;
      _tipoCCTApp = tipoCCTApp;
      _statusCCTApp = statusCCTApp;
    }

    #region Index

    [HttpGet]
    public IActionResult Index(string nomeConvencao, string codTipoCCT, string codStatusCCT, string anoVigenciaInicial, string anoVigenciaFinal)
    {
      if (!VerificaSession())
      {
        return RedirectToAction("Login", "Auth");
      }

      ViewBag.PermitidoPesquisar = VerificarPermissaoControle("Convencao", "Pesquisar");
      ViewBag.PermitidoInserir = VerificarPermissaoControle("Convencao", "Inserir");
      ViewBag.PermitidoDetalhe = VerificarPermissaoControle("Convencao", "Detalhe");
      ViewBag.PermitidoEditar = VerificarPermissaoControle("Convencao", "Editar");
      ViewBag.PermitidoExcluir = VerificarPermissaoControle("Convencao", "Excluir");

      try
      {
        string nomeConvencaoAux = string.Empty;
        int codTipoCCTAux = 0;
        int codStatusCCTAux = 0;
        string anoVigenciaInicialAux = string.Empty;
        string anoVigenciaFinalAux = string.Empty;

        if (!string.IsNullOrEmpty(nomeConvencao))
          nomeConvencaoAux = nomeConvencao;

        if (!string.IsNullOrEmpty(codTipoCCT))
          codTipoCCTAux = Convert.ToInt32(codTipoCCT);

        if (!string.IsNullOrEmpty(codStatusCCT))
          codStatusCCTAux = Convert.ToInt32(codStatusCCT);

        if (!string.IsNullOrEmpty(anoVigenciaInicial))
          anoVigenciaInicialAux = anoVigenciaInicial;

        if (!string.IsNullOrEmpty(anoVigenciaFinal))
          anoVigenciaFinalAux = anoVigenciaFinal;

        Convencao convencao = new Convencao();

        var codSistema = new LocalMachine().LerParametro("SINDPETSHOP", "Configuracoes", "CodSistema").Valor;

        convencao.CodConvencao = Convert.ToInt32(codSistema);

        CarregarCombos();

        convencao = CarregaConvencao(nomeConvencaoAux, codTipoCCTAux, codStatusCCTAux, anoVigenciaInicialAux, anoVigenciaFinalAux);

        return View(convencao);
      }
      catch (Exception ex)
      {
        //Log.GravaLog(string.Empty, GetClientIp(), Types.Aplicativo.DaycambioWeb, Types.TipoLog.Erro, Types.TipoDescricaoLog.Html, "DayCambio.Mvc.Web.Core - Login Controller", "WEB", string.Empty, ex.ToString());
        return RedirectToAction("MiscError", "Error");
      }

    }

    #endregion

    #region InsertEdit


    [HttpGet]
    public ActionResult InsertEdit(int? convencaoId = 0)
    {
      if (!VerificaSession())
      {
        return RedirectToAction("Login", "Auth");
      }

      CarregarCombos();

      int codConvencaoAux = (int)convencaoId;

      Convencao model = new Convencao();

      model.CodConvencao = codConvencaoAux;

      model = ObterConvencao(codConvencaoAux);

      return PartialView("_ModalAddConvencao", model);
    }

    [HttpPost]
    public ActionResult InsertEdit(Convencao model)
    {
      var codConvencao = 0;

      if (!VerificaSession())
      {
        return RedirectToAction("Login", "Auth");
      }

      ModelState.Remove("CodConvencao");
      ModelState.Remove("lstConvencao");
      ModelState.Remove("TipoCCT.Descricao");
      ModelState.Remove("TipoCCT.lstTipoCCT");
      ModelState.Remove("StatusCCT.Descricao");
      ModelState.Remove("StatusCCT.lstStatusCCT");

      if (!ModelState.IsValid)
      {
        //cView("Index", CarregaConvencaoInsertEdit(codConvencao));

        TempData["MSG"] = "warning|Preencha todos os campos!";

        CarregarCombos();

        return PartialView("_ModalAddConvencao", model);
      }

      try
      {

        model.Quem = UsuarioLogado.nmeLoginUsuario.ToString();

        if (model.CodConvencao > 0)
        {
          codConvencao = model.CodConvencao;

          var retorno = _convencaoApp.AlterarConvencao(model);

          if (retorno > 0)
            TempData["MSG"] = "success|Registro alterado com Sucesso";
          else
            TempData["MSG"] = "warning|Registro não pode ser alterado!";
        }
        else
        {
          codConvencao = _convencaoApp.InserirConvencao(model);

          if (codConvencao > 0)
            TempData["MSG"] = "success|Registro inserido com Sucesso";
          else
            TempData["MSG"] = "warning|Registro não pode ser inserido!";
        }
      }
      catch (Exception ex)
      {
        //Log.GravaLog(string.Empty, GetClientIp(), Types.Aplicativo.DaycambioWeb, Types.TipoLog.Erro, Types.TipoDescricaoLog.Html, "DayCambio.Mvc.Web.Core - Login Controller", "WEB", string.Empty, ex.ToString());
        return RedirectToAction("MiscError", "Error");
      }

      return RedirectToAction("Index");
    }


    [HttpGet]
    public ActionResult Detalhe(int codConvencao)
    {
      if (!VerificaSession())
      {
        return RedirectToAction("Login", "Auth");
      }

      var convencao = ObterConvencao(codConvencao);

      return View(convencao);
    }


    [HttpGet]
    public ActionResult Delete(int convencaoId)
    {
      if (!VerificaSession())
      {
        return RedirectToAction("Login", "Auth");
      }

      ViewBag.Acao = "Deseja excluir esta CCT?";

      Convencao convencao = new Convencao();

      if (convencaoId > 0)
      {
        convencao = _convencaoApp.ObterConvencao(convencaoId);
      }

      return PartialView("_ModalDeleteConvencao", convencao);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(Convencao model)
    {
      if (!VerificaSession())
      {
        return RedirectToAction("Login", "Auth");
      }

      try
      {
        _convencaoApp.ExcluirConvencao(model.CodConvencao, UsuarioLogado.nmeLoginUsuario.ToString());

        TempData["MSG"] = "success|Convenção excluída com sucesso!";

      }
      catch (Exception ex)
      {
        TempData["MSG"] = "error|Registro com Erro, favor ligar para o Helpdesk";
      }

      return RedirectToRoute(new { controller = "Convencao", action = "Index", nomeConvencao = string.Empty, codTipoCCT = string.Empty, codStatusCCT = string.Empty, anoVigenciaInicial = string.Empty, anoVigenciaFinal = string.Empty });
    }


    #endregion

    #region Historico


    public IActionResult Hist()
    {
      if (!VerificaSession())
      {
        return RedirectToAction("Login", "Auth");
      }

      return View();
    }

    #endregion

    #region Metodos Publicos


    /// <summary>
    /// carrega dados da convencao
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    private Convencao CarregaConvencao(string nomeConvencao, int codTipoCCT, int codStatusCCT, string anoVigenciaInicial, string anoVigenciaFinal)
    {
      Convencao convencao = new Convencao();

      convencao.lstConvencao = _convencaoApp.ListarConvencao(nomeConvencao, codTipoCCT, codStatusCCT, anoVigenciaInicial, anoVigenciaFinal);

      List<string> totais = _convencaoApp.ObterTotaisCCT();

      if (totais.Count > 0)
      {
        convencao.TotalGeral = Convert.ToInt32(totais[0]);
        convencao.TotalAssinadas = Convert.ToInt32(totais[1]);
        convencao.TotalEmNegociacao = Convert.ToInt32(totais[2]) + Convert.ToInt32(totais[3]);
        convencao.TotalEmNegociacaoPacifico = Convert.ToInt32(totais[2]);
        convencao.TotalEmNegociacaoJuridico = Convert.ToInt32(totais[3]);
      }



      return convencao;
    }

    /// <summary>
    /// carrega dados da convencao
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    private Convencao ObterConvencao(int codConvencao)
    {
      Convencao convencao = new Convencao();

      convencao = _convencaoApp.ObterConvencao(codConvencao);

      return convencao;
    }

    #endregion

    #region Metodos Genericos


    public void CarregarCombos()
    {
      ListarTipoCCT();
      ListarStatusCCT();
    }

    public List<TipoCCTViewModels> ListarTipoCCTViewModel()
    {
      TipoCCTViewModels viewModel = new TipoCCTViewModels();

      TipoCCT tipopCCT = new TipoCCT();
      tipopCCT.lstTipoCCT = _tipoCCTApp.ListarTipoCCT();


      var listaNew = new List<TipoCCTViewModels>();

      if (tipopCCT.lstTipoCCT.Count > 0)
      {
        for (int i = 0; i < tipopCCT.lstTipoCCT.Count; i++)
        {
          listaNew.Add(new TipoCCTViewModels()
          {
            CodTipoCCT = tipopCCT.lstTipoCCT[i].CodTipoCCT,
            Descricao = tipopCCT.lstTipoCCT[i].Descricao
          });
        }
      }

      return listaNew;
    }

    public List<StatusCCTViewModels> ListarStatusCCTViewModel()
    {
      StatusCCTViewModels viewModel = new StatusCCTViewModels();

      StatusCCT StatuspCCT = new StatusCCT();
      StatuspCCT.lstStatusCCT = _statusCCTApp.ListarStatusCCT();


      var listaNew = new List<StatusCCTViewModels>();

      if (StatuspCCT.lstStatusCCT.Count > 0)
      {
        for (int i = 0; i < StatuspCCT.lstStatusCCT.Count; i++)
        {
          listaNew.Add(new StatusCCTViewModels()
          {
            CodStatusCCT = StatuspCCT.lstStatusCCT[i].CodStatusCCT,
            Descricao = StatuspCCT.lstStatusCCT[i].Descricao
          });
        }
      }

      return listaNew;
    }

    public void ListarTipoCCT()
    {
      TipoCCTViewModels viewModel = new TipoCCTViewModels();

      TipoCCT tipopCCT = new TipoCCT();

      tipopCCT.lstTipoCCT = _tipoCCTApp.ListarTipoCCT();

      ViewBag.ViewTipoCCt = new SelectList(tipopCCT.lstTipoCCT, "CodTipoCCT", "Descricao");
    }

    public void ListarStatusCCT()
    {
      StatusCCTViewModels viewModel = new StatusCCTViewModels();

      StatusCCT statuspCCT = new Domain.Model.StatusCCT();

      statuspCCT.lstStatusCCT = _statusCCTApp.ListarStatusCCT();

      ViewBag.ViewStatusCCt = new SelectList(statuspCCT.lstStatusCCT, "CodStatusCCT", "Descricao");
    }

    #endregion


  }
}
