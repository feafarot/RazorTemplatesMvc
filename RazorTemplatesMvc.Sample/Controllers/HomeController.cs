namespace RazorTemplatesMvc.Sample.Controllers
{
    using System.Web.Mvc;
    using Helpers.Css;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Session["footerTextColor"] = new Color(117, 120, 120);
            ViewBag.Version = typeof(Color).Assembly.GetName().Version.ToString();
            return View();
        }
    }
}
