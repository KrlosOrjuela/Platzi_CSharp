
namespace HolaMundoMVC.Models.ModelosProyectoEscuela
{
    using System.Collections.Generic;
    using HolaMundoMVC.Models.ModelosProyectoEscuela.ObjetosBaseEInterfaces;
    
    public class Asignatura : ObjetoBase
    {
        public string CursoId { get; set; }
        public Curso Curso { get; set; }

        public List<Evaluacion> Evaluaciones { get; set; }
    }
}