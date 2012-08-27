namespace RazorTemplatesMvc.Sample
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            var templateRoute = TemplateRouteFactory.CreateRoute("css/{cssname}.css", ContentType.Css, "~/Content", FileTypeHandlingMode.WithCsExtensionPrefix);
            routes.Add("CssRoute", templateRoute); 
            routes.Add("JsRoute", TemplateRouteFactory.CreateRoute("javascript/{jsname}.js", ContentType.Js, "~/Scripts", FileTypeHandlingMode.TransformFromCshtml));
            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}