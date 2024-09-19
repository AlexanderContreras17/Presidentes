using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Unidad2Ejercicio2.Models.Entities;
using Unidad2Ejercicio2.Models.ViewModels;

namespace Unidad2Ejercicio2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            PresidentesContext context = new();
            IndexViewModel vm = new();

            var datos = context.Presidente.OrderBy(x => x.InicioGobierno);
            vm.Presidentes = datos.Select(x => new PresidenteModel
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Periodo = x.InicioGobierno.Year + "-"
                +( x.TerminoGobierno != null ? x.TerminoGobierno.Value.Year.ToString():"")
            }); ;
            return View(vm);
        }
        public IActionResult Biografia(string id)
        {
            PresidentesContext context = new();
            id = id.Replace("-", "");
            var presidente = context.Presidente.Include(x => x.IdEstadoRepublicaNavigation).
                Include(x => x.IdPartidoPoliticoNavigation).Where(x => x.Nombre.ToLower() == id.ToLower()).FirstOrDefault();

            if (presidente == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                BiografiaViewModel vm = new()
                {
                    id = presidente.Id,
                    Nombre = presidente.Nombre,
                    Biografia = presidente.Biografia,
                    CiudadNacimiento = presidente.CiudadNacimiento ?? "Desconocido", //null-coalescence operator
                    EstadoNacimieto =
                    presidente.IdEstadoRepublicaNavigation == null ? "" : presidente.IdEstadoRepublicaNavigation.Nombre,
                    FechaFalleciminto =
                    presidente.FechaFallecimiento == null ? "" : presidente.FechaFallecimiento.Value.ToLongDateString(),
                    FechaNacimiento =
                    presidente.FechaNacimiento == null ? "" : presidente.FechaNacimiento.Value.ToLongDateString(),
                    FinGobierno =
                    presidente.TerminoGobierno == null ? "" : presidente.TerminoGobierno.Value.ToLongDateString(),
                    InicioGobierno = presidente.InicioGobierno.ToLongDateString(),
                    IdPartido = presidente.IdPartidoPolitico,
                    NombrePartido = presidente.IdPartidoPoliticoNavigation.Nombre,
                    Ocupacion = presidente.Ocupacion ?? "Desconocido"

                };


                return View(vm);
            }

        }
    }
    }

