using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace _2048_game
{
    public partial class MainWindow
    {
        private const int GridSize = 4;
        private int[,] _grid = new int[GridSize, GridSize];
        private int _currentScore;
        private int _bestScore;
        private static readonly TileColors TileColors = new TileColors();
        private readonly Dictionary<int, SolidColorBrush> _colorDictionary = TileColors._tileColors;
        private readonly Dictionary<int, SolidColorBrush> _colorFontDictionary = TileColors.FontColors;
        private readonly Dictionary<int, SolidColorBrush> _colorDictionaryDark = TileColors.TileColorsDark;
        private readonly Dictionary<int, SolidColorBrush> _colorFontDictionaryDark = TileColors.FontColorsDark;
        private readonly TilesMovement _tilesMovement = new TilesMovement();

        public MainWindow()
        {
            InitializeComponent();
            this.KeyUp += (sender, e) =>
            {
                var (moved, newScore) = _tilesMovement.Key_Pressed(e, _grid);
                
                _currentScore += newScore;
                if (_tilesMovement.CheckGameEnd(_grid))
                {
                    _bestScore = _currentScore;
                    InitializeGrid(true);
                }
                else if (moved)
                {
                    _tilesMovement.AddRandomTile(GridSize, _grid);
                    InitializeGrid(false);
                }
            };
            
        }

        private void StartGame()
        {
            _tilesMovement.AddRandomTile(GridSize, _grid);
            _tilesMovement.AddRandomTile(GridSize, _grid);
            InitializeGrid(false);
        }
        
        private Border CreateCell(int row, int col, string text, SolidColorBrush bordercolor,
            SolidColorBrush fontcolorsmall, SolidColorBrush fontcolorbig, SolidColorBrush cellcolor)
        {
            Border border = new Border
            {
                BorderBrush = bordercolor,
                BorderThickness = new Thickness(15)
            };

            Grid cellgrid = new Grid
            {
                Background = cellcolor // Use color from dictionary
            };
            if (text == "0")
            {
                text = "";
            }
            TextBlock tile = new TextBlock
            {
                Text = text,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                FontSize = 45,
                FontWeight = FontWeights.Bold
            };

            if (_grid[row, col] <= 4)
            {
                tile.Foreground = fontcolorsmall; // Ensure text is visible
            }
            else
            {
                tile.Foreground = fontcolorbig; // Ensure text is visible
            }

            cellgrid.Children.Add(tile); // Add TextBlock to the cell Grid

            border.Child = cellgrid;

            Grid.SetRow(border, row);
            Grid.SetColumn(border, col);

            return border;
        }

        private int NumberInRange(int number)
        {
            if (number > 2048)
            {
                number = 3000;
            }

            return number;
        }
        private void InitializeGrid(bool endGame)
        {
            HerniPole.Children.Clear(); // Clear the grid before adding new tiles
            ScoreTextBlock.Text = $"Score: {_currentScore}";
            BestScoreTextBlock.Text = $"Best: {_bestScore}";
            
            SolidColorBrush bordercolor;
            SolidColorBrush fontcolorsmall;
            SolidColorBrush fontcolorbig;
            SolidColorBrush cellcolor;
            if (endGame)
            {
                bordercolor = _colorFontDictionaryDark[2];
                fontcolorsmall = _colorFontDictionaryDark[0];
                fontcolorbig = _colorFontDictionaryDark[1];
            }
            else
            {
                bordercolor = _colorFontDictionary[2];
                fontcolorsmall = _colorFontDictionary[0];
                fontcolorbig = _colorFontDictionary[1];
            }

            int maxValue = 0;
            for (int i = 0; i < _grid.GetLength(0); i++)
            {
                for (int j = 0; j < _grid.GetLength(1); j++)
                {
                    if (_grid[i, j] > maxValue)
                    {
                        maxValue = _grid[i, j];
                    }
                    if (endGame)
                    {
                        cellcolor = _colorDictionaryDark[NumberInRange(_grid[i, j])];
                        TextBlock gameOverText = new TextBlock
                        {
                            Text = "!!!!!GAME OVER!!!!!",
                            FontSize = 40,
                            FontWeight = FontWeights.Bold,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Foreground = Brushes.White
                        };

                        HerniPole.Children.Add(gameOverText);
                        Grid.SetRow(gameOverText, 1); // Place in the center (assuming 4 rows)
                        Grid.SetColumnSpan(gameOverText, 4); // Span across all columns
                    }
                    else
                    {
                        cellcolor = cellcolor = _colorDictionary[NumberInRange(_grid[i, j])];
                    }

                    Border border = CreateCell(i, j, _grid[i, j].ToString(), bordercolor, fontcolorsmall, fontcolorbig,
                        cellcolor);
                    

                    HerniPole.Children.Add(border); // Add bordered cell to the outer Grid 
                }
            }

            
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            _grid = new int[GridSize, GridSize];
            if (_currentScore > _bestScore)
            {
                _bestScore = _currentScore;
            }

            _currentScore = 0;
            StartGame();
        }

        private void NewGameButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                NewGameButton_Click(sender, e); 
            }
        }
        
    }
}