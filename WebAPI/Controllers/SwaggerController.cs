using System.Web.Mvc;

namespace WebAPI.Controllers
{
    public class SwaggerController : Controller
    {
        public ActionResult Index()
        {
            return Redirect("http://localhost:61171/swagger/ui/index#/NotaFiscal");
        }
    }
}