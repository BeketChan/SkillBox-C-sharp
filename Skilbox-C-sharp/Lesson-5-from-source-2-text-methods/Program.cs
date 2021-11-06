using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Задание 2.
// 1. Создать метод, принимающий  текст и возвращающий слово, содержащее минимальное количество букв
// 2.* Создать метод, принимающий  текст и возвращающий слово(слова) с максимальным количеством букв 
// Примечание: слова в тексте могут быть разделены символами (пробелом, точкой, запятой) 
// Пример: Текст: "A ББ ВВВ ГГГГ ДДДД  ДД ЕЕ ЖЖ ЗЗЗ"
// 1. Ответ: А
// 2. ГГГГ, ДДДД

// Задание 3. Создать метод, принимающий текст. 
// Результатом работы метода должен быть новый текст, в котором
// удалены все кратные рядом стоящие символы, оставив по одному 
// Пример: ПППОООГГГООООДДДААА >>> ПОГОДА
// Пример: Ххххоооорррооошшшиий деееннннь >>> хороший день

namespace Lesson_5_from_source_2_text_methods
{
    internal class Program
    {
        /// <summary>
        /// Разделение входящей строки на слова. Признак разделения слов = " ". Возвращает массив.
        /// </summary>
        /// <param name="Sent">Текст</param>
        /// <returns></returns>
        public static string[] SentenceSplit(string Sent)
        {
            int wordsQty = 0;
            for (int i = 0; i < Sent.Length; i++)
            {
                if (Sent.Substring(i, 1) == " " | Sent.Substring(i, 1) == "." | Sent.Substring(i, 1) == ",") wordsQty++;
            }
            string[] words = new string[wordsQty + 1];
            int wordNum = 0;
            for (int i = 0; i < Sent.Length; i++)
            {
                if (Sent.Substring(i, 1) == " " | Sent.Substring(i, 1) == "." | Sent.Substring(i, 1) == ",") wordNum++;
                else words[wordNum] += Sent.Substring(i, 1);
            }
            return words;
        }

        /// <summary>
        /// Ищем одно слово в предложении с наименьшим количеством букв.
        /// </summary>
        /// <param name="Sent">Предложение</param>
        /// <returns></returns>
        public static string ShortWord(string Sent)
        {
            string[] words = SentenceSplit(Sent);
            string minWord = Sent;
            int min = Sent.Length;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length < min)
                {
                    min = words[i].Length;
                    minWord = words[i];
                }
            }
            return minWord;
        }

        /// <summary>
        /// Ищем все слова с самым большим количеством букв
        /// </summary>
        /// <param name="Sent">Предложение</param>
        /// <returns></returns>
        public static string[] LongWords(string Sent)
        {
            string[] words = SentenceSplit(Sent);
            int max = 0, maxQty = 0, current = 0;
            for (int i = 0; i < words.Length; i++)
                if (words[i].Length > max)
                    max = words[i].Length;
            for (int i = 0; i < words.Length; i++)
                if (words[i].Length == max)
                    maxQty++;
            string[] longWords = new string[maxQty];
            for (int i = 0;i<words.Length;i++)
                if(words[i].Length == max)
                    longWords[current++] = words[i];
            return longWords;
        }

        /// <summary>
        /// Начало исполнения программы
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Программа для манипуляции со строкой запущено.");
            Console.WriteLine("Введите предложение. Слова разделяйте пробелами, точками или запятыми :");
            string sentence = Console.ReadLine();
            Console.WriteLine("И что с этим делать ?\n1 = показать слово с минимальным количеством букв\n2 = показать слова с максимальным количеством букв\n3 = убрать стоящие рядом кратные символы, оставив по одному");
            int mode = int.Parse(Console.ReadLine());

            switch (mode)
            {
                case 1: Console.WriteLine($"Самое короткое слово = {ShortWord(sentence)}"); break;
                case 2:
                    string[] longWords = LongWords(sentence);
                    Console.WriteLine("Слова с максимальным количеством букв:");
                    foreach (string e in longWords) if (e.Length > 0) Console.WriteLine(e);
                    break;
            }
            Console.ReadLine();
        }        
    }
}
