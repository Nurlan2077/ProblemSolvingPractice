using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class Task3
    {
        /// <summary>
        ///  Метод для проверки принадлежности точки графику: y >= |x| и y >= 1.
        /// </summary>
        public static bool CheckPoint(double coordX, double coordY)
        {
            // Если попадает в область значений графика, то true, иначе false.
            if (coordY >= Math.Abs(coordX) || coordY >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Перегрузка метода для проверки на принадлежность графику.
        public static bool CheckPoint(double y)
        {
            double x = 0;

            // Если попадает в область значений графика, то true, иначе false.
            if (y >= x || y >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
