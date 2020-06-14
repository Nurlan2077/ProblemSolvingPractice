using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Practice.Task5;

namespace Practice
{
    class Task5_Demo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размерность массива:");

            // Размерность матрицы.
            int size = CheckUserInput();

            int[][] matr = new int[size][];
            Random rand = new Random();

            // Случайная генерация элементов матрицы.
            for (int i = 0; i < size; i++)
            {
                matr[i] = new int[size];
                for (int j = 0; j < size; j++)
                {
                    matr[i][j] = rand.Next(-100, 100);
                }
            }

            // Вывод матрицы.
            ShowMas(matr);

            // Вычисление суммы.
            int[] res = FindSum(matr);

            // Вывод элемента.
            foreach (int elem in res)
            {
                Console.WriteLine(elem);
            }

            Console.ReadLine();
        }
    }
}
