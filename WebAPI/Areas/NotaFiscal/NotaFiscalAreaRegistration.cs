using System.Web.Mvc;

namespace WebAPI.Areas.NotaFiscal
{
    public class NotaFiscalAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "NotaFiscal";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "NotaFiscal_default",
                "NotaFiscal/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}