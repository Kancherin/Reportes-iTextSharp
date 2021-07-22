using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reportes_iTextSharp.Web.Models;
using Reportes_iTextSharp.Web.Reports;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Reportes_iTextSharp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult PrintPersona(int param)
        {
            List<Persona> personas = new List<Persona>();

            for (int i = 1; i < 100; i++)
            {
                Persona persona = new Persona();
                persona.Id = i;
                persona.Nombre = $"Persona {i}";
                persona.Direccion = $"Calle {i} N° {i + 100}";
                personas.Add(persona);
            }

            PersonaReport rpt = new PersonaReport(_webHostEnvironment);

            return File(rpt.Report(personas), "application/pdf");
        }

    }
}
