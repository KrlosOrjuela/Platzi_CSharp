

namespace HolaMundoMVC.Models.ModelosProyectoEscuela
{
    using System;
using System.Collections.Generic;
    using HolaMundoMVC.Models.ModelosProyectoEscuela.ObjetosBaseEInterfaces;
    using static HolaMundoMVC.Models.ModelosProyectoEscuela.Enumeradores.TiposEntesSistema;

    public class Escuela: ObjetoBase
    {
        public int AnioDeCreacion { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public TiposEscuela TipoEscuela { get; set; }
        public List<Curso> Cursos { get; set; }
        
        public override string ToString()
        {
            return $"Nombre: \"{Nombre}\", Tipo: {TipoEscuela} {System.Environment.NewLine} Pais: {Pais}, Ciudad:{Ciudad}";
        }
      
    }
}
