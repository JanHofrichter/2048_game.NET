using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace _2048_game
{
    public partial class MainWindow
    {
        private readonly Random _random = new Random();
        private const int GridSize = 4;
        private int[,] _grid = new int[GridSize, GridSize];
        private int _currentScore;
        private int _bestScore;
        private static readonly TileColors TileColors = new TileColors();
        private readonly Dictionary<int, SolidColorBrush> _colorDictionary = TileColors._tileColors;
        private readonly Dictionary<int, SolidColorBrush> _colorFontDictionary = TileColors._fontColors;
        
        public MainWindow()
        {
            InitializeComponent();
            
            MoveFieldsFunction moveFieldsFunction = new MoveFieldsFunction();


            this.KeyUp += (sender, e) => Key_Pressed(e, moveFieldsFunction);
        }

        private void StartGame()
        {
            AddRandomTile();
            AddRandomTile();
            InitializeGrid();
        }

        private bool CheckGameEnd(int[,] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] == 0)
                    {
                        return false;
                    }
                    else
                    {
                        try
                        {
                            if (field[i, j] == field[i + 1, j])
                            {
                                return false;
                            }
                        }
                        catch
                        {
                            // ignored
                        }

                        try
                        {
                            if (field[i, j] == field[i, j + 1])
                            {
                                return false;
                            }
                        }
                        catch
                        {
                            //ignored
                        }
                    }
                }
            }

            return true;
        }

        private void Key_Pressed(KeyEventArgs e,
            MoveFieldsFunction moveFieldsFunction)
        {
            var (moved, newScore) = e.Key switch
            {
                Key.Left => moveFieldsFunction.MoveFields("l", _grid),
                Key.Right => moveFieldsFunction.MoveFields("r", _grid),
                Key.Up => moveFieldsFunction.MoveFields("u", _grid),
                Key.Down => moveFieldsFunction.MoveFields("d", _grid),
                _ => (false, 0)
            };
            _currentScore += newScore;
            // return (moved.Item1, moved.Item2);
            if (CheckGameEnd(_grid))
            {
                Console.WriteLine("GAME END!");
                _bestScore = _currentScore;
                ScoreTextBlock.Text = $"Score: {_currentScore}";
                BestScoreTextBlock.Text = $"Best: {_bestScore}";
            }
            else if (moved)
            {
                AddRandomTile();
                InitializeGrid();
            }
            
        }

        private void InitializeGrid()
        {
            HerniPole.Children.Clear(); // Clear the grid before adding new tiles
            ScoreTextBlock.Text = $"Score: {_currentScore}";
            BestScoreTextBlock.Text = $"Best: {_bestScore}";
            for (int i = 0; i < _grid.GetLength(0); i++)
            {
                for (int j = 0; j < _grid.GetLength(1); j++)
                {
                    Border border = new Border
                    {
                        BorderBrush = _colorFontDictionary[2],
                        BorderThickness = new Thickness(10)
                    };
                    
                    Grid cellgrid = new Grid
                    {
                        Background = _colorDictionary[_grid[i, j]] // Use color from dictionary
                    };

                    TextBlock tile = new TextBlock
                    {
                        Text = _grid[i, j].ToString(),
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        FontSize = 30,
                        FontWeight = FontWeights.Bold
                    };

                    if (_grid[i, j] <= 4)
                    {
                        tile.Foreground = _colorFontDictionary[0]; // Ensure text is visible
                    }
                    else
                    {
                        tile.Foreground = _colorFontDictionary[1]; // Ensure text is visible
                    }

                    cellgrid.Children.Add(tile); // Add TextBlock to the cell Grid

                    border.Child = cellgrid;

                    Grid.SetRow(border, i);
                    Grid.SetColumn(border, j);

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

        private void AddRandomTile()
        {
            int row, col;
            do
            {
                row = _random.Next(0, GridSize);
                col = _random.Next(0, GridSize);
            } while (_grid[row, col] != 0);

            _grid[row, col] = _random.Next(4) != 1 ? 2 : 4;
        }
    }
}