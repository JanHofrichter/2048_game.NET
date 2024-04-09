namespace _2048_game
{
    public class MoveFieldsFunction
    {
        public (bool, int) MoveFields(string direction, int[,] field)
        {
            int newScore = 0;
            bool moved = false;
            switch (direction)
            {
                case "l": //Left
                    for (int i = 0; i < field.GetLength(0); i++)
                    {
                        int merged = 0;
                        for (int j = 0; j < field.GetLength(1); j++)
                        {
                            if (field[i, j] != 0)
                            {
                                int iterNext = 1;
                                int iterOriginal = 0;
                                while (true)
                                {
                                    try
                                    {
                                        if (field[i, j - iterNext] == 0)
                                        {
                                            field[i, j - iterNext] = field[i, j - iterOriginal];
                                            field[i, j - iterOriginal] = 0;
                                            moved = true;
                                        }

                                        else if (field[i, j - iterNext] == field[i, j - iterOriginal] &&
                                                 field[i, j - iterOriginal] != merged)
                                        {
                                            field[i, j - iterNext] += field[i, j - iterOriginal];
                                            field[i, j - iterOriginal] = 0;
                                            merged = field[i, j - iterNext];
                                            newScore += field[i, j - iterNext];
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
                case "r": //right
                    for (int i = field.GetLength(0) - 1; i >= 0; i--)
                    {
                        int merged = 0;
                        for (int j = field.GetLength(1) - 1; j >= 0; j--)
                        {
                            if (field[i, j] != 0)
                            {
                                int iterNext = 1;
                                int iterOriginal = 0;
                                while (true)
                                {
                                    try
                                    {
                                        if (field[i, j + iterNext] == 0)
                                        {
                                            field[i, j + iterNext] = field[i, j + iterOriginal];
                                            field[i, j + iterOriginal] = 0;
                                            moved = true;
                                        }

                                        else if (field[i, j + iterNext] == field[i, j + iterOriginal] &&
                                                 field[i, j + iterOriginal] != merged)
                                        {
                                            field[i, j + iterNext] += field[i, j + iterOriginal];
                                            field[i, j + iterOriginal] = 0;
                                            merged = field[i, j + iterNext];
                                            newScore += field[i, j + iterNext];
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
                case "u": //upper
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
                                         if (field[j - iterNext, i] == 0)
                                         {
                                             field[j - iterNext, i] = field[j - iterOriginal, i];
                                             field[j - iterOriginal, i] = 0;
                                             moved = true;
                                         }
                                         else if (field[j - iterNext, i] == field[j - iterOriginal, i] &&
                                                  field[j - iterOriginal, i] != merged)
                                         {
                                             field[j - iterNext, i] += field[j - iterOriginal, i];
                                             field[j - iterOriginal, i] = 0;
                                             merged = field[j - iterNext, i];
                                             newScore += field[j + iterNext, i];
                                         
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
                case "d": //upper
                    for (int i = 0; i < field.GetLength(0); i++)
                    {
                        int merged = 0;
                        for (int j = field.GetLength(1) - 1; j >= 0; j--)
                        {
                            if (field[j, i] != 0)
                            {
                                int iterNext = 1;
                                int iterOriginal = 0;
                                 while (true)
                                 {
                                     try
                                     {
                                         if (field[j + iterNext, i] == 0)
                                         {
                                             field[j + iterNext, i] = field[j + iterOriginal, i];
                                             field[j + iterOriginal, i] = 0;
                                             moved = true;
                                         }
                                         else if (field[j + iterNext, i] == field[j + iterOriginal, i] &&
                                                  field[j + iterOriginal, i] != merged)
                                         {
                                             field[j + iterNext, i] += field[j + iterOriginal, i];
                                             field[j + iterOriginal, i] = 0;
                                             merged = field[j + iterNext, i];
                                             newScore += field[j + iterNext, i];
                                         
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
    }
}