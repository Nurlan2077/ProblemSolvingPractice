using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ввод количества слов и ключей.
            string[] input = Console.ReadLine().Split(' ');

            // Приведение к числовому типу.
            int wordsNum = Int32.Parse(input[0]);
            int keysNum  = Int32.Parse(input[1]);

            string words = "";      // Хранит все слова.


            // Записывает все слова в одну строку.
            for (int i = 0; i < wordsNum; i++)
            {
                words += Console.ReadLine();
            }

            string keys = "";       // Хранит все ключи.

            // Записывает все ключи в одну строку.
            for (int i = 0; i < keysNum; i++)
            {
                keys += Console.ReadLine();
            }

            // Проходит по каждому символу ключей.
            for(int i = 0; i < keys.Length; i += 1)
            {
                // Если содержит символ ключа, удаляет.
                if (words.Contains(keys[i].ToString()))
                {
                    int temp = words.IndexOf(keys[i].ToString());   // Хранит индекс удаляемого символа.
                    words = words.Remove(temp, 1);                  // Удаляет символ из строки.
                }
            }

            // Хранит итоговый массив с символами.
            char[] result = words.ToCharArray();

            // Сортирует символы в алфавитном порядке.
            Array.Sort(result);
            
            // Вывод результата.
            foreach(char elem in result)
            {
                Console.Write(elem);
            }

        }
    }
}
