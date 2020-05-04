namespace HolaMundoMVC.Models.ModelosProyectoEscuela
{
    using HolaMundoMVC.Models.ModelosProyectoEscuela.ObjetosBaseEInterfaces;
    public class Evaluacion: ObjetoBase
    {
        public string AlumnoId { get; set; }
        public Alumno Alumno { get; set; }
        public string AsignaturaId { get; set; }
        public Asignatura Asignatura  { get; set; }
        public float Nota { get; set; }

        public override string ToString()
        {
            return $"{Nota}, {Alumno.Nombre}, {Asignatura.Nombre}";
        }
    }
}