namespace CoreEscuela.Entidades.PruebaCast
{
    public class Sala
    {
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la sala
        /// </summary>      
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el índice de ocupación de sala (Turnos es espera / Máximo de ocupación)
        /// </summary>
        public float IndiceOcupacion { get; set; }

        /// <summary>
        /// Obtiene o establece la cantidad máxima de turnos que soporta la sala
        /// </summary>
        public int MaximoOcupacion { get; set; }      

        /// <summary>
        /// Obtiene o establece la descripción
        /// </summary>       
        public string Descripcion { get; set; }

        /// <summary>
        /// Obtiene o establece el costo fijo
        /// </summary>
        public double CostoFijo { get; set; }

        /// <summary>
        /// Obtiene o establece la cantidad de turnos actuales en la sala
        /// </summary>  
        public int OcupacionActual { get; set; }
    }
}