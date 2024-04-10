using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.IO;
using System. Text;  



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
        static readonly string _workingDirectory = Environment.CurrentDirectory;
        static readonly string ProjectDirectory = Directory.GetParent(_workingDirectory).Parent.Parent.FullName;
        readonly string _path = ProjectDirectory + @"\PreviousGame.txt";

        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists(_path))
            {
                bool previousGameLoaded = DataWindow_Opening();
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

            for (int i = 0; i < _grid.GetLength(0); i++)
            {
                for (int j = 0; j < _grid.GetLength(1); j++)
                {
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
                        cellcolor = _colorDictionary[NumberInRange(_grid[i, j])];
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


        private void DataWindow_Closing(object? sender, CancelEventArgs e)
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
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

                // Write the string array to a new file named "WriteLines.txt".
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(projectDirectory, "PreviousGame.txt")))
                {
                    outputFile.WriteLine("Best:"+_bestScore);
                    outputFile.WriteLine("Current:"+_currentScore);
                    for (int i = 0; i < _grid.GetLength(0); i++)
                    {
                        for (int j = 0; j < _grid.GetLength(1); j++)
                        {
                            outputFile.WriteLine(_grid[i,j]);
                        }
                    }
                }
            }
        }
        private bool DataWindow_Opening()
        {
            var f = new FileInfo(_path);

            // MessageBox.Show("Do you want to save your LAST GAME and BEST?");
            string msg = "Do you want to load SAVED GAME and BEST SCORE?";
            MessageBoxResult result = 
                MessageBox.Show(
                    msg, 
                    "2048_game", 
                    MessageBoxButton.YesNo, 
                    MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                int row = -2;
                List<string> res = null;
                
                using (FileStream fs = File.Open(_path, FileMode.Open, FileAccess.Read, FileShare.None))  
                {  
                    byte[] b = new byte[1024];  
                    UTF8Encoding temp = new UTF8Encoding(true);  
                    
                    while (fs.Read(b,0,b.Length) > 0)  
                    {
                        res = temp.GetString(b).Split('\n').ToList();
                    }
                }

                for (int i = 0; i < res.Count - 1; i++)
                {
                    if (res[i].Contains("Best:"))
                    {
                        string changedString = res[i].Substring(5);  // Extract the part after "Best:"
                        int cellValue = int.Parse(changedString);
                        _bestScore = cellValue;                        
                        row += 1;
                    }
                    else if (res[i].Contains("Current:"))
                    {
                        string changedString = res[i].Substring(8);  // Extract the part after "Best:"
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
            else
            {
                return false;
            }
        }

    }
}