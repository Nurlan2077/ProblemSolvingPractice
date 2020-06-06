using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FindNum(1, 3, 1, 5));
        }


        // Метод для высчитывания чисел последовательности.
        public static double FindNum(double third, double second, double first, int num)
        {
            // Если вызывают один из трех первых элементов последовательности,
            // то возвращает его.
            switch (num)
            {
                case 1:
                    return first;
                case 2:
                    return second;
                case 3:
                    return third;
            }

            // Высчитывает элемент последовательности.
            return FindNum(third, second, first, num - 1) + FindNum(third, second, first, num - 2) / 3 + 3 * FindNum(third, second, first, num - 3);
        }
    }
}
