namespace RazorTemplatesMvc
{
    using System.Text;
    using System.Web.Mvc;

    /// <summary>
    /// Contains different extension methods that makes simple using of razor templates.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Generated link tag with filled href and required attributes.
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <param name="url">The URL page dependency.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeParams">The route value parameters.</param>
        /// <returns>Completed tag with link to template css.</returns>
        public static string CssTemplateRoute(this HtmlHelper html, UrlHelper url, string routeName, dynamic routeParams = null)
        {
            html.ViewContext.Writer.Write(string.Format("<link href=\"{0}\" type=\"text/css\" rel=\"stylesheet\" />", url.RouteUrl(routeName, routeParams)));
            return string.Empty;
        }

        /// <summary>
        /// Generated link tag with filled href and required attributes.
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <param name="url">The URL page dependency.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeParams">The route value parameters.</param>
        /// <returns>Completed tag with link to template css.</returns>
        public static string CssTemplateRoute(this HtmlHelper html, UrlHelper url, string routeName, dynamic routeParams = null, params Parameter[] parameters)
        {
            var parametersQuery = GetParametersQuery(parameters);
            html.ViewContext.Writer.Write(string.Format("<link href=\"{0}{1}\" type=\"text/css\" rel=\"stylesheet\" />", url.RouteUrl(routeName, routeParams), parametersQuery));
            return string.Empty;
        }

        /// <summary>
        /// Generated script link tag with filled src and required attributes.
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <param name="url">The URL page dependency.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeParams">The route value parameters.</param>
        /// <returns>Completed tag with link to template javascript.</returns>
        public static string JsTemplateRoute(this HtmlHelper html, UrlHelper url, string routeName, dynamic routeParams = null)
        {
            html.ViewContext.Writer.Write(string.Format("<script src=\"{0}\" type=\"text/javascript\"></script>", url.RouteUrl(routeName, routeParams)));
            return string.Empty;
        }

        /// <summary>
        /// Generated script link tag with filled src and required attributes.
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <param name="url">The URL page dependency.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeParams">The route value parameters.</param>
        /// <returns>Completed tag with link to template css.</returns>
        public static string JsTemplateRoute(this HtmlHelper html, UrlHelper url, string routeName, dynamic routeParams = null, params Parameter[] parameters)
        {
            var parametersQuery = GetParametersQuery(parameters);
            html.ViewContext.Writer.Write(string.Format("<script src=\"{0}\" type=\"text/javascript\"></script>", url.RouteUrl(routeName, routeParams), parametersQuery));
            return string.Empty;
        }

        private static string GetParametersQuery(Parameter[] parameters)
        {
            var parametersBuilder = new StringBuilder();
            if (parameters.Length != 0)
            {
                parametersBuilder.Append("?");
                foreach (var parameter in parameters)
                {
                    parametersBuilder.AppendFormat("{0}={1}&", parameter.Key, parameter.Value.ToString());
                }

                parametersBuilder.Remove(parametersBuilder.Length - 1, 1);
            }

            return parametersBuilder.ToString();
        }
    }
}
