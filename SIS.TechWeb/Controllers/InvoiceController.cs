using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SIS.Tech.Models;

namespace SIS.Tech.Controllers;

public class InvoiceController : Controller
{
  public IActionResult Add() => View();
  public IActionResult List() => View();
  public IActionResult Edit() => View();
  public IActionResult Preview() => View();
  public IActionResult Print() => View();
}
