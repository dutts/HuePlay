using System.Linq;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace HuePlay
{
    public static class GradientStopCollectionExtensions
    {
        public static Color GetRelativeColor(this GradientStopCollection gsc, double offset)
        {
            GradientStop before = gsc.Where(w => w.Offset == gsc.Min(m => m.Offset)).First();
            GradientStop after = gsc.Where(w => w.Offset == gsc.Max(m => m.Offset)).First();

            foreach (var gs in gsc)
            {
                if (gs.Offset < offset && gs.Offset > before.Offset)
                {
                    before = gs;
                }
                if (gs.Offset > offset && gs.Offset < after.Offset)
                {
                    after = gs;
                }
            }

            var color = new Color();

            color.A = (byte)((offset - before.Offset) * (after.Color.A - before.Color.A) / (after.Offset - before.Offset) + before.Color.A);
            color.R = (byte)((offset - before.Offset) * (after.Color.R - before.Color.R) / (after.Offset - before.Offset) + before.Color.R);
            color.G = (byte)((offset - before.Offset) * (after.Color.G - before.Color.G) / (after.Offset - before.Offset) + before.Color.G);
            color.B = (byte)((offset - before.Offset) * (after.Color.B - before.Color.B) / (after.Offset - before.Offset) + before.Color.B);

            return color;
        }
    }
}
