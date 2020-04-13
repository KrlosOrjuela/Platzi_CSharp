namespace CoreEscuela
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CoreEscuela.App;
    using CoreEscuela.Entidades;

    class Program
    {
        static void Main(string[] args)
        {
            var coreEscuela = new EscuelaEngine();
            coreEscuela.Inicializar();
            ImprimirEscuelas(coreEscuela.Escuela);
        }

        private static bool Predicate(Curso curso)
        {
            return curso.Nombre == "101";
        }

        private static void ImprimirEscuelas(Escuela escuela)
        {
            Console.WriteLine("===================================");
            Console.WriteLine($"Escuela {escuela.Nombre}");
            Console.WriteLine("===================================");
            Console.WriteLine(escuela);
            Console.WriteLine($"============= Cursos =============");
            ImprimirCursos(escuela.Cursos);
            Console.WriteLine();
        }

        private static void ImprimirCursos(List<Curso> cursos)
        {
            /// cursos? => cursos != null
            if (cursos?.Count > 0)
            {
                foreach (var curso in cursos)
                {
                    Console.WriteLine($"Nombre: {curso.Nombre}, Id: {curso.Id}");
                    ImprimirNotas(curso.Evaluaciones);
                }
            }
        }

        private static void ImprimirNotas(List<Evaluacion> evaluacions)
        {
            evaluacions.OrderBy(ev => ev.Asignatura.Nombre);
            string alumnoActual = string.Empty;
            Console.WriteLine("=================================================================================");

            foreach (var evaluacion in evaluacions)
            {
                if (alumnoActual != evaluacion.Alumno.Nombre)
                {
                    Console.WriteLine($"===============  {evaluacion.Alumno.Nombre.ToUpper()}  =================");
                }
                                
                Console.WriteLine($"Nombre: {evaluacion.Nombre}, Alumno: {evaluacion.Alumno.Nombre}, Asignatura: {evaluacion.Asignatura.Nombre}, Nota: {evaluacion.Nota}");

                alumnoActual = evaluacion.Alumno.Nombre;
            }

            Console.WriteLine("=================================================================================");
        }

        private void AntiguoCodigoMain()
        {
            var escuela = new Escuela("Platzi Academy");
            escuela.Pais = TiposPais.Colombia;
            escuela.AnioCreacion = 1991;
            escuela.Ciudad = TiposCiudad.Medellin;
            escuela.TipoEscuela = TiposEscuela.Secundaria;
            escuela.Cursos = new List<Curso>();
            escuela.Cursos.Add(new Curso() { Nombre = "101" });
            escuela.Cursos.Add(new Curso() { Nombre = "201" });
            escuela.Cursos.Add(new Curso() { Nombre = "301" });
            ImprimirEscuelas(escuela);

            var escuela2 = new Escuela(nombre: "Platzi C# ", anioCreacion: 2020, TiposEscuela.Primaria, TiposPais.Colombia, ciudad: TiposCiudad.Bogota);
            escuela2.Cursos = new List<Curso>();
            escuela2.Cursos.Add(new Curso() { Nombre = "101" });
            escuela2.Cursos.Add(new Curso() { Nombre = "201" });
            escuela2.Cursos.Add(new Curso() { Nombre = "301" });
            ImprimirEscuelas(escuela2);

            escuela.Cursos.RemoveAll(Predicate); /// Uso de un delegado           
            ImprimirEscuelas(escuela);

            /// Otra formas de crear el delegado :
            escuela.Cursos.RemoveAll(delegate (Curso curso)
                                    {
                                        return curso.Nombre == "201";
                                    }); /// Uso de un delegado            
            ImprimirEscuelas(escuela);

            /// Otra formas de crear el delegado :
            escuela.Cursos.RemoveAll((Curso curso) => (curso.Nombre == "301")); /// Otra forma de escribir un delegado, usando expresión lambda
            ImprimirEscuelas(escuela);
        }
    }
}
