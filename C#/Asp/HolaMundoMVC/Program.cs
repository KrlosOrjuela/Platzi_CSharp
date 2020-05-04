namespace HolaMundoMVC
{
    using HolaMundoMVC.Models.ContextoTablasBD;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            var host = CreateHostBuilder(args).Build(); // Creo los servicios, pero no los ejecuto

            using (var scope = host.Services.CreateScope()) // Evitamos que el objeto scope creado, se quede almacenado en memoria
            {
                var servicios = scope.ServiceProvider; // Obtenemos todos los servicios creados y usados.

                try
                {
                    var contextoBD = servicios.GetRequiredService<ContextoBDEscuela>();
                    contextoBD.Database.EnsureCreated(); // Crea todos los elementos necesarios para la BD, incluidos los definidos al sobre-escribir el OnModelCreating en ContextoBDEscuela
                }
                catch (System.Exception ex)
                {
                    /// Usamos el servicio de log de eventos de la aplicación
                    var logEventos = servicios.GetRequiredService<ILogger<Program>>();
                    logEventos.LogError(ex, "Program: Main => Ocurrio un error creando la BD");
                }
            }

            /// Una vez asegurados que todos los datos se estan creados, ejecutamos el servicio 
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
