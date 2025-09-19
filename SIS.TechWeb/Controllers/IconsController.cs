using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SIS.Tech.Models;

namespace SIS.Tech.Controllers;

public class IconsController : Controller
{
  public IActionResult Tabler() => View();
  public IActionResult FontAwesome() => View();
}
