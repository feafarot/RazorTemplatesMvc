namespace RazorTemplatesMvc.Sample.Controllers
{
    using System.Web.Mvc;
    using Helpers.Css;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Session["bgc"] = new Color(10, 30, 55);
            return View();
        }
    }
}
