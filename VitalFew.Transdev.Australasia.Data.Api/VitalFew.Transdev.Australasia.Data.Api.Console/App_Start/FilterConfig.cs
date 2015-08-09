using System.Web.Mvc;

namespace VitalFew.Transdev.Australasia.Data.Api.Console
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
