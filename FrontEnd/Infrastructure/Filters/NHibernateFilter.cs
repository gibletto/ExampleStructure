using System.Web.Mvc;
using FrontEnd.Controllers;

namespace FrontEnd.Infrastructure.Filters
{
    /// <summary>
    /// This could easily be pushed into a common mvc project as it's resuable.
    /// </summary>
    public class NHibernateFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var baseController = filterContext.Controller as BaseController;

            if (baseController == null)
                return;

            baseController.DB.BeginTransaction();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var baseController = filterContext.Controller as BaseController;

            if (baseController == null)
                return;

            if (baseController.DB == null)
                return;

            if (!baseController.DB.Transaction.IsActive)
                return;

            if (filterContext.Exception != null)
            {
                baseController.DB.Transaction.Rollback();
            }
            else
            {
                baseController.DB.Transaction.Commit();
            }
        }
    }
}