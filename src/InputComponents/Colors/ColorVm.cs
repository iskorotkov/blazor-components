using System.Drawing;

namespace InputComponents.Colors
{
    public class ColorVm
    {
        public ColorVm(int r, int g, int b, int a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public Color ToColor() => Color.FromArgb(A, R, G, B);

        public void FromColor(Color color) => (R, G, B, A) = (color.R, color.G, color.B, color.A);

        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }
        public int A { get; set; }

        public string CssValue => $"rgba({R}, {G}, {B}, {A / 255.0})";
    }
}
