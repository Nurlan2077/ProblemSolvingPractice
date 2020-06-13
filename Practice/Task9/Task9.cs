using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Practice
{
    class Task9
    {
        // Вычисление разности суммы чётных и суммы нечётных чисел в кольцевом списке.
        public static int CalculateDifference(RingList ring)
        {
            Node current = ring.head;    // Указывает на головной элемент.

            int sumEvens = 0;
            int sumOdds  = 0;

            // Пока не дойдет до хвостого элемента,
            // выводит элементы.
            while (current != null)
            {
                if (current.data % 2 == 0)
                {
                    sumEvens += current.data;
                }
                else
                {
                    sumOdds += current.data;
                }

                current = current.next;
            }

            return sumEvens - sumOdds;
        }


        // Дополнительный рекурсивный метод для подсчёта суммы элементов и их количества.
        public static int CalculateDifferenceRecursion(Node current, ref int sum, ref int count)
        {
            if (current.data % 2 == 0)
            {
                sum += current.data;
            }
            else
            {
                sum -= current.data;
            }

            count++;
            
            if(current.next == null)
            {
                Console.WriteLine($"Разность чётных и нечётных элементов в кольцевом списке: {sum}");
                Console.WriteLine($"Количество элементов в кольцевом списке: {count}");

                return sum;

            }
            else
            {
                CalculateDifferenceRecursion(current.next, ref sum, ref count);
            }


            return sum;
        }


        // Класс узла кольцевого списка.
        public class Node
        {
            public Node next;   // Информация о следующем элементе списка.
            public int data;    // Число в узле.
        }


        // Класс кольцевого списка.
        public class RingList
        {
            public Node head;   // Ссылка на головной элемент списка.


            // Добавление нового узла в начало.
            public void AddFirst(int data)
            {
                Node addNode = new Node();

                addNode.data = data;
                addNode.next = head;

                head = addNode;
            }

            // Добавление узла в конец списка.
            public void AddLast(int data)
            {
                // Если нет головного элемента.
                if (head == null)
                {
                    head = new Node();

                    head.data = data;
                    head.next = null;
                }
                else
                {
                    Node toAdd = new Node();
                    toAdd.data = data;

                    Node current = head;
                    while (current.next != null)
                    {
                        current = current.next;
                    }

                    current.next = toAdd;
                }
            }


            // Вывод всех узлов.
            public void showNodes()
            {
                Node current = head;    // Указывает на головной элемент.

                // Пока не дойдет до хвостого элемента,
                // выводит элементы.
                while (current != null)
                {
                    Console.WriteLine(current.data);
                    current = current.next;
                }
            }
        }





    }
}