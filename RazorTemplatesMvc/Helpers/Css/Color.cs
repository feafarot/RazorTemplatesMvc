namespace RazorTemplatesMvc.Helpers.Css
{
    /// <summary>
    /// Struct helper that make simpler usage of color values in razor templates. 
    /// </summary>
    public struct Color
    {
        private float internalAlpha;
        
        private byte red;

        private byte green;

        private byte blue;

        private ColorDisplayBehavior colorDisplayBehavior;

        /// <summary>
        /// Initializes a new instance of the <see cref="Color"/> struct.
        /// </summary>
        /// <param name="red">Red component.</param>
        /// <param name="green">The green component.</param>
        /// <param name="blue">The blue component.</param>
        /// <remarks>With Alpha = 1.0</remarks>
        public Color(byte red, byte green, byte blue)
        {
            this.internalAlpha = 1f;
            this.red = red;
            this.green = green;
            this.blue = blue;
            this.colorDisplayBehavior = ColorDisplayBehavior.Normal;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Color"/> struct.
        /// </summary>
        /// <param name="red">Red component.</param>
        /// <param name="green">The green component.</param>
        /// <param name="blue">The blue component.</param>
        /// <param name="behavior">The displaying behavior.</param>
        public Color(byte red, byte green, byte blue, ColorDisplayBehavior behavior)
            : this(red, green, blue)
        {
            colorDisplayBehavior = behavior;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Color"/> struct.
        /// </summary>
        /// <param name="red">Red component.</param>
        /// <param name="green">The green component.</param>
        /// <param name="blue">The blue component.</param>
        /// <param name="alpha">The alpha channel. <remarks>Should be between 0 and 1.0.</remarks></param>
        public Color(byte red, byte green, byte blue, float alpha)
            : this(red, green, blue)
        {
            Alpha = alpha;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Color"/> struct.
        /// </summary>
        /// <param name="red">Red component.</param>
        /// <param name="green">The green component.</param>
        /// <param name="blue">The blue component.</param>
        /// <param name="alpha">The alpha channel. <remarks>Should be between 0 and 1.0.</remarks></param>
        /// <param name="behavior">The displaying behavior.</param>
        public Color(byte red, byte green, byte blue, float alpha, ColorDisplayBehavior behavior)
            : this(red, green, blue, alpha)
        {
            ColorDisplayBehavior = behavior;
        }

        /// <summary>
        /// Gets or sets the red component.
        /// </summary>
        public byte Red { get { return red; } set { red = value; } }
        
        /// <summary>
        /// Gets or sets the green component.
        /// </summary>
        public byte Green { get { return green; } set { green = value; } }
        
        /// <summary>
        /// Gets or sets the blue component.
        /// </summary>
        public byte Blue { get { return blue; } set { blue = value; } }

        /// <summary>
        /// Gets or sets the alpha channel.
        /// </summary>
        public float Alpha
        {
            get
            {
                return internalAlpha;
            }

            set
            {
                if (value > 1f)
                {
                    internalAlpha = 1f;
                }
                else if (value < 0f)
                {
                    internalAlpha = 0f;
                }
                else
                {
                    internalAlpha = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the color displaying behavior.
        /// </summary>
        public ColorDisplayBehavior ColorDisplayBehavior { get { return colorDisplayBehavior; } set { colorDisplayBehavior = value; } }

        /// <summary>
        /// Updates current colors alpha channel and returns updated value. <remarks> Fluent.</remarks>
        /// </summary>
        /// <param name="alpha">The new alpha channel value.</param>
        /// <returns>Updated color value.</returns>
        public Color NewAlpha(float alpha)
        {
            Alpha = alpha;
            return this;
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// Displaying format depends upon <see cref="ColorDisplayBehavior"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            string cssResult;
            switch (ColorDisplayBehavior)
            {
                case ColorDisplayBehavior.WithoutAlpha:
                    cssResult = string.Format("#{0:X2}{1:X2}{2:X2}", Red, Green, Blue);
                    break;
                case ColorDisplayBehavior.Normal:
                default:
                    cssResult = string.Format("rgba({0}, {1}, {2}, {3})", Red, Green, Blue, Alpha);
                    break;
            }

            return cssResult;
        }
    }
}
