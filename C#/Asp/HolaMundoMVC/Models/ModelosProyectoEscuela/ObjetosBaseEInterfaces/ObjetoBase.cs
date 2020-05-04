namespace HolaMundoMVC.Models.ModelosProyectoEscuela.ObjetosBaseEInterfaces
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class ObjetoBase
    {
        [Required] /// Este atributo de validación, Valida que el campo no sea nulo (que sea necesaria su asignación)
        public string Id { get; private set; }

        /// virtual: Define que le campo pude ser re-escrito por la clases hijo
        public virtual string Nombre { get; set; }

        public ObjetoBase() { Id = Guid.NewGuid().ToString(); }

        public override string ToString()
        {
            return $"{Nombre},{Id}";
        }
    }
}