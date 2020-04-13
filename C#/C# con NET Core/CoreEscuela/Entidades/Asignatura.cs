namespace CoreEscuela.Entidades
{
    using System;
    
    public class Asignatura: EnteSistema
    {
        public Asignatura() => (this.Id) = (Guid.NewGuid().ToString());   
    }
}