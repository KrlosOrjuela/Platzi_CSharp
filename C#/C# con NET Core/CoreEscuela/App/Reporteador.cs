namespace CoreEscuela.App
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using CoreEscuela.Entidades;
    using CoreEscuela.Entidades.ClasesPadre;

    public class Reporteador
    {
        private Dictionary<LlaveDiccionario, IEnumerable<EnteSistema>> _dictionary;

        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<EnteSistema>> dictionary)
        {
            if(_dictionary == null)
            {
                throw new ArgumentNullException(nameof(_dictionary));
            }

            this._dictionary = dictionary;
        }

        public IEnumerable<Evaluacion> GetListaEvaluaciones()
        {
            if(this._dictionary?.Count > 0)
            {
                var lista = _dictionary.GetValueOrDefault(LlaveDiccionario.Evaluación);
                return lista.Cast<Evaluacion>();
            }

            return null;
            
        }
    }
}