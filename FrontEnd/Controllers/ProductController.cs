using System.Linq;
using System.Web.Mvc;
using Core.Domain.Catalog;
using Core.Interfaces.Services;
using FrontEnd.ViewModels.Product;
using NHibernate.Transform;

namespace FrontEnd.Controllers
{
    public class ProductController : BaseController
    {
        private readonly ISomeService _service;
        /// <summary>
        /// No default constructor clearly signifies the dependencies to the outside world.
        /// I can remove the container entirely also and just implement a controller factory to handle this.
        /// It all goes in the infrastructure, I'm free to code
        /// </summary>
        /// <param name="service"></param>
        public ProductController(ISomeService service)
        {
            _service = service;
        }

        public ActionResult Index(int id)
        {
            var product = DB.Get<Product>(id);
            var vm = Map.Map<DisplayProductViewModel>(product);
            //Return here or
            //I can also project to a view model directly, and do stuff with futures here to batch queries.
            DisplayProductViewModel alias = null;
            var projectedProductVm = DB.QueryOver<Product>()
                                .Where(x => x.Id == id)
                                .SelectList(list => list.Select(x => x.Id).WithAlias(() => alias.Id)
                                    .Select(x => x.Name).WithAlias(() => alias.Name))
                                .TransformUsing(Transformers.AliasToBean<DisplayProductViewModel>())
                                .Take(10)
                                .Future<DisplayProductViewModel>();
            var stores = DB.QueryOver<Store>()
                .Take(10)
                .Future()
                .ToList();

            return View(vm);
        }

    }
}
