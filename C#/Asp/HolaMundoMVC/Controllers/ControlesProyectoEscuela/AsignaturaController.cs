namespace HolaMundoMVC.Controllers.ControlesPractica
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using HolaMundoMVC.Models.ContextoTablasBD;
    using HolaMundoMVC.Models.ModelosProyectoEscuela;
    using Microsoft.AspNetCore.Mvc;

    public class AsignaturaController : Controller
    {
          private ContextoBDEscuela _contextoBD { get; set; }

        public AsignaturaController(ContextoBDEscuela contextoBD)
        {
            this._contextoBD = contextoBD;
        }

        /// https://localhost:5001/Asignatura/Index 
        public IActionResult Index()
        {
            return View("Index", this._contextoBD.AsignaturasBD.FirstOrDefault());
        }

        /// El parametro se debe llamar Id, por lo configurado en el archivo Startup:
        ///  "{controller=Escuela}/{action=Index}/{id?}"
        public IActionResult AsignaturaXId(string id)
        {
            var asignatura = this._contextoBD.AsignaturasBD.Where(asig => asig.Id == id).FirstOrDefault();
            return View("Index", asignatura);
        }

        /// Haremos lo mismo que la Accion anterior pero usando:
        /// Enrutamiento por atributos: [Route("NombreControl/NombreAccion/{NombreParametro}")]
        /// Podemos configurar la cantidad de enrutamientos que queramos para ejecutar esta acción (Siempre y cuendo se hagan las validaciónes correspondientes)
        [Route("Asignatura/AsignaturaXIdentificador")]
        [Route("Asignatura/AsignaturaXIdentificador/{idAsiganatura}")]
        public IActionResult AsignaturaXIdentificador(string idAsiganatura)
        {
            if (!string.IsNullOrWhiteSpace(idAsiganatura))
            {
                /// Eje: https://localhost:5001/Asignatura/AsignaturaXIdentificador/77882204-e3da-4ba6-9a5c-df8b720f397e
                var asignatura = this._contextoBD.AsignaturasBD.Where(asig => asig.Id == idAsiganatura).FirstOrDefault();
                return View("Index", asignatura);
            }
            else
            {
                /// Si el idAsiganatura es nulo o esta en blanco retornamos todas las asignaturas
                /// Eje: https://localhost:5001/Asignatura/AsignaturaXIdentificador
                return View("ListaAsignaturas", this._contextoBD.AsignaturasBD);
            }
            
        }

        /// https://localhost:5001/Asignatura/ListarAsisgnaturas
        public IActionResult ListarAsisgnaturas()
        {            
            /*var listaAsignaturas = new List<Asignatura>(){
                new Asignatura{Nombre="Matemáticas"} ,
                new Asignatura{Nombre="Física"},
                new Asignatura{Nombre="Programación"},
                new Asignatura{Nombre="Ciencias Naturales"}
            };*/

            ViewBag.Fecha = DateTime.Now;
            return View("ListaAsignaturas", this._contextoBD.AsignaturasBD);
        }
    }
}