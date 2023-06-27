using Autofac;

namespace AutoFacSample
{
    public class ModuleA : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ServiceA>().As<IService>();
            builder.RegisterType<RepositoryA>().As<IRepository>();
        }
    }

    public class ModuleB : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ServiceB>().As<IService>();
            builder.RegisterType<RepositoryB>().As<IRepository>();
        }
    }
}
