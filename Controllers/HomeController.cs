using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MiPrimerAppMVC.Models;

namespace MiPrimerAppMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {

        //Viewdata es un diccionario que permite pasar datos desde el controlador a la vista
        //es una forma de pasar datos sin necesidad de crear un modelo
        ViewData["Mensaje2"] = "Este es un mensaje de prueba desde el controlador con ViewData.";

        //viewbag es un objeto que permite pasar datos desde el controlador a la vista
        //es una forma de pasar datos sin necesidad de crear un modelo
        ViewBag.Mensaje = "Este es un mensaje de prueba desde el controlador con ViewBag.";

        ViewBag.Contador = 10;
        ViewData["Contador2"] = 20;
        return View();
    }

    public IActionResult Privacy()
    {

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult VistaDemo()
    {
        //Titulo de la vista
       // ViewBag.Title = "Vista Demo";
        return View();
    }
}
