using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;
using Autofac;
using AutoMapper;
using Module = Autofac.Module;

namespace FrontEnd.Infrastructure.Autofac
{
    public class AutoMapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                   .AssignableTo<Profile>()
                   .As<Profile>();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                   .AsClosedTypesOf(typeof(ValueResolver<,>))
                   .AsSelf();
            builder.Register(c =>
            {
                Mapper.Configuration.ConstructServicesUsing(DependencyResolver.Current.GetService);
                var profiles = c.Resolve<IEnumerable<Profile>>();
                foreach (var p in profiles)
                {
                    Mapper.AddProfile(p);
                }
                Mapper.AssertConfigurationIsValid();
                return Mapper.Engine;
            }).As<IMappingEngine>().SingleInstance();
        }
    }
}