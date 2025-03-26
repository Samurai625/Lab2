using System;
using System.Data;

class Task14
{
    public static void Run()
    {
        Console.Write("Введіть кількість рядків: ");
        int rows = int.Parse(Console.ReadLine());
        Console.Write("Введіть кількість стовпців: ");
        int cols = int.Parse(Console.ReadLine());

        int[,] matrix = FillMatrix(rows, cols);
        Console.WriteLine("Початкова матриця:");
        PrintMatrix(matrix);

        SortOddColumns(matrix, rows, cols);

        SortEvenColumns(matrix, rows, cols);
        Console.WriteLine("Матриця після сортування:");
        PrintMatrix(matrix);

        static int[,] FillMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];
            Random random = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = random.Next(-50, 51);
                }
            }

            return matrix;
        }

        static void SortOddColumns(int[,] matrix, int rows, int cols)
        {
            for (int j = 0; j < cols; j++)
            {
                if ((j + 1) % 2 != 0)
                {
                    int[] column = new int[rows];
                    for (int i = 0; i < rows; i++)
                    {
                        column[i] = matrix[i, j];
                    }

                    Array.Sort(column);
                    for (int i = 0; i < rows; i++)
                    {
                        matrix[i, j] = column[i];
                    }
                }
            }
        }

        static void SortEvenColumns(int[,] matrix, int rows, int cols)
        {
            for (int j = 0; j < cols; j++)
            {
                if ((j + 1) % 2 == 0)
                {
                    int[] column = new int[rows];

                    for (int i = 0; i < rows; i++)
                    {
                        column[i] = matrix[i, j];
                    }

                    Array.Sort(column);
                    Array.Reverse(column);

                    for (int i = 0; i < rows; i++)
                    {
                        matrix[i, j] = column[i];
                    }
                }
            }
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j] + "\t"}");
                }

                Console.WriteLine();
            }
        }
    }
}
