using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SIS.Tech.Models;

namespace SIS.Tech.Controllers;

public class ModalsController : Controller
{
  public IActionResult Examples() => View();
}
