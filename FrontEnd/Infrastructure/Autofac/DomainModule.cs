using Autofac;
using Core.Interfaces.Services;
using Core.Interfaces.Strategy;
using Core.Services;
using FrontEnd.Infrastructure.Core.Strategy;

namespace FrontEnd.Infrastructure.Autofac
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ClientSpecificStrategy>().As<ISomeStrategy>();
            builder.RegisterType<SomeService>().As<ISomeService>();
        }
    }
}