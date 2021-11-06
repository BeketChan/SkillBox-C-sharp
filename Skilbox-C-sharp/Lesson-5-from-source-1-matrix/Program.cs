using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Задание 1.
// Воспользовавшись решением задания 3 четвертого модуля
// 1.1. Создать метод, принимающий число и матрицу, возвращающий матрицу умноженную на число
// 1.2. Создать метод, принимающий две матрицу, возвращающий их сумму
// 1.3. Создать метод, принимающий две матрицу, возвращающий их произведение

namespace Lesson_5_from_source_1_matrix
{
    internal class Program
    {
        /// <summary>
        /// Простые операции с одной матрицей
        /// </summary>
        /// <param name="mode">1 = умножить</param>
        /// <param name="mult">одиночный оператор</param>
        /// <param name="matrix1">матрица</param>
        /// <returns></returns>
        static void MatrixCalc(int mode, int mult, int[,] matrix1)
        {
            // mode в данном методе не испольщзуется, но я добавил его для единообразия.
            // Да и может понадобится добавлять другие простые операции в одной матрицей.
            int x1 = matrix1.GetUpperBound(0), y1 = matrix1.GetUpperBound(1);
            Console.WriteLine("Матрица");
            for (int x = 0; x < x1; x++)
            {
                for (int y = 0; y < y1; y++)
                    Console.Write($"{matrix1[x, y]}\t");
                Console.WriteLine();
            }
            Console.WriteLine($"Умножить на {mult} = ");
            for (int x = 0; x < x1; x++)
            {
                for (int y = 0; y < y1; y++)
                    Console.Write($"{matrix1[x, y] * mult}\t");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Операции с двумя матрицами
        /// </summary>
        /// <param name="mode">2 = сложить, 3 = вычесть, 4 = перемножить</param>
        /// <param name="matrix1">первая матрица</param>
        /// <param name="matrix2">вторая матрица</param>
        /// <returns></returns>
        static void MatrixCalc(int mode, int[,] matrix1, int[,] matrix2)
        {
            int x1 = matrix1.GetUpperBound(0), y1 = matrix1.GetUpperBound(1);
            int x2 = matrix2.GetUpperBound(0), y2 = matrix2.GetUpperBound(1);
            int[,] matrix3 = new int[x1, y2];
            switch (mode)
            {
                case 2:
                case 3:
                    Console.WriteLine("Матрица 1");
                    for (int x = 0; x < x1; x++)
                    {
                        for (int y = 0; y < y1; y++)
                            Console.Write($"{matrix1[x, y]}\t");
                        Console.WriteLine();
                    }
                    if (mode == 2) Console.WriteLine("сложить с Матрицей 2");
                    else Console.WriteLine("вычесть Матрицу 2");
                    for (int x = 0; x < x1; x++)
                    {
                        for (int y = 0; y < y1; y++)
                            Console.Write($"{matrix2[x, y]}\t");
                        Console.WriteLine();
                    }
                    Console.WriteLine("Результат операции = ");
                    for (int x = 0; x < x1; x++)
                    {
                        for (int y = 0; y < y1; y++)
                            if (mode == 2) Console.Write($"{matrix1[x, y] + matrix2[x, y]}\t");
                            else Console.Write($"{matrix1[x, y] - matrix2[x, y]}\t");
                        Console.WriteLine();
                    }
                    break;
                case 4:
                    Console.WriteLine("Матрица 1");
                    for (int x = 0; x < x1; x++)
                    {
                        for (int y = 0; y < y1; y++)
                            Console.Write($"{matrix1[x, y]}\t");
                        Console.WriteLine();
                    }
                    Console.WriteLine("умножить на Матрицу 2");
                    for (int x = 0; x < x2; x++)
                    {
                        for (int y = 0; y < y2; y++)
                            Console.Write($"{matrix2[x, y]}\t");
                        Console.WriteLine();
                    }
                    Console.WriteLine("Результат операции = ");
                    for (int x = 0; x < x1; x++)
                    {
                        for (int y = 0; y < y2; y++)
                        {
                            for (int i = 0; i < y1; i++)
                                matrix3[x, y] += matrix1[x, i] * matrix2[i, y];
                            Console.Write($"{matrix3[x, y]}\t");
                        }
                        Console.WriteLine();
                    }
                    break;
            }
        }

        /// <summary>
        /// Начало исполнения программы
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Калькулятор МАТРИЦ запущен. Выберите опцию:");
            Console.WriteLine("1 = умножить матрицу на целое число\n2 = сложить две матрицы\n3 = вычесть из первой матрицы вторую\n4 = перемножить матрицы.");
            int mode = int.Parse(Console.ReadLine());
            int x1 = 0, x2 = 0, y1 = 0, y2 = 0, mult = 0;

            // получаем данные от пользователя
            switch (mode)
            {
                case 1:
                    Console.WriteLine("Укажите количество строк в матрице:");
                    do
                    {
                        x1 = int.Parse(Console.ReadLine());
                        if (x1 <= 0) Console.WriteLine("Введено неверное значение ! Требуется целое положительное число !");
                    } while (x1 <= 0);
                    Console.WriteLine("Укажите количество столбцов в матрице:");
                    do
                    {
                        y1 = int.Parse(Console.ReadLine());
                        if (y1 <= 0) Console.WriteLine("Введено неверное значение ! Требуется целое положительное число !");
                    } while (y1 <= 0);
                    Console.WriteLine("Укажите множитель:");
                    mult = int.Parse(Console.ReadLine());
                    break;
                case 2:
                case 3:
                case 4:
                    Console.WriteLine("Укажите количество строк в первой матрице:");
                    do
                    {
                        x1 = int.Parse(Console.ReadLine());
                        if (x1 <= 0) Console.WriteLine("Введено неверное значение ! Требуется целое положительное число !");
                    } while (x1 <= 0);
                    Console.WriteLine("Укажите количество столбцов в первой матрице:");
                    do
                    {
                        y1 = int.Parse(Console.ReadLine());
                        if (y1 <= 0) Console.WriteLine("Введено неверное значение ! Требуется целое положительное число !");
                    } while (y1 <= 0);
                    Console.WriteLine("Укажите количество строк во второй матрице:");
                    do
                    {
                        x2 = int.Parse(Console.ReadLine());
                        if (x2 <= 0) Console.WriteLine("Введено неверное значение ! Требуется целое положительное число !");
                    } while (x2 <= 0);
                    Console.WriteLine("Укажите количество столбцов во второй матрице:");
                    do
                    {
                        y2 = int.Parse(Console.ReadLine());
                        if (y2 <= 0) Console.WriteLine("Введено неверное значение ! Требуется целое положительное число !");
                    } while (y2 <= 0);
                    break;
            }

            // проверяем возможность выполнения операции
            if ((mode == 2 || mode == 3) & (x1 != x2 || y1 != y2))
            {
                Console.WriteLine("Нельзя складывать и вычитать разноразмерные матрицы.");
                mode = 99;
            }
            if (mode == 4 & !(x1 == y2 || x2 == y1))
            {
                Console.WriteLine("Нельзя умножать несогласованные матрицы. Количество столюбцов первой матрицы НЕ равно количеству строк второй.");
                mode = 99;
            }

            // заполняем матрицы
            int[,] matrix1 = new int[x1 + 1, y1 + 1], matrix2 = new int[x2 + 1, y2 + 1];
            if (mode < 99)
            {
                Random rnd = new Random();
                for (int x = 0; x < x1; x++)
                    for (int y = 0; y < y1; y++)
                        matrix1[x, y] = rnd.Next(1, 100);
                if (mode > 0)
                    for (int x = 0; x < x2; x++)
                        for (int y = 0; y < y2; y++)
                            matrix2[x, y] = rnd.Next(1, 100);
            }

            // выполнение операций
            switch (mode)
            {
                case 1: MatrixCalc(mode, mult, matrix1); break;
                case 2:
                case 3: MatrixCalc(mode, matrix1, matrix2); break;
                case 4: MatrixCalc(mode, matrix1, matrix2); break;
            }

            Console.ReadLine();
        }
    }
}
