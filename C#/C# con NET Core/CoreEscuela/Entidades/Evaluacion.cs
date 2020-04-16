namespace CoreEscuela.Entidades
{
    using System;
    using CoreEscuela.Entidades.ClasesPadre;
    
    public class Evaluacion: EnteSistema
    {
         public Alumno Alumno { get; set; }

         public Asignatura Asignatura { get; set; }

         public float Nota { get; set; } 


        /// Esto me permite, que en el moemtnop de depuración, al revisar el objeto, pueda ver rapidamente estos datos retornados 
        public override string ToString()
        {
            return $"{this.Nota}, {this.Alumno.Nombre}, {this.Asignatura.Nombre}";
        } 
    }
    
}