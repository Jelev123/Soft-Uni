using System;


namespace Bees
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = new char[n, n];
            int beeRows = 0;
            int beeCols = 0;
            int flowers = 0;
            

            for (int row = 0; row < n; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row,col] == 'B')
                    {
                        beeRows = row;
                        beeCols = col;
                    }
                }
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                if (command == "right")
                {
                    matrix[beeRows, beeCols] = '.';

                    beeCols++;
                    if (beeCols < n)
                    {
                        if (matrix[beeRows, beeCols] == 'f')
                        {
                            flowers++;
                            matrix[beeRows, beeCols] = 'B';

                        }
                        else if (matrix[beeRows, beeCols] == 'O')
                        {
                            matrix[beeRows, beeCols] = '.';
                            beeCols++;
                            matrix[beeRows, beeCols] = 'B';
                        }

                    }
                    else
                    {
                        Console.WriteLine("The bee got lost!");
                        break;
                    }


                }
                else if (command == "left")
                {
                    matrix[beeRows, beeCols] = '.';

                    beeCols--;
                    if (beeCols >= 0 )
                    {
                        if (matrix[beeRows, beeCols] == 'f')
                        {
                            flowers++;
                            matrix[beeRows, beeCols] = 'B';

                        }
                        else if (matrix[beeRows, beeCols] == 'O')
                        {
                            matrix[beeRows, beeCols] = '.';
                            beeCols--;

                            matrix[beeRows, beeCols] = 'B';
                        }
                    }
                    else
                    {
                        Console.WriteLine("The bee got lost!");
                        break;
                    }
                }
                else if (command == "up")
                {
                    matrix[beeRows, beeCols] = '.';

                    beeRows--;
                    if (beeRows >= 0)
                    {
                        if (matrix[beeRows, beeCols] == 'f')
                        {
                            flowers++;
                            matrix[beeRows, beeCols] = 'B';

                        }
                        else if (matrix[beeRows, beeCols] == 'O')
                        {
                            matrix[beeRows, beeCols] = '.';
                            beeRows--;
                            matrix[beeRows, beeCols] = 'B';
                        }
                    }
                    else
                    {
                        Console.WriteLine("The bee got lost!");
                        break;
                    }
                }
                else if (command == "down")
                {
                    matrix[beeRows, beeCols] = '.';
                    beeRows++;
                    if (beeRows < n)
                    {
                        if (matrix[beeRows, beeCols] == 'f')
                        {
                            flowers++;
                            matrix[beeRows, beeCols] = 'B';

                        }
                        else if (matrix[beeRows,beeCols] == 'O')
                        {
                            matrix[beeRows, beeCols] = '.';
                            beeRows++;
                            if (matrix[beeRows,beeCols] == 'f')
                            {
                                flowers++;
                            }
                            matrix[beeRows, beeCols] = 'B';
                        }
                    }
                    else
                    {
                        Console.WriteLine("The bee got lost!");
                        break;
                    }

                }

                command = Console.ReadLine();
            }
            if (flowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {flowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5-flowers} flowers more"
                );
            }


            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row,col]);
                }

                Console.WriteLine();
            }


        }
    }
}
