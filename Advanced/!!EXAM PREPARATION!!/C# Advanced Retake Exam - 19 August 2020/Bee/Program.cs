using System;

namespace Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] territory = new char[size, size];

            int rowBee = int.MinValue;
            int colBee = int.MinValue;

            for (int row = 0; row < size; row++)
            {
                char[] input = Console.ReadLine()
                    .ToCharArray();
                for (int col = 0; col < size; col++)
                {
                    territory[row, col] = input[col];

                    if (input[col] == 'B')
                    {
                        rowBee = row;
                        colBee = col;
                    }
                }
            }

            int polinatedFlowers = 0;
            int neededPolinatedFlowers = 5;


            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                territory[rowBee, colBee] = '.';

                if (input == "right")
                {
                    colBee += 1;
                    if (outOfArray(rowBee, colBee, size))
                    {
                        break;
                    }
                    if (territory[rowBee, colBee] == 'O')
                    {
                        territory[rowBee, colBee] = '.';
                        colBee += 1;
                        if (outOfArray(rowBee, colBee, size))
                        {
                            break;
                        }
                    }
                }

                else if (input == "left")
                {
                    colBee -= 1;
                    if (outOfArray(rowBee, colBee, size))
                    {
                        break;
                    }
                    if (territory[rowBee, colBee] == 'O')
                    {
                        territory[rowBee, colBee] = '.';
                        colBee -= 1;
                        if (outOfArray(rowBee, colBee, size))
                        {
                            break;
                        }
                    }
                }
                else if (input == "up")
                {
                    rowBee -= 1;
                    if (outOfArray(rowBee, colBee, size))
                    {
                        break;
                    }
                    if (territory[rowBee, colBee] == 'O')
                    {
                        territory[rowBee, colBee] = '.';
                        rowBee -= 1;
                        if (outOfArray(rowBee, colBee, size))
                        {
                            break;
                        }
                    }

                }
                else if (input == "down")
                {
                    rowBee += 1;
                    if (outOfArray(rowBee, colBee, size))
                    {
                        break;
                    }
                    if (territory[rowBee, colBee] == 'O')
                    {
                        territory[rowBee, colBee] = '.';
                        rowBee += 1;
                        if (outOfArray(rowBee, colBee, size))
                        {
                            break;
                        }
                    }

                }

                if (territory[rowBee, colBee] == 'f')
                {
                    polinatedFlowers++;
                    territory[rowBee, colBee] = '.';
                }

                territory[rowBee, colBee] = 'B';
            }

            if (outOfArray(rowBee, colBee, size))
            {
                Console.WriteLine($"The bee got lost!");
            }

            if (polinatedFlowers < neededPolinatedFlowers)
            {
                int needed = neededPolinatedFlowers - polinatedFlowers;
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {needed} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {polinatedFlowers} flowers!");
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"{territory[i, j]}");
                }
                Console.WriteLine();
            }
        }

        private static bool outOfArray(int row, int col, int size)
        {
            if (row < 0 || row >= size || col < 0 || col >= size)
            {
                return true;
            }
            else
            {

                return false;
            }

        }
    }
}

