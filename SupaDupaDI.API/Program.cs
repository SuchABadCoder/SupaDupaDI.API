using System;
using SupaDupaDI.API.DI;
using SupaDupaDI.API.Interfaces;
using SupaDupaDI.API.Services;

namespace SupaDupaDI.API
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            //services.RegisterTransient<IDupaService, DupaService>();
            //services.RegisterTransient<ISupaService, SupaService>();

            //services.RegisterSingleton<IDupaService, DupaService>();
            //services.RegisterSingleton<ISupaService, SupaService>();

            //services.RegisterSingleton<DupaService>();

            services.RegisterTransient(new DupaService());

            var container = services.GetServiceProvider();

            //var service_0 = container.GetService<ISupaService>();
            //var service_1 = container.GetService<ISupaService>();
            var service_2 = container.GetService<DupaService>();

            //service_1.PrintSomeDupa();
            //service_0.PrintSomeDupa();
            Console.WriteLine(service_2.DupaGuid);

            //using ( var scope = new ThreadScope(container))
            //{
            //    services.RegisterScoped<IDupaService, DupaService>();
            //    services.RegisterScoped<ISupaService, SupaService>();

            //    container = services.GetServiceProvider();

            //    var service_0 = container.GetService<ISupaService>();
            //    var service_1 = container.GetService<ISupaService>();

            //    service_0.PrintSomeDupa();
            //    service_1.PrintSomeDupa();
            //}

            //var services_2 = container.GetService<ISupaService>();
            //services_2.PrintSomeDupa();
        }
    }
}
