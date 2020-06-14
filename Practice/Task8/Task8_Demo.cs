using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Practice.Task8;

namespace Task8
{
    // Демонстрационная программа задачи 8.
    class Task8_Demo
    {
        static void Main(string[] args)
        {
            string filePath = "../../input.txt";

            GenerateInput();

            int[][] graph = ReadFromFile(filePath);

            // Проверка на некорректную матрицу смежности.
            if (graph.Length == 0)
            {
                Console.WriteLine("Матрица смежности пуста.");
                return;
            }

            ShowGraph(graph);

            List<Sets> output = FindEmptySubgraphs(graph);

            Console.WriteLine("Введите количество вершин:");
            int num = CheckUserInput(0);

            Console.WriteLine("Пустые подграфы: ");

            bool isNumFits = false;

            // Проходит по выводу.
            foreach (Sets elem in output)
            {
                if (elem.Count == num)
                {
                    isNumFits = true;
                    foreach (int el in elem)
                    {
                        Console.Write(el + " ");
                    }
                }

                Console.WriteLine();
            }

            // Если нет пустых подграфов для числа,
            // введенного пользователем.
            if (!isNumFits && output.Count > 0)
            {
                Console.WriteLine("Пустых подграфов с введенным количеством вершин нет.");
                Console.WriteLine();

                Console.WriteLine("Есть пустые подграфы: ");

                foreach (Sets elem in output)
                {
                    foreach (int el in elem)
                    {
                        Console.Write(el + " ");
                    }

                    Console.WriteLine();
                }
            }
            // Если вообще нет пустых подграфов.
            else if(output.Count == 0)
            {
                Console.WriteLine("Пустых подграфов нет.");
            }

            Console.ReadLine();
        }
    }
}
