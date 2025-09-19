using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SIS.Tech.Models;

namespace SIS.Tech.Controllers;

public class FormLayoutsController : Controller
{
public IActionResult Horizontal() => View();
public IActionResult Vertical() => View();
public IActionResult Sticky() => View();
}
