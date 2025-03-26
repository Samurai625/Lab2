using System;

class Task10
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

        SortRowsByIdx(matrix, rows, cols);
        Console.WriteLine("Матриця після сортування:");
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

    static void SwapRows(int[,] matrix, int row1, int row2, int cols)
    {
        for (int j = 0; j < cols; j++)
        {
            int temp = matrix[row1, j];
            matrix[row1, j] = matrix[row2, j];
            matrix[row2, j] = temp;
        }
    }

    static int PowProduct(int[,] matrix, int pow, int cols)
    {
        int idx = 1;
        for (int i = 0; i < cols; i++)
        {
            idx *= matrix[pow, i];
        }

        return idx;
    }

    static void SortRowsByIdx(int[,] matrix, int rows, int cols)
    {
        for (int i = 0; i < rows - 1; i++)
        {
            for (int k = 0; k < rows - 1; k++)
            {
                int product1 = PowProduct(matrix, k, cols);
                int product2 = PowProduct(matrix, k + 1, cols);

                if (product1 > product2)
                {
                    SwapRows(matrix, k, k + 1, cols);
                }
            }
        }
    }
}
            