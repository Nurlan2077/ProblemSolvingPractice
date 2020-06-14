using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Practice.Task11;


namespace Practice
{
    class Task11_Demo
    {
        static void Main(string[] args)
        {
            // Демонстрация дешифрования.

            Console.WriteLine("Ввод последовательности:");
            int[] input = { 1, 1, 1, 0, 1, 0, 1, 0, 1 };
            int[] output = Decode(input);
            ShowMas(output);

            Console.WriteLine();
            Console.WriteLine("Ввод пустой последовательности:");
            input = new int[] { };
            output = Decode(input);
            ShowMas(output);

            Console.WriteLine();
            Console.WriteLine("Ввод последовательности c 1 элементом:");
            input = new int[] { 1};
            output = Decode(input);
            ShowMas(output);

            Console.ReadLine();
        }
    }
}
