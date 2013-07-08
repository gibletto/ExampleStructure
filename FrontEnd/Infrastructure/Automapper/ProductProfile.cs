using AutoMapper;
using Core.Domain.Catalog;
using FrontEnd.ViewModels.Product;

namespace FrontEnd.Infrastructure.Automapper
{
    public class ProductProfile : Profile
    {
        protected override void Configure()
        {
            //Use value resolvers or type resolvers to use dependency injection with automapper.
            CreateMap<Product, DisplayProductViewModel>();
        }
    }
}