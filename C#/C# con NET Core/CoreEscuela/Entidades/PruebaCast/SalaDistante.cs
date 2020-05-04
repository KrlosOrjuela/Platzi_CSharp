namespace CoreEscuela.Entidades.PruebaCast
{
    using System;
    
    public class SalaDistante:Sala
    {
          /// <summary>
        /// Obtiene o establece el tiempo en seg de desplazamiento
        /// </summary>
        public TimeSpan TiempoDeDesplazamiento { get; set; }

        /// <summary>
        /// Obtiene o establece la distancia entre un ente origen y la sala
        /// </summary>
        public decimal DistanciaDeDesplazamiento { get; set; }

        /// <summary>
        /// Obtiene o establece el id del ente origen
        /// </summary>
        public int IdOrigen { get; set; }
    }
}