namespace HolaMundoMVC.Models.ModelosProyectoEscuela
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using HolaMundoMVC.Models.DataAnnotationsPersonalizados;
    using HolaMundoMVC.Models.ModelosProyectoEscuela.ObjetosBaseEInterfaces;
    using static HolaMundoMVC.Models.ModelosProyectoEscuela.Enumeradores.TiposEntesSistema;

    public class Curso : ObjetoBase
    {
        [Required(ErrorMessage = "Campo nombre requerido")] // Campo requerido
        [StringLength(8)] // Longitud maxima del nombre
        [MinLength(3)] // Longitud minima del nombre
        ///[DivisibleEntreAtributos(ErrorMessage = "Correo no valido")]
        public override string Nombre { get; set; } // override: Al ser este un campo virtual de la clase padre, es necesario indicar que vamos a sobre escribir su comportamiento, para eso usamos: override
        public string EscuelaId { get; set; } /// Autoaticamente el motor, por convención infiere que me estoy relacionando al 'Id' de la 'Escuela'
        public Escuela Escuela { get; set; }
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumnos { get; set; }

        [Display(Prompt = "Dirección correspondencia", Name = "Address")] // Prompt => Marca de agua que describe el contenido en una caja de texto, Name => nombrea  mostrar en un label que mapea el campo (Eje:<label asp-for="Dirección"></label>)
        [Required(ErrorMessage = "Dirección requerida")] // Campo requerido, con mensaje de exepción personalizado
        [MinLength(5, ErrorMessage = "Longitud minima requerida es 5")] // Longitud minima del nombre
        public string Dirección { get; set; }

    }
}