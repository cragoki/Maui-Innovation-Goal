using Core.Interfaces;
using Infrastructure.Repositorys;
using Microsoft.Extensions.Configuration;
using Stashbox;

namespace Infrastructure.Config.IoC
{
    public static class IocBuilder
    {
        public static IStashboxContainer Container { get; private set; }

        private static void Initialize(IStashboxContainer container)
        {
            Container = container;
        }

        public static IStashboxContainer AddDependencies(this IStashboxContainer container, IConfiguration configuration)
        {
            Initialize(container);

            // Repository
            container.RegisterScoped<IUserRepository, UserRepository>();
            container.RegisterScoped<IPollingStationRepository, PollingStationRepository>();

            container.RegisterSettings(configuration);
            container.RegisterServices();
            container.RegisterJobs();
            container.RegisterHttpClients();

            return container;
        }

        public static IStashboxContainer RegisterSettings(this IStashboxContainer container, IConfiguration configuration)
        {
            return container;
        }

        public static IStashboxContainer RegisterServices(this IStashboxContainer container)
        {
            return container;
        }

        public static IStashboxContainer RegisterJobs(this IStashboxContainer container)
        {
            return container;
        }

        public static IStashboxContainer RegisterHttpClients(this IStashboxContainer container)
        {
            return container;
        }
    }
}
