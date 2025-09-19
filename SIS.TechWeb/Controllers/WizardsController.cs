using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SIS.Tech.Models;

namespace SIS.Tech.Controllers;

public class WizardsController : Controller
{
  public IActionResult Checkout() => View();
  public IActionResult CreateDeal() => View();
  public IActionResult PropertyListing() => View();
}
