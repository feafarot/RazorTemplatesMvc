namespace RazorTemplatesMvc
{
    /// <summary>
    /// File type handling mode.
    /// </summary>
    public enum FileTypeHandlingMode
    {
        /// <summary>
        /// Using this mode handler will add "cs" prefix to file extension and will use it for mapping with servers file system. 
        /// </summary>
        /// <remarks>
        /// Sample: if request is "http://localhost/Sample/css/test.css" then handler will map it to file with ".cscss" extension.
        /// </remarks>
        WithCsExtensionPrefix,

        /// <summary>
        /// Using this mode handler will not change file name or extension it will be use original file name for mapping with servers file system.
        /// </summary>
        WithoutCsExtensionPrefix,

        /// <summary>
        /// Using this mode handler will change file extension from it's any to ".cshtml" and will use it for mapping with servers file system.
        /// </summary>
        TransformFromCshtml
    }
}
