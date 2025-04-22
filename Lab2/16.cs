using System;

class Task16
{
    public static void Run()
    {
        Console.Write("Введіть розмір квадратної матриці: ");
        int n = int.Parse(Console.ReadLine());

        FillType fillType = MatrixUtils.AskFillType();

        int[,]? matrix = MatrixUtils.GetMatrix(n, n, fillType);
        if (matrix == null) return;

        Console.WriteLine("Матриця:");
        MatrixUtils.PrintMatrix(matrix);

        (int sum, int count) = CalculateNegativeBelowDiagonal(matrix);
        Console.WriteLine($"Сума від'ємних: {sum}, Кількість: {count}");
    }

    static (int sum, int count) CalculateNegativeBelowDiagonal(int[,] matrix)
    {
        int sum = 0, count = 0;
        for (int i = 1; i < matrix.GetLength(0); i++)
            for (int j = 0; j < i; j++)
                if (matrix[i, j] < 0)
                {
                    sum += matrix[i, j];
                    count++;
                }

        return (sum, count);
    }
}
