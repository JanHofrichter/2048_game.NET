using System.Collections.Generic;
using System.Windows.Media;

namespace _2048_game
{
    public class TileColors
    {
        public const double Darkness = 0.5;

        public readonly Dictionary<int, SolidColorBrush> _tileColors = new Dictionary<int, SolidColorBrush>(0)
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
            { 3000, new SolidColorBrush(Color.FromRgb(61, 59, 52)) }, // Color for others keys


            // ... Add colors for other tile values using Color.FromRgb(red, green, blue)
        };
        public readonly Dictionary<int, SolidColorBrush> TileColorsDark = new Dictionary<int, SolidColorBrush>()
        {
            { 0, new SolidColorBrush(Color.FromRgb((int)(249.0 * Darkness), (int)(246.0 * Darkness), (int)(242.0 * Darkness))) },
            { 2, new SolidColorBrush(Color.FromRgb((int)(238.0 * Darkness), (int)(228.0 * Darkness), (int)(218.0 * Darkness))) },
            { 4, new SolidColorBrush(Color.FromRgb((int)(237.0 * Darkness), (int)(224.0 * Darkness), (int)(200.0 * Darkness))) },
            { 8, new SolidColorBrush(Color.FromRgb((int)(242.0 * Darkness), (int)(177.0 * Darkness), (int)(121.0 * Darkness))) },
            { 16, new SolidColorBrush(Color.FromRgb((int)(245.0 * Darkness), (int)(149.0 * Darkness), (int)(99.0 * Darkness))) },
            { 32, new SolidColorBrush(Color.FromRgb((int)(246.0 * Darkness), (int)(124.0 * Darkness), (int)(95.0 * Darkness))) },
            { 64, new SolidColorBrush(Color.FromRgb((int)(246.0 * Darkness), (int)(94.0 * Darkness), (int)(59.0 * Darkness))) },
            { 128, new SolidColorBrush(Color.FromRgb((int)(237.0 * Darkness), (int)(207.0 * Darkness), (int)(114.0 * Darkness))) },
            { 256, new SolidColorBrush(Color.FromRgb((int)(237.0 * Darkness), (int)(204.0 * Darkness), (int)(97.0 * Darkness))) },
            { 512, new SolidColorBrush(Color.FromRgb((int)(237.0 * Darkness), (int)(200.0 * Darkness), (int)(80.0 * Darkness))) },
            { 1024, new SolidColorBrush(Color.FromRgb((int)(237.0 * Darkness), (int)(197.0 * Darkness), (int)(63.0 * Darkness))) },
            { 2048, new SolidColorBrush(Color.FromRgb((int)(237.0 * Darkness), (int)(194.0 * Darkness), (int)(46.0 * Darkness))) },
            { 3000, new SolidColorBrush(Color.FromRgb((int)(61.0 * Darkness), (int)(59.0 * Darkness), (int)(52.0 * Darkness))) }, // You can choose a different default color here


            // ... Add colors for other tile values using Color.FromRgb(red, green, blue)
        };

        public readonly Dictionary<int, SolidColorBrush> FontColors = new Dictionary<int, SolidColorBrush>()
        {
            { 0, new SolidColorBrush(Color.FromRgb(119, 110, 101)) },
            { 1, new SolidColorBrush(Color.FromRgb(249, 246, 242)) },
            {2, new SolidColorBrush(Color.FromRgb(187, 173, 160))},

        };
        
        public readonly Dictionary<int, SolidColorBrush> FontColorsDark = new Dictionary<int, SolidColorBrush>()
        {
            { 0, new SolidColorBrush(Color.FromRgb((int)(119 * 0.5), (int)(110 * 0.5), (int)(101 * 0.5))) },
            { 1, new SolidColorBrush(Color.FromRgb((int)(249 * 0.5), (int)(246 * 0.5), (int)(242 * 0.5))) },
            { 2, new SolidColorBrush(Color.FromRgb((int)(187 * 0.5), (int)(173 * 0.5), (int)(160 * 0.5))) },
        };

    }
}
