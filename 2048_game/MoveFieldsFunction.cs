namespace _2048_game
{
    public class MoveFieldsFunction
    {
        public (bool, int) MoveFields(string direction, int[,] field)
        {
            int new_score = 0;
            bool moved = false;
            for (int i = 0; i < field.GetLength(0); i++)
            {
                bool lmoved = false;
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

                                        else if (field[i, j - iterColumn] == field[i, j - iterColumnOrigin] &&
                                                 iterColumn <=2)
                                        {
                                            field[i, j - iterColumn] += field[i, j - iterColumnOrigin];
                                            field[i, j - iterColumnOrigin] = 0;
                                            new_score += field[i, j - iterColumn];
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
                                        else if (field[i - iterRow, j] == field[i - iterRowOrigin, j] &&
                                                 lmoved == false)
                                        {
                                            field[i - iterRow, j] += field[i - iterRowOrigin, j];
                                            field[i - iterRowOrigin, j] = 0;
                                            new_score += field[i - iterRow, j];

                                            moved = true;
                                            lmoved = true;
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
                bool lmoved = false;
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

                                        else if (field[i, j + iterColumn] == field[i, j + iterColumnOrigin] &&
                                                 iterColumn <=2)
                                        {
                                            field[i, j + iterColumn] += field[i, j + iterColumnOrigin];
                                            field[i, j + iterColumnOrigin] = 0;
                                            new_score += field[i, j + iterColumn];
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

                            case "d": //Down - does not work
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
                                        else if (field[i + iterRow, j] == field[i + iterRowOrigin, j] &&
                                                 lmoved == false)
                                        {
                                            field[i + iterRow, j] += field[i + iterRowOrigin, j];
                                            field[i + iterRowOrigin, j] = 0;
                                            new_score += field[i + iterRow, j];
                                            moved = true;
                                            lmoved = true;
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

            return (moved, new_score);
        }
    }
}