using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SIS.Tech.Models;

namespace SIS.Tech.Controllers;

public class ChartsController : Controller
{
  public IActionResult Apex() => View();
  public IActionResult Chartjs() => View();
}
