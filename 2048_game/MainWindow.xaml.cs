using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.IO;
using System.Text;


namespace _2048_game
{
    public partial class MainWindow
    {
        const int GridSize = 4;
        private int[,] _grid = new int[GridSize, GridSize];
        private int _currentScore;
        private int _bestScore;
        private static readonly TileColors TileColors = new TileColors();
        private readonly Dictionary<int, SolidColorBrush> _colorDictionary = TileColors._tileColors;
        private readonly Dictionary<int, SolidColorBrush> _colorFontDictionary = TileColors.FontColors;
        private readonly Dictionary<int, SolidColorBrush> _colorDictionaryDark = TileColors.TileColorsDark;
        private readonly Dictionary<int, SolidColorBrush> _colorFontDictionaryDark = TileColors.FontColorsDark;
        private readonly TilesMovement _tilesMovement = new TilesMovement();
        private readonly Ui _ui = new Ui();
        static readonly string WorkingDirectory = Environment.CurrentDirectory;
        static readonly string? ProjectDirectory = Directory.GetParent(WorkingDirectory)?.Parent?.Parent?.FullName;
        private readonly string Path = ProjectDirectory + @"\PreviousGame.txt";

        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists(Path))
            {
                bool previousGameLoaded = LoadPreviousGameState();
                if (previousGameLoaded)
                {
                    InitializeGrid(false);
                }
                else
                {
                    StartGame();
                }
            }
            else
            {
                StartGame();
            }

            this.KeyUp += (sender, e) =>
            {
                var (moved, newScore) = _tilesMovement.Key_Pressed(e, _grid);
                _currentScore += newScore;
                if (_currentScore > _bestScore)
                {
                    _bestScore = _currentScore;
                }

                if (_tilesMovement.CheckGameEnd(_grid))
                {
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
            //Setting colors
            SolidColorBrush borderColor;
            SolidColorBrush fontColorSmall;
            SolidColorBrush fontColorBig;
            SolidColorBrush cellColor;
            if (endGame)
            {
                borderColor = _colorFontDictionaryDark[2];
                fontColorSmall = _colorFontDictionaryDark[0];
                fontColorBig = _colorFontDictionaryDark[1];
            }
            else
            {
                borderColor = _colorFontDictionary[2];
                fontColorSmall = _colorFontDictionary[0];
                fontColorBig = _colorFontDictionary[1];
            }

            Border.BorderBrush = borderColor;

            for (int row = 0; row < _grid.GetLength(0); row++)
            {
                for (int col = 0; col < _grid.GetLength(1); col++)
                {
                    if (endGame)
                    {
                        cellColor = _colorDictionaryDark[NumberInRange(_grid[row, col])];
                        TextBlock gameOverText = new TextBlock
                        {
                            Text = "GAME OVER!",
                            FontSize = 55,
                            FontWeight = FontWeights.Bold,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Foreground = Brushes.White
                        };

                        HerniPole.Children.Add(gameOverText);
                        Grid.SetRow(gameOverText, 1); // Place in the center
                        Grid.SetColumnSpan(gameOverText, 4); // Span across all columns
                    }
                    else
                    {
                        cellColor = _colorDictionary[NumberInRange(_grid[row, col])];
                    }

                    Border border = Ui.CreateCell(row, col, _grid, borderColor, fontColorSmall, fontColorBig,
                        cellColor);


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

        private bool LoadPreviousGameState()
        {
            const string msg = "Do you want to load SAVED GAME and BEST SCORE?";
            MessageBoxResult result =
                MessageBox.Show(
                    msg,
                    "2048_game",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    int row = -2;
                    List<string>? res = null;

                    using (FileStream fs = File.Open(Path, FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        byte[] b = new byte[1024];
                        UTF8Encoding temp = new UTF8Encoding(true);

                        while (fs.Read(b, 0, b.Length) > 0) //load file content in res
                        {
                            res = temp.GetString(b).Split('\n').ToList();
                        }
                    }

                    //try recreating grid
                    for (int i = 0; i < res.Count - 1; i++)
                    {
                        if (res[i].Contains("Best:"))
                        {
                            string changedString = res[i].Substring(5); // Extract the part after "Best:"
                            int cellValue = int.Parse(changedString);
                            _bestScore = cellValue;
                            row += 1;
                        }
                        else if (res[i].Contains("Current:"))
                        {
                            string changedString = res[i].Substring(8); // Extract the part after "Best:"
                            int cellValue = int.Parse(changedString);
                            _currentScore = cellValue;
                            row += 1;
                        }
                        else
                        {
                            int gridRow = row / 4;
                            int gridCol = row % 4;
                            _grid[gridRow, gridCol] = int.Parse(res[i]);
                            row += 1;
                        }
                    }

                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void HandleClosingApp(object? sender, CancelEventArgs e)
        {
            // MessageBox.Show("Do you want to save your LAST GAME and BEST?");
            string msg = "Do you want to save your LAST GAME and BEST SCORE?";
            MessageBoxResult result =
                MessageBox.Show(
                    msg,
                    "2048_game",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Exclamation);
            if (result == MessageBoxResult.Yes)
            {
                string workingDirectory = Environment.CurrentDirectory;
                string? projectDirectory = Directory.GetParent(workingDirectory)?.Parent?.Parent?.FullName;

                // Write the string array to a new file named "WriteLines.txt".
                using StreamWriter outputFile =
                    new StreamWriter(System.IO.Path.Combine(projectDirectory, "PreviousGame.txt"));
                outputFile.WriteLine("Best:" + _bestScore);
                outputFile.WriteLine("Current:" + _currentScore);
                for (int row = 0; row < _grid.GetLength(0); row++)
                {
                    for (int col = 0; col < _grid.GetLength(1); col++)
                    {
                        outputFile.WriteLine(_grid[row, col]);
                    }
                }
            }
        }
    }
}