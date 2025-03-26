using System;

class Task15
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

        SwapMinMaxInRows(matrix);

        Console.WriteLine("Матриця після обміну мінімального та максимального елементів:");
        PrintMatrix(matrix);
    }

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

    static void SwapMinMaxInRows(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            int maxIndex = 0;
            int minIndex = 0;

            for (int j = 1; j < cols; j++)
            {
                if (matrix[i, j] > matrix[i, maxIndex])
                {
                    maxIndex = j;
                }

                if (matrix[i, j] < matrix[i, minIndex])
                {
                    minIndex = j;
                }
            }

            int temp = matrix[i, maxIndex];
            matrix[i, maxIndex] = matrix[i, minIndex];
            matrix[i, minIndex] = temp;
        }
    }
}