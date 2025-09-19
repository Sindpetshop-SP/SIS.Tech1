using Microsoft.AspNetCore.Mvc;

namespace SIS.Tech.Controllers.System
{
  public class ErrorController : BaseController
  {
    public IActionResult Index()
    {
      

      if (!VerificaSession())
      {
        return RedirectToAction("Login", "Auth");
      }

      return View();
    }

    public IActionResult MiscComingSoon()
    {
      

      if (!VerificaSession())
      {
        return RedirectToAction("Login", "Auth");
      }

      return View();
    }

    public IActionResult MiscError()
    {

      

      if (!VerificaSession())
      {
        return RedirectToAction("Login", "Auth");
      }

      return View();
    }

    public IActionResult MiscNotAuthorized()
    {
      

      if (!VerificaSession())
      {
        return RedirectToAction("Login", "Auth");
      }

      return View();
    }

    public IActionResult MiscUnderMaintenance()
    {
      

      if (!VerificaSession())
      {
        return RedirectToAction("Login", "Auth");
      }

      return View();
    }

  }
}
