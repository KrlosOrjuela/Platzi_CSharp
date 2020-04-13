namespace CoreEscuela
{
    using System;

    public class Escuela
    {
        public string Nombre;
        public string Direccion;

        public void SonarTimbre()
        {
            Console.Beep(2000, 1000);
        }
    }
}