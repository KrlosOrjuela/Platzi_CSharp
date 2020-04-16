namespace CoreEscuela.Entidades
{
    using System.Collections.Generic;
    using CoreEscuela.Entidades.ClasesPadre;

    public class Escuela: EnteSistema
    {
        /// Obtiene o establece el año de creación de la escuela 
        /// Trabajamos con el encapsulamiento integrado en c#: {get; set;} (Es el mismo que hacemos con "nombre")
        public Escuela(int anioCreacion, TiposPais pais, TiposCiudad ciudad, TiposEscuela tipoEscuela) 
        {
            this.AnioCreacion = anioCreacion;
                this.Pais = pais;
                this.Ciudad = ciudad;
                this.TipoEscuela = tipoEscuela;
               
        }
                public int AnioCreacion {get; set;}

        /// Obtiene o establece el pais de la escuela 
        public TiposPais Pais { get; set; }

        /// Obtiene o establece la ciudad de la escuela 
        public TiposCiudad Ciudad { get; set; }
        public TiposEscuela TipoEscuela { get; set; }
        public List<Curso> Cursos { get; set; }

        /// Constructor Forma 1
        public Escuela(string nombre, int anioCreacion)
        {
            this.Nombre = nombre;
            this.AnioCreacion = anioCreacion;
        }

        /// Contructor Forma 2
        public Escuela(string nombre) => (this.Nombre) = (nombre);

        /// Sobre-escrivimos el comportamiento del metodo "ToString" en la entidad
        public override string ToString()
        {
            return $"Tipo: {this.TipoEscuela}, Pais: {this.Pais}, Ciudad: {this.Ciudad}";
        }

        /// Constructor Forma 3: Parametros opcionales 
        public Escuela(string nombre, int anioCreacion, TiposEscuela tipo, TiposPais pais = TiposPais.Colombia, TiposCiudad ciudad = TiposCiudad.Otro)
        {
            (this.Nombre, this.AnioCreacion) = (nombre, anioCreacion);
            this.TipoEscuela = tipo;
            this.Pais = pais;
            this.Ciudad = ciudad;
        }       

    }

}