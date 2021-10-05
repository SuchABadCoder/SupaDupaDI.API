using System.Collections.Generic;

namespace SupaDupaDI.API.DI
{
    public class ServiceCollection
    {
        private readonly List<ServiceDescriptor> _serviceDescriptors;

        public ServiceCollection()
        {
            _serviceDescriptors = new List<ServiceDescriptor>();
        }

        public ServiceProvider GetServiceProvider()
        {
            return new ServiceProvider(_serviceDescriptors);
        }

        public void RegisterSingleton<TService>(TService implementation)
        {
            _serviceDescriptors.Add(new ServiceDescriptor(implementation, ServiceLifetime.Singleton));
        }

        public void RegisterSingleton<TService>()
        {
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), ServiceLifetime.Singleton));
        }

        public void RegisterSingleton<TService, TImplementation>() where TImplementation : TService
        {
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Singleton));
        }

        public void RegisterTransient<TService>(TService implementation)
        {
            _serviceDescriptors.Add(new ServiceDescriptor(implementation, ServiceLifetime.Transient));
        }

        public void RegisterTransient<TService>()
        {
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), ServiceLifetime.Transient));
        }

        public void RegisterTransient<TService, TImplementation>() where TImplementation : TService
        {
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Transient));
        }

        public void RegisterScoped<TService, TImplementation>() where TImplementation : TService
        {
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Scoped));
        }
    }
}
