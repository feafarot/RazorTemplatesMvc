namespace RazorTemplatesMvc.Sample.Controllers
{
    using System.Web.Mvc;
    using Helpers.Css;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Session["background"] = new Color(10, 30, 55);
            ViewBag.Version = typeof(Color).Assembly.GetName().Version.ToString();
            return View();
        }
    }
}
