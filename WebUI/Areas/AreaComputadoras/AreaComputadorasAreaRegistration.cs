using System.Web.Mvc;

namespace WebUI.Areas.AreaComputadoras
{
    public class AreaComputadorasAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AreaComputadoras";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AreaComputadoras_default",
                "AreaComputadoras/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );

            context.MapRoute(
            name: "FormRuta",
            url: "AreaComputadoras/{controller}/{action}"
            );
        }
    }
}