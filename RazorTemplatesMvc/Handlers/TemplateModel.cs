namespace RazorTemplatesMvc.Handlers
{
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
    }
}
