namespace HolaMundoMVC.Models.ContextoTablasBD
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using HolaMundoMVC.Models.ModelosProyectoEscuela;
    using Microsoft.EntityFrameworkCore;
    using static HolaMundoMVC.Models.ModelosProyectoEscuela.Enumeradores.TiposEntesSistema;

    public class ContextoBDEscuela : DbContext
    {
        /// DbSet: Representa una tabla en BD, en este caso definimos que es del tipo Escuela
        public DbSet<Escuela> EscuelasBD { get; set; }

        /// DbSet: Representa una tabla en BD, en este caso definimos que es del tipo Asignatura
        public DbSet<Asignatura> AsignaturasBD { get; set; }

        /// DbSet: Representa una tabla en BD, en este caso definimos que es del tipo Alumno
        public DbSet<Alumno> AlumnosBD { get; set; }

        /// DbSet: Representa una tabla en BD, en este caso definimos que es del tipo Curso
        public DbSet<Curso> CursosBD { get; set; }

        /// DbSet: Representa una tabla en BD, en este caso definimos que es del tipo Evaluacion
        public DbSet<Evaluacion> EvaluacionesBD { get; set; }

        public ContextoBDEscuela(DbContextOptions<ContextoBDEscuela> options) : base(options)
        {

        }

        /// (Sobre escribimos el comportamiento) Metodo que se ejecuta cuando se esta creando la BD
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /// Antes de cambiar su comportamiento, ejecute el comportamiento predeterminado
            base.OnModelCreating(modelBuilder);

            /// Luego si lo que deseo hacer: SEMBRAR DATOS EN LA BD 

            /// IMPORTANTE: 
            // Antes de crear cualquier entidad en BD, es necesario recordar que cada objeto debe tener una llave primaria llamada Id.

            /// 1) Creamos una escuela.
            var escuela = new Escuela();
            escuela.AnioDeCreacion = 2020;
            escuela.Nombre = "Platzy";
            escuela.Direccion = "Clle 5 # 6-8";
            escuela.Ciudad = "Bogota";
            escuela.Pais = "Colombia";
            escuela.TipoEscuela = TiposEscuela.Secundaria;           

            /// 2) - Cargamos cursos de la Escuela
            ///    - Por cada curso es necesario cargar una lista de asignaturas asignadas
            ///    - Por cada curso es necesario cargar una lista de alumnos asignados

            /// Empezamos
            //  *   Cargamos cursos de la Escuela
            var listaCursosXEscuela = this.CargarCursos(escuela);

            //  *   Por cada curso es necesario cargar una lista de asignaturas
            var listaAsignaturasXCurso = this.CargarAsignaturasXCursos(listaCursosXEscuela);

            // *    Por cada curso es necesario cargar una lista de alumnos asignados
            var listaAlumnosXCurso = this.CargarAlumnosXCurso(listaCursosXEscuela);

            /// hacemos la siembra de nuestros datos 
            /// HasData: Valida si no tiene datos la tabla Escuela. sino tiene datos inserta el definido como parametro: escuela
            modelBuilder.Entity<Escuela>().HasData(escuela);
            modelBuilder.Entity<Curso>().HasData(listaCursosXEscuela);
            modelBuilder.Entity<Asignatura>().HasData(listaAsignaturasXCurso);
            modelBuilder.Entity<Alumno>().HasData(listaAlumnosXCurso);

            /*
            /// 2) Creamos una lista de asignaturas que dictara la escuela
            var listaAsignaturas = new List<Asignatura>(){
                new Asignatura{Nombre="Matemáticas"} ,
                new Asignatura{Nombre="Física"},
                new Asignatura{Nombre="Programación"},
                new Asignatura{Nombre="Ciencias Naturales"}
            };
            modelBuilder.Entity<Asignatura>().HasData(listaAsignaturas.ToArray());

            /// 3) Creamos una lista de Alumnos incritos la escuela
            var listaAlumnos = this.GenerarAlumnosAlAzar(50);
            modelBuilder.Entity<Alumno>().HasData(listaAlumnos.ToArray());
            */

        }


        private List<Asignatura> CargarAsignaturasXCursos(List<Curso> listaCursosXEscuela)
        {
            var totalAsignaturasAsociadas = new List<Asignatura>();

            foreach (var curso in listaCursosXEscuela)
            {
                var listaAsignaturas = new List<Asignatura>()
                {
                    new Asignatura{Nombre="Matemáticas", CursoId = curso.Id} ,
                    new Asignatura{Nombre="Física", CursoId = curso.Id},
                    new Asignatura{Nombre="Programación", CursoId = curso.Id},
                    new Asignatura{Nombre="Ciencias Naturales", CursoId = curso.Id}
                };

                // curso.Asignaturas = listaAsignaturas;
                totalAsignaturasAsociadas.AddRange(listaAsignaturas);
            }

            return totalAsignaturasAsociadas;
        }


        private List<Curso> CargarCursos(Escuela escuela)
        {
            var listaCursos = new List<Curso>();
            listaCursos.Add(new Curso() { EscuelaId = escuela.Id, Nombre = "101", Dirección= "Calle 1 2-3", Jornada = TiposJornada.Mañana });
            listaCursos.Add(new Curso() { EscuelaId = escuela.Id, Nombre = "201", Dirección= "Calle 1 2-3", Jornada = TiposJornada.Mañana });
            listaCursos.Add(new Curso() { EscuelaId = escuela.Id, Nombre = "301", Dirección= "Calle 1 2-3", Jornada = TiposJornada.Mañana });
            listaCursos.Add(new Curso() { EscuelaId = escuela.Id, Nombre = "401", Dirección= "Calle 1 2-3", Jornada = TiposJornada.Tarde });
            listaCursos.Add(new Curso() { EscuelaId = escuela.Id, Nombre = "501", Dirección= "Calle 1 2-3", Jornada = TiposJornada.Tarde });
            return listaCursos;
        }


        private List<Alumno> GenerarAlumnosAlAzar(int cantidad, string IdCursoAsignado)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {a1}", CursoId =  IdCursoAsignado};

            return listaAlumnos.OrderBy((al) => al.Id).Take(cantidad).ToList();
        }


        private List<Alumno> CargarAlumnosXCurso(List<Curso> listaCursos)
        {
            var listaAlumnosCargados = new List<Alumno>();

            var random = new Random();

            foreach (var curso in listaCursos)
            {
                int cantidadAlumnosAGenerar = random.Next(5,20); // Numero aleatorio entre 5 y 20
                var listaAlunosGenerados = this.GenerarAlumnosAlAzar(cantidadAlumnosAGenerar, curso.Id);
                listaAlumnosCargados.AddRange(listaAlunosGenerados);
            }

            return listaAlumnosCargados;
        }

    }
}