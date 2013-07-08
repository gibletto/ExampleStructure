using System.Web.Mvc;
using Core.Domain.Catalog;
using Core.Interfaces.Services;
using FrontEnd.ViewModels.Product;

namespace FrontEnd.Controllers
{
    public class ProductController : BaseController
    {
        private readonly ISomeService _service;
        /// <summary>
        /// No default constructor clearly signifies the dependencies to the outside world.
        /// I can remove the container entirely also and just implement a controller factory to handle this.
        /// It all goes in the infrastruce, I'm free to code
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
            return View(vm);
        }

    }
}
