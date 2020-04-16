namespace CoreEscuela.App
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CoreEscuela.Entidades;

    /// la palabra clave **sealed** define que dicha clase no puede ser heredada, pero si instanciada.
    public sealed class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine() { }

        public void Inicializar()
        {
            this.Escuela = new Escuela(nombre: "Platzi C# ",
                                       anioCreacion: 2020,
                                       TiposEscuela.Primaria,
                                       TiposPais.Colombia,
                                       ciudad: TiposCiudad.Bogota);

            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();
        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>();
            this.Escuela.Cursos.Add(new Curso() { Nombre = "101", TiposDeJornada = TiposJornada.Manana });
            this.Escuela.Cursos.Add(new Curso() { Nombre = "201", TiposDeJornada = TiposJornada.Manana });
            this.Escuela.Cursos.Add(new Curso() { Nombre = "301", TiposDeJornada = TiposJornada.Noche });
            this.Escuela.Cursos.Add(new Curso() { Nombre = "401", TiposDeJornada = TiposJornada.Noche });
            this.Escuela.Cursos.Add(new Curso() { Nombre = "501", TiposDeJornada = TiposJornada.Noche });
            this.Escuela.Cursos.Add(new Curso() { Nombre = "601", TiposDeJornada = TiposJornada.Manana });

            Random rnd = new Random();

            foreach (var c in Escuela.Cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                c.Alumnos = GenerarAlumnosAlAzar(cantRandom);
            }
        }

        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                var listaAsignaturas = new List<Asignatura>(){
                    new Asignatura{Nombre="Matemáticas"} ,
                    new Asignatura{Nombre="Educación Física"},
                    new Asignatura{Nombre="Castellano"},
                    new Asignatura{Nombre="Ciencias Naturales"}
                };
                curso.Asignaturas = listaAsignaturas;
            }
        }

        private void CargarEvaluaciones()
        {
            foreach (var curso in this.Escuela.Cursos)
            {
                curso.Evaluaciones = new List<Evaluacion>();
                
                foreach (var alumno in curso.Alumnos)
                {
                    foreach (var asignatura in curso.Asignaturas)
                    {
                        curso.Evaluaciones.AddRange(GenerarEvaluacion(alumno, asignatura));
                    }
                }                
            }
        }

        private List<Alumno> GenerarAlumnosAlAzar(int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };

            return listaAlumnos.OrderBy((al) => al.Id).Take(cantidad).ToList();
        }

        private List<Evaluacion> GenerarEvaluacion(Alumno alumno, Asignatura asignatura)
        {
            string[] nombreEvaluacion = { "Parcial 1", "Parcial 2", "Parcial 3", "Parcial 4", "Parcial 5" };
            var listEvaluaciones = new List<Evaluacion>();

            foreach (var nota in nombreEvaluacion)
            {
                var evaluacion = new Evaluacion();
                evaluacion.Nombre = nota;
                evaluacion.Alumno = alumno;
                evaluacion.Asignatura = asignatura;

                evaluacion.Nota = (float)Math.Round((new Random().NextDouble() * (4.0 - 0.0 + 1) + 0.0), 1); /// (r.NextDouble() * (maximo - minimo + 1)) + minimo  (si el min es 0, el max = max -1)
                /// opcional de aleatorios entre 0.0 y 5.0:
                /// evaluacion.Nota = (float)(5 * new Random().NextDouble()) ;
                listEvaluaciones.Add(evaluacion);
            }

            return listEvaluaciones;
        }

    }
}