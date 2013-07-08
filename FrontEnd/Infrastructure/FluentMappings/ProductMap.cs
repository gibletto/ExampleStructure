using Core.Domain.Catalog;
using FluentNHibernate.Mapping;

namespace FrontEnd.Infrastructure.FluentMappings
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Name).Length(255).Not.Nullable();
            Map(x => x.SKU).Length(100).Not.Nullable().Unique();
            HasMany(x => x.Stores)
                .ForeignKeyConstraintName("FK_ProductStores")
                .KeyColumn("Id");
        }
    }
}