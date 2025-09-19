using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SIS.Tech.Models;

namespace SIS.Tech.Controllers;

public class AccessController : Controller
{
public IActionResult Permission() => View();
public IActionResult Roles() => View();
}
