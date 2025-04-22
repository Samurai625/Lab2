public enum FillType
{
    Manual = 1,
    Random = 2
}

public static class MatrixUtils
{
    public static int[,] GetMatrix(int rows, int cols, FillType fillType)
    {
        return fillType == FillType.Manual
            ? ManualFill(rows, cols)
            : RandomFill(rows, cols);
    }

    private static int[,] ManualFill(int rows, int cols)
    {
        int[,] matrix = new int[rows, cols];
        Console.WriteLine("Введіть елементи матриці:");
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"[{i},{j}]: ");
                matrix[i, j] = int.Parse(Console.ReadLine()!);
            }

        return matrix;
    }

    private static int[,] RandomFill(int rows, int cols)
    {
        int[,] matrix = new int[rows, cols];
        Random rand = new Random();
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                matrix[i, j] = rand.Next(-50, 51);
        return matrix;
    }

    public static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write($"{matrix[i, j]}\t");
            Console.WriteLine();
        }
    }
    public static FillType AskFillType()
{
    Console.WriteLine("Оберіть спосіб заповнення матриці:");
    Console.WriteLine("1 — Вручну");
    Console.WriteLine("2 — Випадково");
    while (true)
    {
        Console.Write("Ваш вибір: ");
        string? input = Console.ReadLine();
        if (input == "1") return FillType.Manual;
        if (input == "2") return FillType.Random;
        Console.WriteLine("Некоректний вибір, спробуйте ще.");
    }
}

}

