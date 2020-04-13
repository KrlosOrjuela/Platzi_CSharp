namespace CoreEscuela
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            var miEscuela = new Escuela();
            miEscuela.Nombre = "Platzi";
            miEscuela.Direccion = "Cra 9 Clle 72";
            Console.WriteLine("Sonar timbre...");
            miEscuela.SonarTimbre();
        }
    }
}
