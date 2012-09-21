namespace RazorTemplatesMvc.Handlers
{
    using System.Collections.Generic;
    using System.Web.SessionState;
    using RazorEngine.Templating;

    /// <summary>
    /// Template model.
    /// </summary>
    public class TemplateModel : TemplateBase
    {
        /// <summary>
        /// Gets or sets the session.
        /// </summary>
        public HttpSessionState Session { get; set; }

        /// <summary>
        /// Gets or sets the parameters parsed from query string.
        /// </summary>
        public Dictionary<string, string> Parameters { get; set; }
    }
}
