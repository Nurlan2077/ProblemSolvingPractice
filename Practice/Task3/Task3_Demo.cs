using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Practice.Task3;

namespace Practice
{
    // Демонстрация программы для проверки точки на принадлежность графику y >= |x| и y >= 1.
    class DemoTask3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число X:");
            double pointX = CheckUserInput();       // Координата точки X.

            Console.WriteLine("Введите число Y:");
            double pointY = CheckUserInput();       // Координата точки Y.

            // Проверка точек на принадлежность графику.
            if (CheckPoint(pointX, pointY))
            {
                Console.WriteLine($"Точка ({pointX};{pointY}) принадлежит графику.");
            }
            else
            {
                Console.WriteLine($"Точка ({pointX};{pointY}) не принадлежит графику.");
            }
        }
    }


}
