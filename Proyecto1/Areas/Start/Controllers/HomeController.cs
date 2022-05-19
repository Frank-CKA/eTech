using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Proyecto1.Data.Repositorio.IRepositorio;
using Proyecto1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Controllers
{
    [Area("Start")] //Setup de home controller y views - Sábado 14
    public class HomeController : Controller //Cambio de HomeController - Martes 17
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnidadTrabajo _unidadTrabajo;

        public HomeController(ILogger<HomeController> logger, IUnidadTrabajo unidadTrabajo)
        {
            _logger = logger;
            _unidadTrabajo = unidadTrabajo;
        }

        public IActionResult Index()
        {
            IEnumerable<Producto> productoLista =
                 _unidadTrabajo.Producto.ObtenerTodos(IncluirPropiedades: "Categoria,Marca");
            return View(productoLista);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new Proyecto1.Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
