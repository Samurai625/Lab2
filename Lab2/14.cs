using System;

class Task14
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

        SortOddAndEvenColumns(matrix, rows, cols);

        Console.WriteLine("Матриця після сортування:");
        MatrixUtils.PrintMatrix(matrix);
    }

    static void SortColumns(int[,] matrix, int rows, int j, bool ascending)
    {
            for (int i = 0; i < rows - 1; i++)
            {
                for (int k = 0; k < rows - i - 1; k++)
                {
                    bool condition = ascending
                        ? matrix[k, j] > matrix[k + 1, j]
                        : matrix[k, j] < matrix[k + 1, j];

                    if (condition)
                    {
                        Swap(matrix, k, k + 1, j);
                    }
                }
            }
    }

    static void SortOddAndEvenColumns(int[,] matrix, int rows, int cols)
    {
        for(int j = 0; j < cols; j++)
        {
            bool ascendindg = (j % 2 == 0);
            SortColumns(matrix, rows, j, ascendindg);
        }
    }

    static void Swap(int[,] matrix, int i, int j, int col)
    {
        (matrix[i, col], matrix[j, col]) = (matrix[j, col], matrix[i, col]);
    }
}
