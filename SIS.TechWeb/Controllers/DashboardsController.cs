using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SIS.Tech.Models;

namespace SIS.Tech.Controllers;

public class DashboardsController : Controller
{
  public IActionResult Index() => View();
  public IActionResult CRM() => View();
}
