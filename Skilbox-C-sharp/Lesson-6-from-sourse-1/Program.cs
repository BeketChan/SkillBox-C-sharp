using System;
using System.IO;
using System.IO.Compression;

namespace Lesson_6_from_sourse_1
{
    internal class Program
    {
        /// <summary>
        /// Проверка корректности ввода целых чисел в указанный диапазон с возвратом прошедшего проверку значения.
        /// </summary>
        /// <param name="min">От</param>
        /// <param name="max">До</param>
        /// <returns></returns>
        static int CheckValidInput(int min, int max)
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
                    N = 0;
                }
                if (N >= 1 && N <= 100_000) check = true;
                else Console.WriteLine("Введите корректное число !");
            } while (!check);
            return N;
        }
        
        /// <summary>
        /// Поиск количества групп от числа.
        /// </summary>
        /// <param name="N">Число.</param>
        /// <returns></returns>
        static int FindM(int N)
        {
            int M = 0;
            for (int i = 1;i < N; i++)
            {
                M++;
                i *= 2;
            }
            return M;
        }

        /// <summary>
        /// Заполнение массива группами чисел.
        /// </summary>
        /// <param name="N">Число.</param>
        /// <returns></returns>
        static void FillM(int N, string path)
        {
            int M = FindM(N);
            int current = 1;
            string line = "";
            using (StreamWriter sr = File.CreateText(path))
            {
                for (int i = 1; i <= N; i++)
                {
                    if (i == current) line = i.ToString();
                    else line += $",{i}";

                    if (i == current * 2 - 1 || i == N)
                    {
                        current *= 2;
                        sr.WriteLine(line);
                    }
                }
            }
        }

        /// <summary>
        /// Создание архива файла с данными.
        /// </summary>
        /// <param name="source">Файл.</param>
        /// <param name="path">Архив.</param>
        static void SaveInZipFile(string source, string path)
        {
            using (FileStream fs = File.OpenRead(source))
            {
                using (FileStream sr = File.Create(path))
                {
                    using (GZipStream gz = new GZipStream(sr, CompressionMode.Compress))
                    {
                        fs.CopyTo(gz);
                    }
                }
            }
        }

        /// <summary>
        /// Начало работы программы.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string path = "value.txt";
            int N = 0;
            int zip = 0;

            if (!File.Exists(path)) using (StreamWriter sw = new StreamWriter(path, append: false)) //File.CreateText(path))
                {
                    Console.WriteLine("Файл с данными не найден. Создадим новый. Введите целое число от 1 до 1 000 000 000:");
                    N = CheckValidInput(1, 1_000_000_000);
                    sw.WriteLine(N);
                }
            else
            {
                using (StreamReader sr = new StreamReader(path))
                    N = int.Parse(sr.ReadLine());
                Console.WriteLine($"Подгрузил число {N}");
            }

            Console.WriteLine($"Чего изволите ? 1 = расчитать количество групп для числа {N:0,0}, 2 = сохранить заполненные группы в файл");
            int mode = int.Parse((string)Console.ReadLine());

            switch (mode)
            {
                case 1:
                    Console.WriteLine($"Ряд чисел от 1 до {N} разбит на группы в количестве {FindM(N)} штук.");
                    break;
                case 2:
                    Console.WriteLine("Желаете заархивировать результаты в файл ? 1 = да, 2 = нет.");
                    zip = CheckValidInput(1, 2);
                    break;
            }

            DateTime dateTime = DateTime.Now;

            if (zip > 0)
            {
                path = "result.txt";
                string pathZip = "result.zip";
                FillM(N,path);

                if (zip == 1)
                {
                    SaveInZipFile(path,pathZip);
                    Console.WriteLine($"Архив {pathZip} сохранён.");
                }

                if (zip == 2) Console.WriteLine($"Файл {path} сохранён.");
            }

            TimeSpan timeSpan = DateTime.Now.Subtract(dateTime);
            Console.WriteLine($"На исполнение ушло {timeSpan.Milliseconds} милесекунд.");

            Console.ReadLine();
        }
    }
}
