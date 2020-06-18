using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Practice.Task6;

namespace Practice
{
    class Task6_Demo
    {
        static void Main(string[] args)
        {
            

            Console.WriteLine("Введите количество чисел для вычисления: ");
            int num = CheckUserInput(3);
            Console.WriteLine();

            Console.WriteLine("Введите первые три числа последовательности: ");

            // Инициализация первых трех элементов.
            double[] elems = new double[num];

            elems[0] = CheckUserInput();
            elems[1] = CheckUserInput();
            elems[2] = CheckUserInput();

            Console.WriteLine("Введите число M для поиска в последовательности: ");
            double numM = CheckUserInput();
            Console.WriteLine();

            Console.WriteLine();
            FindNum(ref elems, 3);   // Высчитывание эл-ов посл-ти.

            //Console.WriteLine("Последовательность:");
            foreach(double elem in elems)
            {
                Console.Write(elem + " ");
            }
            
            Console.WriteLine();

            Console.WriteLine("Номера элементов, которые равны M: ");
            int count = 0;   // Вспомог. переменная для подсчёта кол-ва чисел равных numM.


            // Проходит по эл-ам посл-ти.
            for (int i = 0; i < num; i++)
            {
                if (elems[i] == numM)
                {
                    count++;
                    Console.Write((i + 1) + " ");
                }
            }

            Console.WriteLine();

            // Вывод количества чисел равных M.
            if (count != 0)
            {
                Console.WriteLine($"Количество чисел равных M равно: {count}");
            }
            else
            {
                Console.WriteLine($"Чисел равных M нет.");
            }
            
            Console.WriteLine();

            // Анализ последовательности.
            int analysis = AnalizeSequence(elems);
            
            Console.ForegroundColor = ConsoleColor.Green;
            
            switch (analysis)
            {
                case 11:
                    Console.WriteLine("Числовая последовательность монотонная строго возрастающая");
                    break;
                case 10:
                    Console.WriteLine("Числовая последовательность монотонная нестрого возрастающая");
                    break;
                case 21:
                    Console.WriteLine("Числовая последовательность монотонная строго убывающая");
                    break;
                case 20:
                    Console.WriteLine("Числовая последовательность монотонная нестрого убывающая");
                    break;
                case 0:
                    Console.WriteLine("Числовая последовательность не монотонная.");
                    break;
                case -1:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("В последовательности недостаточно чисел для анализа.");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            
            Console.ForegroundColor = ConsoleColor.White;
            
            Console.ReadLine();
            
        }
    }
}
