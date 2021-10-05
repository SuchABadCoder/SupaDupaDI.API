using System;
using System.Collections.Generic;
using System.Linq;

namespace SupaDupaDI.API.DI
{
    public class ServiceProvider : IDisposable
    {
        private readonly List<ServiceDescriptor> _serviceDescriptors;

        public ServiceProvider(List<ServiceDescriptor> serviceDescriptors)
        {
            _serviceDescriptors = serviceDescriptors; 
        }

        public object GetService(Type serviceType)
        {
            var descriptor = _serviceDescriptors
                .SingleOrDefault(x => x.ServiceType == serviceType);

            if (descriptor == null)
                throw new Exception($"Service of type {serviceType} isn't registered");

            if (descriptor.Implementation != null)
                return descriptor.Implementation;

            var actualType = descriptor.ImplementationType ?? descriptor.ServiceType;

            if (actualType.IsAbstract || actualType.IsInterface)
                throw new Exception("Canot instansiate abstract classes or interface");

            var construcorInfo = actualType.GetConstructors().First();

            var parameters = construcorInfo.GetParameters()
                .Select(x => GetService(x.ParameterType)).ToArray();

            var implementation = Activator
                .CreateInstance(actualType, parameters);

            if (descriptor.Lifetime == ServiceLifetime.Singleton || descriptor.Lifetime == ServiceLifetime.Scoped)
                descriptor.Implementation = implementation;

            return implementation;
        }

        public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }

        public void Dispose()
        {
            foreach (var service in _serviceDescriptors)
                if (service.Lifetime == ServiceLifetime.Scoped)
                    service.Implementation = null;

            Console.WriteLine("Disposed");
        }
    }
}
