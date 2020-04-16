namespace CoreEscuela.Entidades
{
    using System;
    using System.Collections.Generic;
    using CoreEscuela.Entidades.ClasesPadre;

    public class Curso: EnteSistema
    {
        public TiposJornada TiposDeJornada { get; set; }    

        public List<Asignatura> Asignaturas { get; set; }

        public List<Alumno> Alumnos { get; set; }

        public List<Evaluacion> Evaluaciones { get; set; }

        
     
    }
}