using System;

class Task10
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
        PrintMatrixWithProducts(matrix,rows, cols);

        SortRowsByProduct(matrix, rows, cols);
        Console.WriteLine("Матриця після сортування:");
        PrintMatrixWithProducts(matrix, rows, cols);
    }

     static void PrintMatrixWithProducts(int[,] matrix, int rows, int cols)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{matrix[i, j],5}");
            }
            int product = GetProduct(matrix, i, cols);
            Console.WriteLine($"   | Добуток: {product}");
        }
    }


    static void SortRowsByProduct(int[,] matrix, int rows, int cols)
    {
        int[] products = new int[rows];
        for(int i = 0; i < rows; i++)
            products[i] = GetProduct(matrix, i, cols);

        bool swapped;
        do
        {
            swapped = false;
            for (int i = 0; i < rows - 1; i++)
            {
                if (products[i] > products[i + 1])
                {
                    SwapRows(matrix, i, i + 1, cols);
                    (products[i], products[i + 1]) = (products[i + 1], products[i]);
                    swapped = true;
                }
            }
        } while (swapped);
    }

    static int GetProduct(int[,] matrix, int row, int cols)
    {
        int product = 1;
        bool hasNonZero = false;
        for(int j = 0; j < cols; j++)
        {
            if (matrix[row, j] != 0)
            {
                product *= matrix[row, j];
                hasNonZero = true;
            }
        }
        return hasNonZero ? product : 0;
    }

    static void SwapRows(int[,] matrix, int r1, int r2, int cols)
    {
        for (int j = 0; j < cols; j++)
        {
           (matrix[r1, j], matrix[r2, j]) = (matrix[r2, j], matrix[r1, j]);
        }
    }
}
