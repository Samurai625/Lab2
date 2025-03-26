using System;

class Task16
{
    public static void Run()
    {
        Console.Write("Введіть розмір матриці: ");
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = FillArr(n);
        Console.WriteLine($"Матриця:");
        PrintMatrix(matrix);

        (int sum, int count) = CalculateNegativeElements(matrix);
    }

     static int[,] FillArr(int n)
    {
        int[,] matrix = new int[n, n];
        Random random = new Random();

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
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
    static(int sum,int count) CalculateNegativeElements(int[,] matrix)
    {
        int sum = 0;
        int count = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (matrix[i, j] < 0)
                {
                    sum += matrix[i, j];
                    count++;
                }
            }
        }
        Console.WriteLine($"Сума від'ємних елементів: {sum}");
        Console.WriteLine($"Кількість від'ємних елементів: {count}");
        return (sum, count);
    }
}