using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Practice.Task9;

namespace Task9
{
    // Демонстрация решения задачи 9.
    class Task9_Demo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите целые числа через пробел.");

            int[] nums = new int[0];

            bool ok = false;

            // Проверка ввода массива.
            do
            {
                try
                {
                    string input = Console.ReadLine();
                    nums = Regex.Split(input.Trim(), @"\s+").Select(Int32.Parse).ToArray();
                    ok = true;
                }
                catch (System.FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Введите только целые числа.");
                    Console.ForegroundColor = ConsoleColor.White;

                }
            }
            while (!ok);

            RingList ringList = new RingList();

            // Заполнение кольцевого списка.
            foreach (int num in nums)
            {
                ringList.AddLast(num);
            }

            Console.WriteLine($"Разность суммы чётных и суммы нечётных чисел равна: {CalculateDifference(ringList)}");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("*Рекурсивный метод*");
            Console.ForegroundColor = ConsoleColor.White;

            int sum   = 0;
            int count = 0;
            CalculateDifferenceRecursion(ringList.head, ref sum, ref count);

            Console.ReadLine();
        }
    }
}
