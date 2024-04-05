using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;


namespace _2048_game
{
    public partial class MainWindow : Window
    {
        private readonly Random _random = new Random();
        private const int GridSize = 4;

        public MainWindow()
        {
            InitializeComponent();


            int[,] grid = new int[GridSize, GridSize];
            this.KeyUp += (sender, e) => Key_Pressed(sender, e, grid);

            AddRandomTile(grid);
            AddRandomTile(grid);
            InitializeGrid(grid);
        }

        private readonly Dictionary<int, SolidColorBrush> _tileColors = new Dictionary<int, SolidColorBrush>()
        {
            { 0, new SolidColorBrush(System.Windows.Media.Color.FromRgb(204, 192, 179)) },
            { 2, new SolidColorBrush(System.Windows.Media.Color.FromRgb(238, 228, 218)) }, 
            { 4, new SolidColorBrush(System.Windows.Media.Color.FromRgb(237, 224, 200)) }, 
            { 8, new SolidColorBrush(System.Windows.Media.Color.FromRgb(242, 177, 121)) },      
            { 16, new SolidColorBrush(System.Windows.Media.Color.FromRgb(245, 149, 99)) },     
            { 32, new SolidColorBrush(System.Windows.Media.Color.FromRgb(246, 124, 95)) },    
            { 64, new SolidColorBrush(System.Windows.Media.Color.FromRgb(246, 94, 59)) },    
            { 128, new SolidColorBrush(System.Windows.Media.Color.FromRgb(237, 207, 114)) },   
            { 256, new SolidColorBrush(System.Windows.Media.Color.FromRgb(237, 204, 97)) },    
            { 512, new SolidColorBrush(System.Windows.Media.Color.FromRgb(237, 200, 80)) },   
            { 1024, new SolidColorBrush(System.Windows.Media.Color.FromRgb(237, 197, 63)) },   
            { 2048, new SolidColorBrush(System.Windows.Media.Color.FromRgb(237, 194, 46)) },   
            

            // ... Add colors for other tile values using System.Windows.Media.Color.FromRgb(red, green, blue)
        };

        private void Key_Pressed(object sender, KeyEventArgs e, int[,] field)
        {
            switch (e.Key)
            {
                case Key.Left:
                    MoveFields("l", field);
                    break;
                case Key.Right:
                    MoveFields("r", field);
                    break;
                case Key.Up:
                    MoveFields("u", field);
                    break;
                case Key.Down:
                    MoveFields("d", field);
                    break;
            }

            InitializeGrid(field);
        }

        private void InitializeGrid(int[,] field)
        {
            HerniPole.Children.Clear(); // Clear the grid before adding new tiles

            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Grid cellgrid = new Grid();
                    cellgrid.Background = _tileColors[field[i, j]]; // Use color from dictionary
                    
                    TextBlock tile = new TextBlock();
                    tile.Text = field[i, j].ToString();
                    tile.HorizontalAlignment = HorizontalAlignment.Center;
                    tile.VerticalAlignment = VerticalAlignment.Center;
                    tile.FontSize = 40;
                    tile.FontWeight = FontWeights.Bold;
                    if (field[i, j] <= 4)
                    {
                        tile.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(119, 110, 101)); // Ensure text is visible
                    }
                    else
                    {
                        tile.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(249, 246, 242)); // Ensure text is visible
                    }
                    // tile.Background = _tileColors[field[i, j]]; // Use color from dictionary for the text

            
                    cellgrid.Children.Add(tile);  // Add TextBlock to the cell Grid

                    Grid.SetRow(cellgrid, i);
                    Grid.SetColumn(cellgrid, j);

                    HerniPole.Children.Add(cellgrid);  // Add cell Grid to the outer Grid
                }
            }
        }


        private void MoveFields(string direction, int[,] field)
        {
            bool moved = false;
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] != 0)
                    {
                        int iterColumn = 1;
                        int iterColumnOrigin = 0;
                        int iterRow = 1;
                        int iterRowOrigin = 0;
                        switch (direction)
                        {
                            case "l": //Left
                                while (true)
                                {
                                    try
                                    {
                                        if (field[i, j - iterColumn] == 0)
                                        {
                                            field[i, j - iterColumn] = field[i, j - iterColumnOrigin];
                                            field[i, j - iterColumnOrigin] = 0;
                                            moved = true;
                                        }

                                        else if (field[i, j - iterColumn] == field[i, j - iterColumnOrigin])
                                        {
                                            field[i, j - iterColumn] += field[i, j - iterColumnOrigin];
                                            field[i, j - iterColumnOrigin] = 0;
                                            moved = true;
                                        }
                                        else break;

                                        iterColumn += 1;
                                        iterColumnOrigin += 1;
                                    }
                                    catch
                                    {
                                        break;
                                    }
                                }

                                break;

                            case "u": //Up
                                while (true)
                                {
                                    try
                                    {
                                        if (field[i - iterRow, j] == 0)
                                        {
                                            field[i - iterRow, j] = field[i - iterRowOrigin, j];
                                            field[i - iterRowOrigin, j] = 0;
                                            moved = true;
                                        }
                                        else if (field[i - iterRow, j] == field[i - iterRowOrigin, j])
                                        {
                                            field[i - iterRow, j] += field[i - iterRowOrigin, j];
                                            field[i - iterRowOrigin, j] = 0;
                                            moved = true;
                                        }
                                        else break;

                                        iterRow += 1;
                                        iterRowOrigin += 1;
                                    }
                                    catch
                                    {
                                        break;
                                    }
                                }

                                break;
                        }
                    }
                }
            }

            for (int i = field.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = field.GetLength(1) - 1; j >= 0; j--)
                {
                    if (field[i, j] != 0)
                    {
                        int iterColumn = 1;
                        int iterColumnOrigin = 0;
                        int iterRow = 1;
                        int iterRowOrigin = 0;
                        switch (direction)
                        {
                            case "r": //Right
                                while (true)
                                {
                                    try
                                    {
                                        if (field[i, j + iterColumn] == 0)
                                        {
                                            field[i, j + iterColumn] = field[i, j + iterColumnOrigin];
                                            field[i, j + iterColumnOrigin] = 0;
                                            moved = true;
                                        }

                                        else if (field[i, j + iterColumn] == field[i, j + iterColumnOrigin])
                                        {
                                            field[i, j + iterColumn] += field[i, j + iterColumnOrigin];
                                            field[i, j + iterColumnOrigin] = 0;
                                            moved = true;
                                        }
                                        else break;

                                        iterColumn += 1;
                                        iterColumnOrigin += 1;
                                    }
                                    catch
                                    {
                                        break;
                                    }
                                }

                                break;

                            case "d": //Down
                                while (true)
                                {
                                    try
                                    {
                                        if (field[i + iterRow, j] == 0)
                                        {
                                            field[i + iterRow, j] = field[i + iterRowOrigin, j];
                                            field[i + iterRowOrigin, j] = 0;
                                            moved = true;
                                        }
                                        else if (field[i + iterRow, j] == field[i + iterRowOrigin, j])
                                        {
                                            field[i + iterRow, j] += field[i + iterRowOrigin, j];
                                            field[i + iterRowOrigin, j] = 0;
                                            moved = true;
                                        }
                                        else break;

                                        iterRow += 1;
                                        iterRowOrigin += 1;
                                    }
                                    catch
                                    {
                                        break;
                                    }
                                }

                                break;
                        }
                    }
                }
            }

            if (moved == true)
            {
                AddRandomTile(field);
            }
        }

        private void AddRandomTile(int[,] field)
        {
            int row, col;
            do
            {
                row = _random.Next(0, GridSize);
                col = _random.Next(0, GridSize);
            } while (field[row, col] != 0);

            field[row, col] = _random.Next(4) != 1 ? 2 : 4;
        }
    }
}