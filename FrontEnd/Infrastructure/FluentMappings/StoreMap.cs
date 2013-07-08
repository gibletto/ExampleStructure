using Core.Domain.Catalog;
using FluentNHibernate.Mapping;

namespace FrontEnd.Infrastructure.FluentMappings
{
    public class StoreMap : ClassMap<Store>
    {
        public StoreMap()
        {
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.StoreName).Length(100).Not.Nullable();
        }
    }
}