﻿namespace TravelAgency.Web.Infrastructure.Extensions
{
    using System.Reflection;
    using Microsoft.Extensions.DependencyInjection;
    public static class WebApplicationBuilderExtensions
    {
        /// <summary>
        /// This method registers all services with their interfaces and implementation of given assembly.
        /// The assembly is taken from the type of random service implementation provided.
        /// </summary>
        /// <param name="serviceType">Type of random service implementation.</param>
        /// <exception cref="InvalidOperationException"></exception>

        public static void AddApplicationServices(this IServiceCollection services, Type serviceType)
        {
            Assembly? serviceAssembly = Assembly.GetAssembly(serviceType);
            if (serviceAssembly == null)
            {
                throw new InvalidOperationException("Invalid service type provided!");
            }

            Type[] servicesTypes = serviceAssembly
                .GetTypes()
                .Where(t => t.Name.EndsWith("Service") && !t.IsInterface)
                .ToArray();

            foreach (var inplementationType in servicesTypes)
            {
                Type? interfaceType = inplementationType.GetInterface($"I{inplementationType.Name}");

                if (interfaceType == null)
                {
                    throw new InvalidOperationException($"No interface is provided for the service with name: {inplementationType.Name}");
                }

                services.AddScoped(interfaceType, inplementationType);
            }

        }
    }
}