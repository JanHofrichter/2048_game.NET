using System.Collections.Generic;
using System.Windows.Media;

namespace _2048_game
{
    public class TileColors
    {
        private double darkness = 0.5;
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
        public readonly Dictionary<int, SolidColorBrush> _tileColorsDark = new Dictionary<int, SolidColorBrush>()
        {
            { 0, new SolidColorBrush(Color.FromRgb((int)(204 * 0.5), (int)(192 * 0.5), (int)(179 * 0.5))) },
            { 2, new SolidColorBrush(Color.FromRgb((int)(238 * 0.5), (int)(228 * 0.5), (int)(218 * 0.5))) },
            { 4, new SolidColorBrush(Color.FromRgb((int)(237 * 0.5), (int)(224 * 0.5), (int)(200 * 0.5))) },
            { 8, new SolidColorBrush(Color.FromRgb((int)(242 * 0.5), (int)(177 * 0.5), (int)(121 * 0.5))) },
            { 16, new SolidColorBrush(Color.FromRgb((int)(245 * 0.5), (int)(149 * 0.5), (int)(99 * 0.5))) },
            { 32, new SolidColorBrush(Color.FromRgb((int)(246 * 0.5), (int)(124 * 0.5), (int)(95 * 0.5))) },
            { 64, new SolidColorBrush(Color.FromRgb((int)(246 * 0.5), (int)(94 * 0.5), (int)(59 * 0.5))) },
            { 128, new SolidColorBrush(Color.FromRgb((int)(237 * 0.5), (int)(207 * 0.5), (int)(114 * 0.5))) },
            { 256, new SolidColorBrush(Color.FromRgb((int)(237 * 0.5), (int)(204 * 0.5), (int)(97 * 0.5))) },
            { 512, new SolidColorBrush(Color.FromRgb((int)(237 * 0.5), (int)(200 * 0.5), (int)(80 * 0.5))) },
            { 1024, new SolidColorBrush(Color.FromRgb((int)(237 * 0.5), (int)(197 * 0.5), (int)(63 * 0.5))) },
            { 2048, new SolidColorBrush(Color.FromRgb((int)(237 * 0.5), (int)(194 * 0.5), (int)(46 * 0.5))) },

            // ... Add colors for other tile values using Color.FromRgb(red, green, blue)
        };

        public readonly Dictionary<int, SolidColorBrush> _fontColors = new Dictionary<int, SolidColorBrush>()
        {
            { 0, new SolidColorBrush(Color.FromRgb(119, 110, 101)) },
            { 1, new SolidColorBrush(Color.FromRgb(249, 246, 242)) },
            {2, new SolidColorBrush(Color.FromRgb(187, 173, 160))}
        };
        
        public readonly Dictionary<int, SolidColorBrush> _fontColorsDark = new Dictionary<int, SolidColorBrush>()
        {
            { 0, new SolidColorBrush(Color.FromRgb((int)(119 * 0.5), (int)(110 * 0.5), (int)(101 * 0.5))) },
            { 1, new SolidColorBrush(Color.FromRgb((int)(249 * 0.5), (int)(246 * 0.5), (int)(242 * 0.5))) },
            { 2, new SolidColorBrush(Color.FromRgb((int)(187 * 0.5), (int)(173 * 0.5), (int)(160 * 0.5))) },
        };
    }
}
