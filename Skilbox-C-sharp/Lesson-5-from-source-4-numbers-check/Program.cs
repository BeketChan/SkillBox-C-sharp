using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Задание 4. Написать метод принимающий некоторое количесво чисел, выяснить
// является заданная последовательность элементами арифметической или геометрической прогрессии

namespace Lesson_5_from_source_4_numbers_check
{
    internal class Program
    {
        /// <summary>
        /// Разделение целых чисел из строки.
        /// </summary>
        /// <param name="sent">Строка целых чисел разделённых символами " ", ".", ","</param>
        /// <returns></returns>
        static int[] NumderSplit(string sent)
        {
            int wordsQty = 0;
            for (int i = 0; i < sent.Length; i++)
            {
                if (sent.Substring(i, 1) == " " | sent.Substring(i, 1) == "." | sent.Substring(i, 1) == ",") wordsQty++;
            }
            string[] words = new string[wordsQty + 1];
            int wordNum = 0;
            for (int i = 0; i < sent.Length; i++)
            {
                if (sent.Substring(i, 1) == " " | sent.Substring(i, 1) == "." | sent.Substring(i, 1) == ",") wordNum++;
                else words[wordNum] += sent.Substring(i, 1);
            }
            int[] numbers = new int[wordsQty + 1];
            for (int i = 0;i < words.Length; i++)numbers[i] = Convert.ToInt32(words[i]);
            return numbers;
        }
        
        /// <summary>
        /// Провера, является ли повледовательность целых чисел арифметической прогрессией.
        /// </summary>
        /// <param name="numbers">Массив целых чисел.</param>
        /// <returns></returns>
        static bool ArithmeticProgressionScheck(int[] numbers)
        {
            int gap = numbers[1] - numbers[0];
            for(int i = 2; i < numbers.Length; i++)
            {
                if (numbers[i] - numbers[i - 1] == gap) continue;
                else return false;
            }
            return true;
        }

        /// <summary>
        /// Провера, является ли повледовательность целых чисел геометрической прогрессией.
        /// </summary>
        /// <param name="numbers">Массив целых чисел.</param>
        /// <returns></returns>
        static bool GeometricProgressionScheck(int[] numbers)
        {
            double gap = (double)numbers[1] / (double)numbers[0];
            for (int i = 2; i < numbers.Length; i++)
            {
                if ((double)numbers[i] / (double)numbers[i - 1] == gap) continue;
                else return false;
            }
            return true;
        }

        /// <summary>
        /// Начало работы программы
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Введите через пробел ряд целых положительных чисел:");
            string numderText = Console.ReadLine();
            int[] numbers = NumderSplit(numderText);

            if (numbers.Length > 1)
            {
                if (ArithmeticProgressionScheck(numbers)) Console.WriteLine("Данная последовательность является арифметической прогрессией.");
                else Console.WriteLine("Данная последовательность НЕ является арифметической прогрессией.");
                if (GeometricProgressionScheck(numbers)) Console.WriteLine("Данная последовательность является геометрической прогрессией.");
                else Console.WriteLine("Данная последовательность НЕ является геометрической прогрессией.");
            }
            else Console.WriteLine("Вы ввели всего 1 число.");            

            Console.ReadLine();
        }
    }
}
