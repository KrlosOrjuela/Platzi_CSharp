namespace CoreEscuela.Entidades.ClasesPadre
{
    using System;

    /// la palabra clave **abstract** define que dicha clase solamente pueda ser heredada, pero nunca instanciada.
    public abstract class EnteSistema
    {
        public string Id { get; set; }

         public string Nombre { get; set; }

         public EnteSistema() => (this.Id) = (Guid.NewGuid().ToString());      

        /// Esto me permite, que en el moemtnop de depuración, al revisar el objeto, pueda ver rapidamente estos datos retornados 
        public override string ToString()
        {
            return $"{this.Nombre}, {this.Id}";
        }   
    }    
}