using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SIS.Tech.Models;

namespace SIS.Tech.Controllers;

public class MapsController : Controller
{
  public IActionResult Leaflet() => View();
}
