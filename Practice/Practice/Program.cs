using System;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            int amountUFO = Int32.Parse(Console.ReadLine());        // Количество тарелок.
            string[] laserInfo = Console.ReadLine().Split(' ');     // Строковые координаты луча.
            int[] laserCoords = new int[laserInfo.Length];          // Числовые координаты луча.

            // Перевод строковых координат в числовые.
            for (int i = 0; i < laserInfo.Length; i++)
            {
                laserCoords[i] = int.Parse(laserInfo[i]);
            }

            // Координаты точек лазера.
            int x1 = laserCoords[0];
            int y1 = laserCoords[1];
            int x2 = laserCoords[2];
            int y2 = laserCoords[3];

            double A = y2 - y1;
            double B = x1 - x2;
            double C = x2 * y1 - x1 * y2;

            int count = 0;      // Вспомогательная переменная для подсчёта сбитых тарелок.
            string res = "";    // Вспомог. переменная для вывода ответа.

            int[] result = new int[amountUFO]; 

            // Проходит по всем координатам тарелок.
            for (int i = 1; i <= amountUFO; i++)
            {
                string[] infoUFO = Console.ReadLine().Split(' ');

                // Переводит строковые координаты в числовые.
                int x = Int32.Parse(infoUFO[0]);
                int y = Int32.Parse(infoUFO[1]);
                int R = Int32.Parse(infoUFO[2]);

                // Проверяет расстояние между прямой и окружностью.
                if (Math.Abs(A * x + B * y + C) / Math.Sqrt(A * A + B * B) <= R )
                {
                    result[count] = i;
                    count++;
                }
            }

            // Вывод ответа.
            Console.WriteLine(count);

            for (int i = 0; i < amountUFO; i++)
            {
                if(result[i] > 0)
                {
                    Console.Write(result[i] + " ");
                }
            }
        }
    }
}
