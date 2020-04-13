namespace CoreEscuela.Entidades
{
    using System;
    
    public class Alumno: EnteSistema
    {
        public Alumno() => (this.Id) = (Guid.NewGuid().ToString());   
    }
}