namespace HolaMundoMVC.Controllers.ControlesProyectoEscuela
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using HolaMundoMVC.Models.ContextoTablasBD;
    using HolaMundoMVC.Models.ModelosProyectoEscuela;
    using Microsoft.AspNetCore.Mvc;

    public class AlumnoController : Controller
    {

        private ContextoBDEscuela _contextoBD { get; set; }

        public AlumnoController(ContextoBDEscuela contextoBD)
        {
            this._contextoBD = contextoBD;
        }      
        

        /// https://localhost:5001/Alumno/Index 
        /// Haremos lo mismo que la Accion anterior pero usando:
        /// Enrutamiento por atributos: [Route("NombreControl/NombreAccion/{NombreParametro}")]
        /// Podemos configurar la cantidad de enrutamientos que queramos para ejecutar esta acción (Siempre y cuendo se hagan las validaciónes correspondientes)
        [Route("Alumno/Index")]
        [Route("Alumno/Index/{idAlunmo}")]
        public IActionResult Index(string idAlunmo)
        {
            if (!string.IsNullOrWhiteSpace(idAlunmo))
            {
                /// Eje: localhost:5001/Alumno/Index/77882204-e3da-4ba6-9a5c-df8b720f397e
                var alumno = this._contextoBD.AlumnosBD.Where(asig => asig.Id == idAlunmo).FirstOrDefault();
                return View("Index", alumno);
            }
            else
            {
                /// Si el idAsiganatura es nulo o esta en blanco retornamos todas las asignaturas
                /// Eje: localhost:5001/Alumno/Index
                 return View("ListarAlumnos", this._contextoBD.AlumnosBD);
            }
            
        }

        /// https://localhost:5001/Alumno/ListarAlumnos
        public IActionResult ListarAlumnos()
        {
            ViewBag.Fecha = DateTime.Now;
            return View("ListarAlumnos", this._contextoBD.AlumnosBD);
        }

        ///
        ///
        private List<Alumno> GenerarAlumnosAlAzar(int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };

            return listaAlumnos.OrderBy((al) => al.Id).Take(cantidad).ToList();
        }
    }
}