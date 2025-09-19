using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SIS.Tech.Domain.Model;
using SIS.Tech.IApp;
using SIS.Tech.Models.Empresas;
using SIS.Tech.Models.Contatos;
using SIS.Tech.Models.Enderecos;
using SIS.Tech.Models.RamoAtividades;

namespace SIS.Tech.Controllers.System
{
  public class EmpresaController : BaseController
  {
    private readonly IEmpresaApp _appEmpresa;
    private readonly IContatoApp _appContato;
    private readonly IEnderecoApp _appEndereco;
    private readonly IRamoAtividadeApp _appRamoAtividade;
    private readonly ITipoPessoaApp _appTipoPessoa;
    private readonly ISocioApp _appSocio;
    private readonly IFuncionarioApp _appFuncionario;

    public EmpresaController(IEmpresaApp appEmpresa, ISocioApp appSocio, IFuncionarioApp appFuncionario, IRamoAtividadeApp appRamoAtividade, IContatoApp appContato, IEnderecoApp appEndereco, ITipoPessoaApp appTipoPessoa)
    {
      _appEmpresa = appEmpresa;
      _appSocio = appSocio;
      _appFuncionario = appFuncionario;
      _appRamoAtividade = appRamoAtividade;
      _appContato = appContato;
      _appEndereco = appEndereco;
      _appTipoPessoa = appTipoPessoa;
    }

    #region Dashboard

    [HttpGet]
    public IActionResult Dashboard()
    {
      return View();
    }




    public IActionResult CustomerAll() => View();

    public IActionResult CustomerDetailsBilling() => View();
    public IActionResult CustomerDetailsNotifications() => View();
    public IActionResult CustomerDetailsOverview() => View();
    public IActionResult CustomerDetailsSecurity() => View();


    #endregion

    #region Pesquisa / Lista Empresas

    [HttpGet, ActionName("Index")]
    public IActionResult Index(string? Cnpj, string? RazaoSocial, string? NomeFantasia)
    {
      if (!VerificaSession())
      {
        return RedirectToAction("Login", "Auth");
      }

      ViewBag.PermitidoPesquisar = VerificarPermissaoControle("Empresa", "Pesquisar");
      ViewBag.PermitidoInserir = VerificarPermissaoControle("Empresa", "Novo");
      ViewBag.PermitidoDetalhe = VerificarPermissaoControle("Empresa", "Detalhe");
      ViewBag.PermitidoEditar = VerificarPermissaoControle("Empresa", "Editar");
      ViewBag.PermitidoExcluir = VerificarPermissaoControle("Empresa", "Excluir");

      try
      {
        if (ModelState.IsValid)
        {
          if (!String.IsNullOrEmpty(Cnpj) | !String.IsNullOrEmpty(RazaoSocial) | !String.IsNullOrEmpty(NomeFantasia))
          {
            EmpresaViewModel empresa = new EmpresaViewModel();
            empresa.Empresa = new Empresa();
            empresa.Empresa.lstEmpresa = _appEmpresa.ListarEmpresaFiltro(Cnpj, RazaoSocial, NomeFantasia);

            return View(empresa);
          }
          else
          {
            EmpresaViewModel empresa = new EmpresaViewModel();
            empresa.Empresa = new Empresa();
            empresa.Empresa.lstEmpresa = _appEmpresa.ListarEmpresa();

            return View(empresa);
          }

        } 
         
        return RedirectToAction("Index", "Empresa");

      }
      catch (Exception)
      {
        //Log.GravaLog(string.Empty, GetClientIp(), Types.Aplicativo.DaycambioWeb, Types.TipoLog.Erro, Types.TipoDescricaoLog.Html, "DayCambio.Mvc.Web.Core - Login Controller", "WEB", string.Empty, ex.ToString());
        return RedirectToAction("MiscError", "Error");
        throw;
      }

        return View();
    }

    #endregion

    #region Detalhe

    [HttpGet]
    public ActionResult DetailsOverview(int codEmpresa)
    {
      if (!VerificaSession())
      {
        return RedirectToAction("Login", "Auth");
      }

      ViewBag.PermitidoPesquisar = VerificarPermissaoControle("Empresa", "Pesquisar");
      ViewBag.PermitidoInserir = VerificarPermissaoControle("Empresa", "Novo");
      ViewBag.PermitidoDetalhe = VerificarPermissaoControle("Empresa", "Detalhe");
      ViewBag.PermitidoEditar = VerificarPermissaoControle("Empresa", "Editar");
      ViewBag.PermitidoExcluir = VerificarPermissaoControle("Empresa", "Excluir");

      ViewBag.PermitidoNovoContato = VerificarPermissaoControle("Empresa", "NovoContato");
      ViewBag.PermitidoEditarContato = VerificarPermissaoControle("Empresa", "EditarContato");
      ViewBag.PermitidoExcluirContato = VerificarPermissaoControle("Empresa", "ExcluirContato");

      ViewBag.PermitidoNovoEndereco = VerificarPermissaoControle("Empresa", "NovoEndereco");
      ViewBag.PermitidoEditarEndereco = VerificarPermissaoControle("Empresa", "EditarEndereco");
      ViewBag.PermitidoExcluirEndereco = VerificarPermissaoControle("Empresa", "ExcluirEndereco");

      ViewBag.PermitidoNovoFuncionario = VerificarPermissaoControle("Empresa", "NovoFuncionario");
      ViewBag.PermitidoEditarFuncionario = VerificarPermissaoControle("Empresa", "EditarFuncionario");
      ViewBag.PermitidoExcluirFuncionario = VerificarPermissaoControle("Empresa", "ExcluirFuncionario");

      ViewBag.PermitidoNovoSocio = VerificarPermissaoControle("Empresa", "NovoSocio");
      ViewBag.PermitidoEditarSocio = VerificarPermissaoControle("Empresa", "EditarSocio");
      ViewBag.PermitidoExcluirSocio = VerificarPermissaoControle("Empresa", "ExcluirSocio");

      CarregaCombos();

      EmpresaViewModel empresa = new EmpresaViewModel();
      empresa.Empresa = new Empresa();
      empresa.Empresa = _appEmpresa.ObterEmpresa(codEmpresa);

      return View(empresa);
    }


    [HttpGet]
    public ActionResult DetailsContacts(int codEmpresa)
    {
      if (!VerificaSession())
      {
        return RedirectToAction("Login", "Auth");
      }

      CarregaCombos();

      EmpresaViewModel empresa = new EmpresaViewModel();
      empresa.Empresa = new Empresa();
      empresa.Empresa = _appEmpresa.ObterEmpresa(codEmpresa);

      //contatos
      empresa.Empresa.Contato = new Contato();
      empresa.Empresa.Contato.lstContatos = _appContato.ListarContatosEmpresa(codEmpresa);

      //enderecos
      empresa.Empresa.Endereco = new Endereco();
      empresa.Empresa.Endereco.lstEnderecos = _appEndereco.ListarEnderecosEmpresa(codEmpresa);

      return View(empresa);
    }



    #endregion

    #region Inserir, Editar e Excluir


    [HttpGet]
    public ActionResult InsertEdit(int empresaId)
    {
      if (!VerificaSession())
      {
        return RedirectToAction("Login", "Auth");
      }

      ListarTipoPessoa();
      ListarRamoAtividade();

      var empresa = new EmpresaViewModel();

      if (empresaId > 0)
      {
        empresa = CarregaEmpresa(empresaId);
      }
      else
      {
        empresa = CarregaEmpresa(0);
      }

      return PartialView("_ModalInsertEdit", empresa);

    }


    public EmpresaViewModel CarregaEmpresa(int codEmpresa)
    {
      CarregaCombos();

      var emp = new EmpresaViewModel();
      emp.Empresa = new Empresa();

      //update
      emp.Empresa = _appEmpresa.ObterEmpresa(codEmpresa);
      emp.Empresa.CodEmpresa = codEmpresa;

      return emp;
    }



    #endregion

    #region Metodos Genericos

    public void CarregaCombos()
    {
      ListarTipoPessoa();
      ListarRamoAtividade();
      ListarTipoContato();
      ListarTipoEndereco();
    }

    private void ListarTipoPessoa()
    {
      TipoPessoaViewModels tipoPessoa = new TipoPessoaViewModels();

      tipoPessoa.lstTipoPessoa = _appTipoPessoa.ListarTipoPessoa();

      ViewBag.ViewTipoPessoa = new SelectList(tipoPessoa.lstTipoPessoa, "CodTipoPessoa", "Descricao");
    }

    private void ListarRamoAtividade()
    {
      var lstViewRamoAtividade = _appRamoAtividade.ListarRamoAtividade();

      RamoAtividadeViewModels ramoAtividade = new RamoAtividadeViewModels();

      ramoAtividade.lstRamoAtividade = lstViewRamoAtividade;

      ViewBag.ViewRamoAtividades = new SelectList(ramoAtividade.lstRamoAtividade, "CodRamoAtividade", "Descricao");
    }

    private void ListarTipoContato()
    {
      TipoContatoViewModels tipoContato = new TipoContatoViewModels();

      tipoContato.lstTipoContatos = _appContato.ListarTipoContato();

      ViewBag.ViewTipoContato = new SelectList(tipoContato.lstTipoContatos, "CodTipoContato", "Descricao");
    }

    private void ListarTipoEndereco()
    {
      TipoEnderecoViewModels tipoEndereco = new TipoEnderecoViewModels();

      tipoEndereco.lstTipoEndereco = _appEndereco.ListarTipoEndereco();

      ViewBag.ViewTipoEndereco = new SelectList(tipoEndereco.lstTipoEndereco, "CodTipoEndereco", "Descricao");
    }

    /// <summary>
    /// retira mascara CPF / CNPJ / Inscricao Estadual e Muncipal
    /// </summary>
    /// <returns></returns>
    public string RetiraMascara(string campo)
    {
      return campo.Replace(".", "").Replace("/", "").Replace("-", "").Replace("(", "").Replace(")", "").Trim();
    }




    #endregion


  }
}
