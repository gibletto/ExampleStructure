using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using FrontEnd.Controllers;

namespace FrontEnd.App_Start
{
    public class AutofacConfig
    {
        public static void RegisterContainer()
        {
            var builder = new ContainerBuilder();
            //Scan all if needed for any assembly registrations.
            builder.RegisterAssemblyModules(typeof(AutofacConfig).Assembly);
            builder.RegisterModelBinderProvider();
            builder.RegisterFilterProvider();
            builder.RegisterControllers(typeof(ProductController).Assembly).PropertiesAutowired();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}