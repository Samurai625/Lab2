using System;

class ChooseTask
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        while (true)
        {
            Console.WriteLine("\nВиберіть номер завдання для виконання (1-4):");
            Console.WriteLine("1. Завдання 1: Сума та кількість від’ємних елементів під головною діагоналлю.");
            Console.WriteLine("2. Завдання 2: Обмін першого максимального та мінімального елемента кожного рядка.");
            Console.WriteLine("3. Завдання 3: Упорядкувати всі стовпчики з парними номерами за незростанням, а всі стовпчики з непарними номерами \r\n за неспаданням.");
            Console.WriteLine("4. Завдання 4: Упорядкувати рядки матриці за неспаданням добутків елементів у цих рядках.");
            Console.WriteLine("0. Вийти з програми.");
            Console.Write("Ваш вибір: ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Task16.Run();
                        break;
                    case 2:
                        Task15.Run();
                        break;
                    case 3:
                        Task14.Run();
                        break;
                    case 4:
                        Task10.Run();
                        break;
                    case 0:
                        Console.WriteLine("Вихід з програми...");
                        return;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Введіть число від 0 до 4.");
            }
        }
    }
}