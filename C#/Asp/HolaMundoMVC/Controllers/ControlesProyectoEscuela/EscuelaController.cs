namespace HolaMundoMVC.Controllers
{
    using System.Linq;
    using HolaMundoMVC.Models.ContextoTablasBD;
    using HolaMundoMVC.Models.ModelosProyectoEscuela;
    using Microsoft.AspNetCore.Mvc;
    using static HolaMundoMVC.Models.ModelosProyectoEscuela.Enumeradores.TiposEntesSistema;

    public class EscuelaController: Controller
    {
        /// Agregamos un método donde definimos la acción como respuesta a una solicitud Index a nuestro controlador 
        /// Esta acción permitira al controlador enlazarse con la vista: Views/Escuela/Index
        /// El nombre del método debe ser igual al nombre de la vista

        /* PRACTICA
        public IActionResult Index()
        {
            var escuela = new Escuela();
            escuela.AnioFundacion = 2020;
            escuela.Nombre = "Platzy";

            // Otra forma de enviar información a la vista es usando Viewbag, 
            // que es un diccionario que me permite guardar objetos de forma dinámica
            ViewBag.ObjetoDinamico = "Dato dinámico de la escuela";

            // La acción a ejecutar por nuestro controlador es redireccionar a la vista: Index
            // Por eso es muy importante que el nombre del método sea igual al nombre de la vista.
            return View("Practica/Index", escuela);
            // ("Practica/Index", escuela) => es la forma de especificar la vista que esta dentro de alguna carpeta especifica, y el objeto con el que va a trabajar
        }
        */

        /* PRACTICA 2
        public IActionResult Index()
        {
            var escuela = new Escuela();
            escuela.AnioDeCreacion = 2020;
            escuela.Nombre = "Platzy";
            escuela.Direccion = "Clle 5 # 6-8";
            escuela.Ciudad = "Bogota";
            escuela.Pais = "Colombia";
            escuela.TipoEscuela = TiposEscuela.Secundaria;
            
            return View("Proyecto/Index", escuela);
        }
        */

        private ContextoBDEscuela _contextoBD { get; set; }

        public EscuelaController(ContextoBDEscuela contextoBD)
        {
            this._contextoBD = contextoBD;
        }
        
        public IActionResult Index()
        {
            var escuela = this._contextoBD.EscuelasBD.FirstOrDefault();            
            return View("Proyecto/Index", escuela);
        }

        
    }
}