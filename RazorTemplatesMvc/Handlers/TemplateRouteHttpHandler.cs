namespace RazorTemplatesMvc.Handlers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using System.Web.SessionState;
    using RazorEngine;

    using RequestContext = System.Web.Routing.RequestContext;
    using RazorEngine.Templating;

    /// <summary>
    /// Template MVC route and HTTP handler.
    /// </summary>
    public class TemplateRouteHttpHandler : IRouteHandler, IHttpHandler, IRequiresSessionState
    {
        private const string StylePattern = "<style type=\"text/css\">";

        private const string EndStylePattern = "</style>";

        private const string ScriptPattern = "<script type=\"text/javascript\">";

        private const string EndScriptPattern = "</script>";

        private readonly string responseType;

        private readonly string realPath;

        private readonly FileTypeHandlingMode mode;

        private readonly ContentType? type;

        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateRouteHttpHandler"/> class.
        /// </summary>
        /// <param name="responseType">Type of the template response content.</param>
        /// <param name="realPath">The real server path to map with template request.</param>
        /// <param name="mode">The file type handling mode.</param>
        public TemplateRouteHttpHandler(ContentType responseType, string realPath, FileTypeHandlingMode mode)
        {
            this.realPath = realPath;
            this.mode = mode;
            this.type = responseType;
            switch (responseType)
            {
                case ContentType.Css:
                    this.responseType = "text/css";
                    break;
                case ContentType.Js:
                    this.responseType = "text/javascript";
                    break;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateRouteHttpHandler"/> class.
        /// </summary>
        /// <param name="responseType">Type of the template response content.</param>
        /// <param name="realPath">The real server path to map with template request.</param>
        /// <param name="mode">The file type handling mode.</param>
        public TemplateRouteHttpHandler(string responseType, string realPath, FileTypeHandlingMode mode)
        {
            this.responseType = responseType;
            this.realPath = realPath;
            this.mode = mode;
        }

        /// <summary>
        /// Gets a value indicating whether another request can use the <see cref="T:System.Web.IHttpHandler"/> instance.
        /// </summary>
        /// <returns>true if the <see cref="T:System.Web.IHttpHandler"/> instance is reusable; otherwise, false.</returns>
        public bool IsReusable { get { return true; } }

        /// <summary>
        /// Provides the object that processes the request.
        /// </summary>
        /// <param name="requestContext">An object that encapsulates information about the request.</param>
        /// <returns>
        /// An object that processes the request.
        /// </returns>
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return this;
        }

        /// <summary>
        /// Enables processing of HTTP Web requests by a custom HttpHandler that implements the <see cref="T:System.Web.IHttpHandler"/> interface.
        /// </summary>
        /// <param name="context">An <see cref="T:System.Web.HttpContext"/> object that provides references to the intrinsic server objects (for example, Request, Response, Session, and Server) used to service HTTP requests.</param>
        public void ProcessRequest(HttpContext context)
        {
            var fileName = GetFileName(context.Request.AppRelativeCurrentExecutionFilePath);
            var realFilePath = GetRealFilePath(fileName);
            var textTemplate = File.ReadAllText(context.Server.MapPath(realFilePath));

            TemplateModel model = CreateModel(context);
            var parsedTemplate = Razor.Parse<TemplateModel>(textTemplate, model);
            if (mode == FileTypeHandlingMode.TransformFromCshtml)
            {
                parsedTemplate = ClearTemplate(parsedTemplate);
            }

            context.Response.ContentType = responseType;
            context.Response.Write(parsedTemplate);
        }

        private TemplateModel CreateModel(HttpContext context)
        {
            var model = new TemplateModel
                {
                    Session = context.Session
                };
            return model;
        }

        private string ClearTemplate(string parsedTemplate)
        {
            string result;
            switch (type)
            {
                case ContentType.Css:
                    result = parsedTemplate.Remove(parsedTemplate.IndexOf(StylePattern), StylePattern.Length);
                    result = result.Remove(result.LastIndexOf(EndStylePattern), EndStylePattern.Length);
                    break;
                case ContentType.Js:
                    result = parsedTemplate.Remove(parsedTemplate.IndexOf(ScriptPattern), ScriptPattern.Length);
                    result = result.Remove(result.LastIndexOf(EndScriptPattern), EndScriptPattern.Length);
                    break;
                case null:
                default:
                    result = parsedTemplate;
                    break;
            }

            return result;
        }

        private string GetFileName(string path)
        {
            var parts = path.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0)
            {
                return null;
            }

            return parts[parts.Length - 1];
        }

        private string GetRealFilePath(string fileName)
        {
            var realFilePath = string.Format("{0}/{1}", realPath.TrimEnd('/'), fileName);
            switch (mode)
            {
                case FileTypeHandlingMode.WithCsExtensionPrefix:
                    realFilePath = realFilePath.Insert(realFilePath.LastIndexOf('.') + 1, "cs");
                    break;
                case FileTypeHandlingMode.TransformFromCshtml:
                    realFilePath = realFilePath.Remove(realFilePath.LastIndexOf('.'));
                    realFilePath = realFilePath.Insert(realFilePath.Length, ".cshtml");
                    break;
                case FileTypeHandlingMode.WithoutCsExtensionPrefix:
                    break;
            }

            return realFilePath;
        }
    }
}
