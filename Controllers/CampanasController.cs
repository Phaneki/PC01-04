using Microsoft.AspNetCore.Mvc;
using PortalCampanas.Models;
using System;
using System.Collections.Generic;

namespace PortalCampanas.Controllers
{
    public class CampanasController : Controller
    {
        public IActionResult Index()
        {
            var campanas = new List<Campania>
            {
                new Campania { Id=1, Nombre="Promo Electro", Categoria="Electro", Estado="Vigente", Canal="Web", DescuentoPct=20, FechaInicio=DateTime.Now.AddDays(-5), FechaFin=DateTime.Now.AddDays(5) },
                new Campania { Id=2, Nombre="Hogar Sale", Categoria="Hogar", Estado="Próxima", Canal="App", DescuentoPct=15, FechaInicio=DateTime.Now.AddDays(2), FechaFin=DateTime.Now.AddDays(10) },
                new Campania { Id=3, Nombre="Moda Flash", Categoria="Moda", Estado="Finalizada", Canal="Tienda", DescuentoPct=30, FechaInicio=DateTime.Now.AddDays(-10), FechaFin=DateTime.Now.AddDays(-2) }
            };

            return View(campanas);
        }
    }
}