using System.Drawing;

namespace InputComponents.Colors
{
    /// <summary>
    /// ViewModel for <c>ColorPicker</c> component.
    /// </summary>
    public class ColorVm
    {
        /// <summary>
        /// Create <c>ColorVm</c> with provided <paramref name="r"/> <paramref name="g"/> <paramref name="b"/> <paramref name="a"/> values.
        /// </summary>
        /// <remarks>
        /// <para>Values should be between 0 and 255 (inclusive).</para>
        /// </remarks>
        public ColorVm(int r, int g, int b, int a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        /// <summary>
        /// Convert to <c>System.Drawing.Color</c> struct.
        /// </summary>
        public Color ToColor() => Color.FromArgb(A, R, G, B);

        /// <summary>
        /// Create <c>ColorVm</c> with values from <c>System.Drawing.Color</c>.
        /// </summary>
        public void FromColor(Color color) => (R, G, B, A) = (color.R, color.G, color.B, color.A);

        /// <summary>
        /// Red value (between 0 and 255 inclusively).
        /// </summary>
        public int R { get; set; }

        /// <summary>
        /// Green value (between 0 and 255 inclusive).
        /// </summary>
        public int G { get; set; }

        /// <summary>
        /// Blue value (between 0 and 255 inclusive).
        /// </summary>
        public int B { get; set; }

        /// <summary>
        /// Alpha value (between 0 and 255 inclusive).
        /// </summary>
        public int A { get; set; }

        /// <summary>
        /// Color string for using with CSS attribute.
        /// </summary>
        /// <remarks>
        /// <para><c>R</c>, <c>G</c>, <c>B</c> values are between 0 and 255 (inclusive), <c>A</c> is between 0 and 1.</para>
        /// </remarks>
        /// <value>"rgba({R}, {G}, {B}, {A / 255.0})"</value>
        public string CssValue => $"rgba({R}, {G}, {B}, {A / 255.0})";
    }
}
