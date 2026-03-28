using Microsoft.AspNetCore.Mvc;
using PortalCampanas.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PortalCampanas.Controllers
{
    public class CampanasController : Controller
    {
        public IActionResult Index(string categoria, string estado)
        {
            var campanas = new List<Campania>
            {
                new Campania { Id=1, Nombre="Promo Electro", Categoria="Electro", Estado="Vigente", Canal="Web", DescuentoPct=20, FechaInicio=DateTime.Now.AddDays(-5), FechaFin=DateTime.Now.AddDays(5) },
                new Campania { Id=2, Nombre="Hogar Sale", Categoria="Hogar", Estado="Próxima", Canal="App", DescuentoPct=15, FechaInicio=DateTime.Now.AddDays(2), FechaFin=DateTime.Now.AddDays(10) },
                new Campania { Id=3, Nombre="Moda Flash", Categoria="Moda", Estado="Finalizada", Canal="Tienda", DescuentoPct=30, FechaInicio=DateTime.Now.AddDays(-10), FechaFin=DateTime.Now.AddDays(-2) }
            };

            if (!string.IsNullOrEmpty(categoria))
            {
                campanas = campanas.Where(c => c.Categoria == categoria).ToList();
            }

            if (!string.IsNullOrEmpty(estado))
            {
                campanas = campanas.Where(c => c.Estado == estado).ToList();
            }

            return View(campanas);
        }

        public IActionResult Detalle(int id)
        {
            var campanas = new List<Campania>
            {
                new Campania { Id=1, Nombre="Promo Electro", Categoria="Electro", Estado="Vigente", Canal="Web", DescuentoPct=20, FechaInicio=DateTime.Now.AddDays(-5), FechaFin=DateTime.Now.AddDays(5), Descripcion="Descuentos en electrodomésticos" },
                new Campania { Id=2, Nombre="Hogar Sale", Categoria="Hogar", Estado="Próxima", Canal="App", DescuentoPct=15, FechaInicio=DateTime.Now.AddDays(2), FechaFin=DateTime.Now.AddDays(10), Descripcion="Ofertas en hogar" },
                new Campania { Id=3, Nombre="Moda Flash", Categoria="Moda", Estado="Finalizada", Canal="Tienda", DescuentoPct=30, FechaInicio=DateTime.Now.AddDays(-10), FechaFin=DateTime.Now.AddDays(-2), Descripcion="Liquidación moda" }
            };

            var campania = campanas.FirstOrDefault(c => c.Id == id);

            return View(campania);
        }

        public IActionResult Resumen()
        {
            var campanas = new List<Campania>
            {
                new Campania { Id=1, Nombre="CyberWow Electro", Categoria="Electro", Estado="Vigente", Canal="Web", DescuentoPct=30, FechaInicio=DateTime.Parse("2026-03-15"), FechaFin=DateTime.Parse("2026-03-30"), Descripcion="Ofertas en productos electrónicos" },
                new Campania { Id=2, Nombre="Renueva tu Hogar", Categoria="Hogar", Estado="Vigente", Canal="Tienda", DescuentoPct=25, FechaInicio=DateTime.Parse("2026-03-01"), FechaFin=DateTime.Parse("2026-04-01"), Descripcion="Renueva tu hogar con descuentos" },
                new Campania { Id=3, Nombre="Fashion Week Lima", Categoria="Moda", Estado="Próxima", Canal="App", DescuentoPct=40, FechaInicio=DateTime.Parse("2026-04-10"), FechaFin=DateTime.Parse("2026-04-20"), Descripcion="Moda en tendencia" },
                new Campania { Id=4, Nombre="Tech Days", Categoria="Tecnología", Estado="Próxima", Canal="Web", DescuentoPct=35, FechaInicio=DateTime.Parse("2026-05-01"), FechaFin=DateTime.Parse("2026-05-10"), Descripcion="Tecnología con descuentos" },
                new Campania { Id=5, Nombre="Liquidación Verano", Categoria="Moda", Estado="Finalizada", Canal="Tienda", DescuentoPct=50, FechaInicio=DateTime.Parse("2026-01-10"), FechaFin=DateTime.Parse("2026-01-20"), Descripcion="Liquidación de verano" },
                new Campania { Id=6, Nombre="Electro Fiestas Patrias", Categoria="Electro", Estado="Finalizada", Canal="Web", DescuentoPct=20, FechaInicio=DateTime.Parse("2026-01-15"), FechaFin=DateTime.Parse("2026-01-30"), Descripcion="Ofertas por fiestas patrias" },
                new Campania { Id=7, Nombre="Smart Home Fest", Categoria="Tecnología", Estado="Vigente", Canal="App", DescuentoPct=15, FechaInicio=DateTime.Parse("2026-03-20"), FechaFin=DateTime.Parse("2026-04-05"), Descripcion="Hogar inteligente" },
                new Campania { Id=8, Nombre="Deco Primavera", Categoria="Hogar", Estado="Próxima", Canal="Tienda", DescuentoPct=20, FechaInicio=DateTime.Parse("2026-09-01"), FechaFin=DateTime.Parse("2026-09-15"), Descripcion="Decoración de primavera" }
            };

            var total = campanas.Count;
            var vigentes = campanas.Count(c => c.Estado == "Vigente");
            var proximas = campanas.Count(c => c.Estado == "Próxima");
            var promedio = campanas.Average(c => c.DescuentoPct);

            var web = campanas.Count(c => c.Canal == "Web");
            var app = campanas.Count(c => c.Canal == "App");
            var tienda = campanas.Count(c => c.Canal == "Tienda");

            var resumen = new
            {
                Total = total,
                Vigentes = vigentes,
                Proximas = proximas,
                Promedio = Math.Round(promedio, 2),
                Web = web,
                App = app,
                Tienda = tienda
            };

            return View(resumen);
        }
    }
}