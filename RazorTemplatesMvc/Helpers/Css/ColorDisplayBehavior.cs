namespace RazorTemplatesMvc.Helpers.Css
{
    /// <summary>
    /// Color display translate behavior.
    /// </summary>
    public enum ColorDisplayBehavior
    {
        /// <summary>
        /// Color will be translated to <value>rgba(r, g , b, a)</value> string value. Where r, g, b, a are red, green blue and alpha channel components of color.
        /// </summary>
        Normal,

        /// <summary>
        /// Color will be translated to <value>#RRGGBB</value> string value. Where RR, GG, BB are red, green, blue components in hexadecimal view.
        /// </summary>
        WithoutAlpha
    }
}