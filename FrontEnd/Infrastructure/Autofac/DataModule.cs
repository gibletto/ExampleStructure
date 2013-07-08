using Autofac;
using Autofac.Integration.Mvc;
using Core.Domain.Catalog;
using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;

namespace FrontEnd.Infrastructure.Autofac
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x =>
            {
                var config = new Configuration();
                var fluentConfig = Fluently.Configure(config);
                fluentConfig.Mappings(m => m.FluentMappings.AddFromAssemblyOf<Product>())
                            .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true));
                return fluentConfig.BuildSessionFactory();
            }).As<ISessionFactory>();
            builder.Register(x =>
            {
                var sessionFactory = x.Resolve<ISessionFactory>();
                if (!CurrentSessionContext.HasBind(sessionFactory))
                {
                    CurrentSessionContext.Bind(sessionFactory.OpenSession());
                }
                var session = sessionFactory.GetCurrentSession();
                return session;
            }).As<ISession>().InstancePerHttpRequest();
        }
    }
}