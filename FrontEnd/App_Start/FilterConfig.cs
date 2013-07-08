using System.Web.Mvc;
using FrontEnd.Infrastructure.Filters;

namespace FrontEnd
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new NHibernateFilter(), 1);
            filters.Add(new HandleErrorAttribute());
        }
    }
}