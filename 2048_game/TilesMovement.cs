using System.Windows.Input;

namespace _2048_game
{
    public class TilesMovement
    {
        private readonly Random _random = new Random();

        public (bool, int) MoveTiles(string direction, int[,] field)
        {
            int newScore = 0;
            bool moved = false;
            switch (direction)
            {
                case "l": //Pressed left arrow key or A
                    for (int row = 0; row < field.GetLength(0); row++)
                    {
                        int merged = 0;
                        for (int column = 0; column < field.GetLength(1); column++)
                        {
                            if (field[row, column] != 0)
                            {
                                int iterNext = 1;
                                int iterOriginal = 0;
                                while (true)
                                {
                                    try
                                    {
                                        if (field[row, column - iterNext] == 0) //Move through free space (0)
                                        {
                                            field[row, column - iterNext] = field[row, column - iterOriginal];
                                            field[row, column - iterOriginal] = 0;
                                            moved = true;
                                        }

                                        else if (field[row, column - iterNext] ==
                                                 field[row, column - iterOriginal] && //Merge same tiles
                                                 field[row, column - iterOriginal] != merged)
                                        {
                                            field[row, column - iterNext] += field[row, column - iterOriginal];
                                            field[row, column - iterOriginal] = 0;
                                            merged = field[row, column - iterNext];
                                            newScore += field[row, column - iterNext];
                                            moved = true;
                                        }
                                        else break;

                                        iterNext += 1;
                                        iterOriginal += 1;
                                    }
                                    catch
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }

                    break;
                case "r": //Pressed right arrow key or D
                    for (int row = field.GetLength(0) - 1; row >= 0; row--)
                    {
                        int merged = 0;
                        for (int col = field.GetLength(1) - 1; col >= 0; col--)
                        {
                            if (field[row, col] != 0)
                            {
                                int iterNext = 1;
                                int iterOriginal = 0;
                                while (true)
                                {
                                    try
                                    {
                                        if (field[row, col + iterNext] == 0) //Move through free space (0)
                                        {
                                            field[row, col + iterNext] = field[row, col + iterOriginal];
                                            field[row, col + iterOriginal] = 0;
                                            moved = true;
                                        }

                                        else if (field[row, col + iterNext] ==
                                                 field[row, col + iterOriginal] && //Merge same tiles
                                                 field[row, col + iterOriginal] != merged)
                                        {
                                            field[row, col + iterNext] += field[row, col + iterOriginal];
                                            field[row, col + iterOriginal] = 0;
                                            merged = field[row, col + iterNext];
                                            newScore += field[row, col + iterNext];
                                            moved = true;
                                        }
                                        else break;

                                        iterNext += 1;
                                        iterOriginal += 1;
                                    }
                                    catch
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }

                    break;
                case "u": //Pressed up arrow key or W
                    for (int i = 0; i < field.GetLength(0); i++)
                    {
                        int merged = 0;
                        for (int j = 0; j < field.GetLength(1); j++)
                        {
                            if (field[j, i] != 0)
                            {
                                int iterNext = 1;
                                int iterOriginal = 0;
                                while (true)
                                {
                                    try
                                    {
                                        if (field[j - iterNext, i] == 0) //Move through free space (0)
                                        {
                                            field[j - iterNext, i] = field[j - iterOriginal, i];
                                            field[j - iterOriginal, i] = 0;
                                            moved = true;
                                        }
                                        else if (field[j - iterNext, i] ==
                                                 field[j - iterOriginal, i] && //Merge same tiles
                                                 field[j - iterOriginal, i] != merged)
                                        {
                                            field[j - iterNext, i] += field[j - iterOriginal, i];
                                            field[j - iterOriginal, i] = 0;
                                            merged = field[j - iterNext, i];
                                            newScore += field[j - iterNext, i];
                                            moved = true;
                                        }
                                        else break;

                                        iterNext += 1;
                                        iterOriginal += 1;
                                    }
                                    catch
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }

                    break;
                case "d": //Pressed down arrow key or S
                    for (int row = 0; row < field.GetLength(0); row++)
                    {
                        int merged = 0;
                        for (int col = field.GetLength(1) - 1; col >= 0; col--)
                        {
                            if (field[col, row] != 0)
                            {
                                int iterNext = 1;
                                int iterOriginal = 0;
                                while (true)
                                {
                                    try
                                    {
                                        if (field[col + iterNext, row] == 0) //Move through free space (0)
                                        {
                                            field[col + iterNext, row] = field[col + iterOriginal, row];
                                            field[col + iterOriginal, row] = 0;
                                            moved = true;
                                        }
                                        else if (field[col + iterNext, row] ==
                                                 field[col + iterOriginal, row] && //Merge same tiles
                                                 field[col + iterOriginal, row] != merged)
                                        {
                                            field[col + iterNext, row] += field[col + iterOriginal, row];
                                            field[col + iterOriginal, row] = 0;
                                            merged = field[col + iterNext, row];
                                            newScore += field[col + iterNext, row];

                                            moved = true;
                                        }
                                        else break;

                                        iterNext += 1;
                                        iterOriginal += 1;
                                    }
                                    catch
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }

                    break;
            }

            return (moved, newScore);
        }

        public (bool, int) Key_Pressed(KeyEventArgs e, int[,] field)
        {
            var (moved, newScore) = e.Key switch
            {
                Key.Left or Key.A => MoveTiles("l", field),
                Key.Right or Key.D => MoveTiles("r", field),
                Key.Up or Key.W => MoveTiles("u", field),
                Key.Down or Key.S => MoveTiles("d", field),
                _ => (false, 0)
            };
            return (moved, newScore);
        }

        public bool CheckGameEnd(int[,] field)
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

        public void AddRandomTile(int GridSize, int[,] field)
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