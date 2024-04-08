using System.Collections.Generic;
using System.Windows.Media;

namespace _2048_game
{
    public class TileColors
    {
        public readonly Dictionary<int, SolidColorBrush> _tileColors = new Dictionary<int, SolidColorBrush>()
        {
            { 0, new SolidColorBrush(Color.FromRgb(204, 192, 179)) },
            { 2, new SolidColorBrush(Color.FromRgb(238, 228, 218)) },
            { 4, new SolidColorBrush(Color.FromRgb(237, 224, 200)) },
            { 8, new SolidColorBrush(Color.FromRgb(242, 177, 121)) },
            { 16, new SolidColorBrush(Color.FromRgb(245, 149, 99)) },
            { 32, new SolidColorBrush(Color.FromRgb(246, 124, 95)) },
            { 64, new SolidColorBrush(Color.FromRgb(246, 94, 59)) },
            { 128, new SolidColorBrush(Color.FromRgb(237, 207, 114)) },
            { 256, new SolidColorBrush(Color.FromRgb(237, 204, 97)) },
            { 512, new SolidColorBrush(Color.FromRgb(237, 200, 80)) },
            { 1024, new SolidColorBrush(Color.FromRgb(237, 197, 63)) },
            { 2048, new SolidColorBrush(Color.FromRgb(237, 194, 46)) },
            // ... Add colors for other tile values using Color.FromRgb(red, green, blue)
        };

        public readonly Dictionary<int, SolidColorBrush> _fontColors = new Dictionary<int, SolidColorBrush>()
        {
            { 0, new SolidColorBrush(Color.FromRgb(119, 110, 101)) },
            { 1, new SolidColorBrush(Color.FromRgb(249, 246, 242)) },
            {2, new SolidColorBrush(Color.FromRgb(187, 173, 160))}
        };
    }
}
