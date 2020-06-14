using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Practice.Task7;

namespace Task7
{
    class Task7_Demo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество длин слов:");
            
            int num = CheckUserInput(0);    // Количество длин слов.

            int[] lengths = new int[num];   // Длины кодовых слов.
            
            Console.WriteLine("Введите длины слов:");
            for(int i = 0; i < num; i++)
            {
                lengths[i] = CheckUserInput();
            }

            // Вычисление кодового слова.
            string[] res = CalculateCode(lengths);

            Console.WriteLine("Кодовые слова:");
            // Вывод кодовых слов.
            foreach (string elem in res)
            {
                Console.Write(elem + " ");
            }

            Console.ReadLine();
        }
    }
}
