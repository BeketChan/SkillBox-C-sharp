using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_8
{
    public class ExpansionForConsol
    {
        public ExpansionForConsol() { }

        /// <summary>
        /// Получить текст из консоли
        /// </summary>
        /// <param name="tittle">Сообщение перед вводом текста</param>
        /// <returns></returns>
        public string GetText(string tittle)
        {
            Console.WriteLine(tittle);
            string text = Console.ReadLine();
            return text;
        }

        /// <summary>
        /// Получить целое число из консоли.
        /// </summary>
        /// <param name="tittle">Сообщение перед вводом текста</param>
        /// <returns></returns>
        public int GetInt(string tittle)
        {
            Console.WriteLine(tittle);
            int N = -1;
            bool check = false;
            do
            {
                try
                {
                    N = Convert.ToInt32(Console.ReadLine());
                    check = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Введите корректное число !");
                    check = false;
                }
            } while (!check);
            return N;
        }

        /// <summary>
        /// Получить дробное число из консоли.
        /// </summary>
        /// <param name="tittle">Сообщение перед вводом текста</param>
        /// <returns></returns>
        public double GetDouble(string tittle)
        {
            Console.WriteLine(tittle);
            double N = -1;
            bool check = false;
            do
            {
                try
                {
                    N = Convert.ToInt32(Console.ReadLine());
                    check = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Введите корректное число !");
                    check = false;
                }
            } while (!check);
            return N;
        }

        /// <summary>
        /// Проверка корректности ввода целых чисел в указанный диапазон с возвратом прошедшего проверку значения.
        /// </summary>
        /// <param name="min">От</param>
        /// <param name="max">До</param>
        /// <returns></returns>
        public int CheckValidInput(int min, int max)
        {
            int N;
            bool check = false;
            do
            {
                try
                {
                    N = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    N = -1;
                }
                if (N >= min && N <= max) check = true;
                else Console.WriteLine("Введите корректное число !");
            } while (!check);
            return N;
        }
    }
}
