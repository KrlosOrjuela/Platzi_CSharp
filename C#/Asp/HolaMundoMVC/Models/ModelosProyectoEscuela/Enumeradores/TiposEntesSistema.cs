namespace HolaMundoMVC.Models.ModelosProyectoEscuela.Enumeradores
{
    public class TiposEntesSistema
    {
        public enum TiposEscuela
        {
            Primaria, 
            Secundaria, 
            PreEscolar
        }

         public enum TiposJornada
        {
            Mañana, 
            Tarde, 
            Noche
        }

        public enum LlaveDiccionario
        {
            Escuela ,
            Curso,
            Alumno,
            Asignatura,
            Evaluación
        }
    }
}