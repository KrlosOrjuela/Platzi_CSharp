namespace CoreEscuela
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CoreEscuela.App;
    using CoreEscuela.Entidades;
    using CoreEscuela.Entidades.ClasesPadre;
    using CoreEscuela.Entidades.PruebaCast;
    using CoreEscuela.Utilidades;


    class Program
    {
        static void Main(string[] args)
        {
            /// Evento delegado lanzado al terminar la ejecución del programa
            // Forma 1:
            //AppDomain.CurrentDomain.ProcessExit += AccionDelEvento();
             // Forma 2:
            //.CurrentDomain.ProcessExit += (o,s)=> Imprimir.ImprimirBeepEnConsola(5000,1000);

            /// Remover un evento asignado 
            //AppDomain.CurrentDomain.ProcessExit -= AccionDelEvento();

            var coreEscuela = new EscuelaEngine(); 
            coreEscuela.Inicializar();
            ImprimirEscuelas(coreEscuela.Escuela);

            Imprimir.ImprimirLineaEnConsola(20);
            Imprimir.ImprimirTituloEnConsola("Pruebas Polimorfismo");

            var alumnoTest = new Alumno() { Nombre = "Carlo Amaya" };
            var objSistema = alumnoTest;

            Imprimir.ImprimirTituloEnConsola("Alumno");
            Console.WriteLine($"Nombre Alumno: {alumnoTest.Nombre}");
            Console.WriteLine($"Id Alumno: {alumnoTest.Id}");
            Console.WriteLine($"Id objSistema: {alumnoTest.GetType()}");


            Imprimir.ImprimirTituloEnConsola("objSistema");
            Console.WriteLine($"Nombre objSistema: {objSistema.Nombre}");
            Console.WriteLine($"Id objSistema: {objSistema.Id}");
            Console.WriteLine($"Id objSistema: {objSistema.GetType()}");

            var listEscuela = new List<Escuela>(); 
            listEscuela.Add(coreEscuela.Escuela);

            /// obtener objetos que implementen una interfaz 
            var objILugar = from obj in listEscuela
                            where obj is ILugar
                            select (ILugar) obj;


            /// Diccionarios
            Dictionary<int,string> diccionario = new Dictionary<int, string>();
            diccionario.Add(10, "Juank");
            diccionario.Add(12, "CarlosA");
            diccionario.Add(14, "DianaO");

            // Forma de recorrer un diccionario.
            foreach (var keyValuePair in diccionario)
            {
                Console.WriteLine($"Key:{keyValuePair.Key}; Valor: {keyValuePair.Value}");
            }

            Dictionary<string,string> diccionario2 = new Dictionary<string, string>();
            diccionario2["Luna"] = "Cuerpo celeste que gira alrrededor de la tierra";
            Console.WriteLine(diccionario2["Luna"]);

            // Cast
            IEnumerable<SalaDistante> listaSalasDistantes = new List<SalaDistante>();
            List<Sala> salas = new List<Sala>();

            //salas = listaSalasDistantes.Cast<Sala>();
            var sala1 = new Sala(){CostoFijo = 1534, Descripcion= "ejemplo 1", Id = 1, IndiceOcupacion = 1, MaximoOcupacion = 1, Nombre = "Sala 1",OcupacionActual = 1};
            var sala2 = new Sala(){CostoFijo = 1534, Descripcion= "ejemplo 2", Id = 1, IndiceOcupacion = 1, MaximoOcupacion = 1, Nombre = "Sala 2",OcupacionActual = 1};
            var sala3 = new Sala(){CostoFijo = 1534, Descripcion= "ejemplo 3", Id = 1, IndiceOcupacion = 1, MaximoOcupacion = 1, Nombre = "Sala 3",OcupacionActual = 1};
            var sala4 = new Sala(){CostoFijo = 1534, Descripcion= "ejemplo 4", Id = 1, IndiceOcupacion = 1, MaximoOcupacion = 1, Nombre = "Sala 4",OcupacionActual = 1};
            
            salas.Add(sala1);
             salas.Add(sala2);
              salas.Add(sala3);
               salas.Add(sala4);

            listaSalasDistantes = salas.Cast<SalaDistante>();  
           
           Reporteador repo = new Reporteador(null);


        }

        private static EventHandler AccionDelEvento()
        {
            Imprimir.ImprimirTituloEnConsola("SALIENDO");
            Imprimir.ImprimirBeepEnConsola(3000,1000);
            Imprimir.ImprimirTituloEnConsola("SALIÓ");
            return null;
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
