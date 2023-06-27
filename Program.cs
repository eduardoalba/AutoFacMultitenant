using Autofac;
using Autofac.Multitenant;
using System;

namespace AutoFacSample
{
    class Program
    {
        private static IContainer _container;
        private static TenantIdentificationWithServiceStrategy _tenantIdentifier;

        static void Main(string[] args)
        {
            _container = ConfigureDependencies();

            while (true)
            {
                var input = Console.ReadLine().ToUpper();
                if (input == "Q")
                    break;

                ResolveAndDispose<IService>(x => x.Run(), input);
            }
        }

        private static void ResolveAndDispose<T>(Action<T> action, string input) where T : IDisposable
        {
            _tenantIdentifier.Letter = input;

            using (var lifetimeScope = _container.BeginLifetimeScope())
            {
                using (var service = lifetimeScope.Resolve<T>())
                {
                    action(service);
                };
            }
        }

        private static IContainer ConfigureDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<RepositoryLevel>().As<IRepositoryLevel>();
            builder.RegisterType<ServiceLevel>().As<IServiceLevel>();
            builder.RegisterType<TenantIdentificationWithServiceStrategy>().AsSelf();

            var container = builder.Build();

            _tenantIdentifier = container.Resolve<TenantIdentificationWithServiceStrategy>();

            var mtc = new MultitenantContainer(_tenantIdentifier, container);

            mtc.ConfigureTenant("L06", b => b.RegisterModule<ModuleA>());
            mtc.ConfigureTenant("L10", b => b.RegisterModule<ModuleB>());

            return mtc;
        }
    }
}
