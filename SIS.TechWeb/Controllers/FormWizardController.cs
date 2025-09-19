using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SIS.Tech.Models;

namespace SIS.Tech.Controllers;

public class FormWizardController : Controller
{
public IActionResult Icons() => View();
public IActionResult Numbered() => View();
}
