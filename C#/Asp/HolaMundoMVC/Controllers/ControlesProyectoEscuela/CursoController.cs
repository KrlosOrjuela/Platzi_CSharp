namespace HolaMundoMVC.Controllers.ControlesProyectoEscuela
{
    using System.Linq;
    using HolaMundoMVC.Models.ContextoTablasBD;
    using HolaMundoMVC.Models.ModelosProyectoEscuela;
    using Microsoft.AspNetCore.Mvc;

    public class CursoController : Controller
    {

        private ContextoBDEscuela _contextoBD { get; set; }

        public CursoController(ContextoBDEscuela contextoBD)
        {
            this._contextoBD = contextoBD;
        }

        /// https://localhost:5001/Curso/Index 
        /// Haremos lo mismo que la Accion anterior pero usando:
        /// Enrutamiento por atributos: [Route("NombreControl/NombreAccion/{NombreParametro}")]
        /// Podemos configurar la cantidad de enrutamientos que queramos para ejecutar esta acción (Siempre y cuendo se hagan las validaciónes correspondientes)
        [Route("Curso")]
        [Route("Curso/Index")]
        [Route("Curso/Index/{idCurso}")]
        public IActionResult Index(string idCurso)
        {
            if (!string.IsNullOrWhiteSpace(idCurso))
            {
                /// Eje: localhost:5001/Curso/Index/77882204-e3da-4ba6-9a5c-df8b720f397e
                var curso = this._contextoBD.CursosBD.Where(asig => asig.Id == idCurso).FirstOrDefault();
                return View(curso);
            }
            else
            {
                /// Si el idAsiganatura es nulo o esta en blanco retornamos todas las asignaturas
                /// Eje: localhost:5001/Curso/Index
                return View("ListarCursos", this._contextoBD.CursosBD);
            }

        }

        /// Accion que muestra la vista para crera un curso
        public IActionResult CrearCurso()
        {
            return View("FrmCreate");
        }


        /// Esta acción se llamara cuando se lancé un evento POST desde la vista (http) (Eje: Un boton dentro de un formulario con método POST)
        [HttpPost]
        public IActionResult CrearCurso(Curso cursoACrear)
        {
            if (ModelState.IsValid) /// Forma de validar que los campos marcados como requeridos (en el modelo Curso) esten correctamente diligenciados
            {
                var escuela = this._contextoBD.EscuelasBD.FirstOrDefault();

                cursoACrear.EscuelaId = escuela.Id;
                this._contextoBD.Add(cursoACrear);
                this._contextoBD.SaveChanges(); // Guardamos todos los cambios
                ViewBag.Notificacion = "Curso creado exitosamente";
                return View("Index", cursoACrear);
            }
            else
            {
                return View("FrmCreate", cursoACrear); /// Mostramos nuevamente la vista, mapeando los datos ingresados, junto con los que faltan por ingresar
            }            
        }
    }
}