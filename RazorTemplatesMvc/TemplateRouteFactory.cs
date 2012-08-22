namespace RazorTemplatesMvc
{
    using System.Web.Routing;
    using Handlers;

    /// <summary>
    /// Template route factory.
    /// </summary>
    public static class TemplateRouteFactory
    {
        /// <summary>
        /// Creates the route for template handling.
        /// </summary>
        /// <param name="url">The URL pattern for the route.</param>
        /// <param name="responseType">Type of the templates content response.</param>
        /// <param name="realPath">The real server path that should be mapped with route pattern.</param>
        /// <returns>Template route handler.</returns>
        public static Route CreateRoute(string url, ContentType responseType, string realPath)
        {
            return new Route(url, new TemplateRouteHttpHandler(responseType, realPath, FileTypeHandlingMode.WithCsExtensionPrefix));
        }

        /// <summary>
        /// Creates the route for template handling.
        /// </summary>
        /// <param name="url">The URL pattern for the route.</param>
        /// <param name="responseType">Custom type of the templates content response.</param>
        /// <param name="realPath">The real path.</param>
        /// <returns>Template route handler.</returns>
        public static Route CreateRoute(string url, string responseType, string realPath)
        {
            return new Route(url, new TemplateRouteHttpHandler(responseType, realPath, FileTypeHandlingMode.WithCsExtensionPrefix));
        }

        /// <summary>
        /// Creates the route for template handling.
        /// </summary>
        /// <param name="url">The URL pattern for the route.</param>
        /// <param name="responseType">Custom type of the templates content response.</param>
        /// <param name="realPath">The real server path that should be mapped with route pattern.</param>
        /// <param name="mode">File type(extension) handling mode.</param>
        /// <returns>Template route handler.</returns>
        public static Route CreateRoute(string url, string responseType, string realPath, FileTypeHandlingMode mode)
        {
            return new Route(url, new TemplateRouteHttpHandler(responseType, realPath, mode));
        }

        /// <summary>
        /// Creates the route for template handling.
        /// </summary>
        /// <param name="url">The URL pattern for the route.</param>
        /// <param name="responseType">Type of the templates content response.</param>
        /// <param name="realPath">The real server path that should be mapped with route pattern.</param>
        /// <param name="mode">File type(extension) handling mode.</param>
        /// <returns>Template route handler.</returns>
        public static Route CreateRoute(string url, ContentType responseType, string realPath, FileTypeHandlingMode mode)
        {
            return new Route(url, new TemplateRouteHttpHandler(responseType, realPath, mode));
        }
    }
}
