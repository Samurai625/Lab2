using System;

class Task15
{
    public static void Run()
    {
        Console.Write("Введіть кількість рядків: ");
        int rows = int.Parse(Console.ReadLine());
        Console.Write("Введіть кількість стовпців: ");
        int cols = int.Parse(Console.ReadLine());

        FillType fillType = MatrixUtils.AskFillType();

        int[,]? matrix = MatrixUtils.GetMatrix(rows, cols, fillType);
        if (matrix == null) return;

        Console.WriteLine("Початкова матриця:");
        MatrixUtils.PrintMatrix(matrix);

        SwapMinMaxInRows(matrix);

        Console.WriteLine("Матриця після обміну:");
        MatrixUtils.PrintMatrix(matrix);
    }

    static void SwapMinMaxInRows(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            int min = 0, max = 0;
            for (int j = 1; j < cols; j++)
            {
                if (matrix[i, j] < matrix[i, min]) min = j;
                if (matrix[i, j] > matrix[i, max]) max = j;
            }
            (matrix[i, min], matrix[i, max]) = (matrix[i, max], matrix[i, min]);
        }
    }
}
