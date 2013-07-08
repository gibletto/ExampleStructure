using System.Web.Mvc;
using AutoMapper;
using NHibernate;

namespace FrontEnd.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// I usually property inject common dependencies to prevent annoying constructor chaining
        /// </summary>
        public ISession DB { get; set; }
        public IMappingEngine Map { get; set; }
    }
}