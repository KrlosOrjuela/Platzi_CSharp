namespace CoreEscuela.Utilidades
{
    using System;

    public static class Imprimir
    {
        public static void ImprimirLineaEnConsola(int longitudLinea = 10)
        {
            Console.WriteLine("".PadLeft(longitudLinea, '='));
        }

        public static void ImprimirTituloEnConsola(string titulo)
        {
            var longitud = titulo.Length + 4;
            ImprimirLineaEnConsola(longitud);
            Console.WriteLine($"| {titulo} |");
            ImprimirLineaEnConsola(longitud);
        }

        public static void ImprimirBeepEnConsola(int hz = 2000, int tiempo = 500)
        {
            Console.Beep(hz, tiempo);
        }
    }
}