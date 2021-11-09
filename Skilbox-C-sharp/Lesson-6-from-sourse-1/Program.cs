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
        /// Проверка завершения распределения чисел по группам.
        /// </summary>
        /// <param name="mas">Базовый массив.</param>
        /// <returns></returns>
        static bool EndCheck(int[] mas)
        {
            for (int i = 0; i < mas.Length; i++) if (mas[i] != 0) return false;
            return true;
        }

        /// <summary>
        /// Поиск количества групп от числа.
        /// </summary>
        /// <param name="N">Число.</param>
        /// <returns></returns>
        static int FindM(int N)
        {
            int M = 0;
            int[] baseMas = new int[N], tempMas = new int[N];

            for (int i = 0; i < N; i++) baseMas[i] = i + 1;
            do
            {
                M++;
                for (int i = 0; i < N; i++) tempMas[i] = baseMas[i];

                for (int i = 0; i < N; i++)
                {
                    if (tempMas[i] == 0) continue;
                    else
                    {
                        for (int j = i; j < N; j++)
                        {
                            if (j == i) continue;
                            else
                                if (tempMas[j] != 0 && tempMas[i] % tempMas[j] != 0 && tempMas[j] % tempMas[i] != 0) continue;
                            else tempMas[j] = 0;
                        }
                    }
                }

                for (int i = 0; i < N; i++)
                    if (tempMas[i] != 0) baseMas[i] = 0;

            } while (!EndCheck(baseMas));

            return M;
        }

        /// <summary>
        /// Заполнение массива группами чисел.
        /// </summary>
        /// <param name="N">Число.</param>
        /// <returns></returns>
        static string[] FillM(int N)
        {
            int M = 0;
            int[] baseMas = new int[N], tempMas = new int[N];
            string[] itogMas = new string[FindM(N)];

            for (int i = 0; i < N; i++) baseMas[i] = i + 1;
            do
            {
                M++;
                for (int i = 0; i < N; i++) tempMas[i] = baseMas[i];

                for (int i = 0; i < N; i++)
                {
                    if (tempMas[i] == 0) continue;
                    else
                    {
                        for (int j = i; j < N; j++)
                        {
                            if (j == i) continue;
                            else
                                if (tempMas[j] != 0 && tempMas[i] % tempMas[j] != 0 && tempMas[j] % tempMas[i] != 0) continue;
                            else tempMas[j] = 0;
                        }
                    }
                }

                itogMas[M - 1] = "";
                for (int i = 0; i < N; i++)
                {
                    if (tempMas[i] != 0)
                    {
                        baseMas[i] = 0;
                        if (itogMas[M - 1] == "") itogMas[M - 1] = Convert.ToString(tempMas[i]);
                        else itogMas[M - 1] += "," + Convert.ToString(tempMas[i]);
                    }
                    
                }                    

            } while (!EndCheck(baseMas));

            return itogMas;
        }

        /// <summary>
        /// Сохранить данные в указанный файл.
        /// </summary>
        /// <param name="path">Файл.</param>
        /// <param name="rows">Массив с данными.</param>
        static void SaveInFile(string path, string[] rows)
        {
            using (StreamWriter sr = File.CreateText(path))
            {
                for (int i = 0; i < rows.Length; i++)
                    sr.WriteLine(rows[i]);
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
            bool check = false;
            int N = 0;
            int zip = 0;

            if (!File.Exists(path)) using (StreamWriter sw = new StreamWriter(path, append: false)) //File.CreateText(path))
                {
                    Console.WriteLine("Файл с данными не найден. Создадим новый. Введите целое число от 1 до 100 000:");
                    N = CheckValidInput(1, 100_000);
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
                string[] itogMas = FillM(N);
                path = "result.txt";
                string pathZip = "result.zip";
                SaveInFile(path, itogMas);

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
