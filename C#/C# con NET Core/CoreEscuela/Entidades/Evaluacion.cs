namespace CoreEscuela.Entidades
{
    using System;
    
    public class Evaluacion: EnteSistema
    {
         public Alumno Alumno { get; set; }

         public Asignatura Asignatura { get; set; }

         public float Nota { get; set; }

        public Evaluacion() => (this.Id) = (Guid.NewGuid().ToString());   
    }
}