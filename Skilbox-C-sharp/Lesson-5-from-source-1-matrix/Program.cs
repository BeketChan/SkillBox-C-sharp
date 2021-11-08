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
                if (N >= 1 && N <= 10) check = true;
                else Console.WriteLine("Введите корректное число !");
            } while (!check);
            return N;
        }

        /// <summary>
        /// Печать матрицы на экран.
        /// </summary>
        /// <param name="matrix">Матрица.</param>
        static void MatrixPrint(int[,] matrix)
        {
            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                    Console.Write($"{matrix[x, y]}\t");
                Console.WriteLine();
            }
        }
        
        /// <summary>
        /// Простые операции с одной матрицей
        /// </summary>
        /// <param name="mode">1 = умножить</param>
        /// <param name="mult">одиночный оператор</param>
        /// <param name="matrix1">матрица</param>
        /// <returns></returns>
        static int[,] MatrixCalc(int mode, int mult, int[,] matrix1)
        {
            int[,] matrix3 = new int[matrix1.GetLength(0), matrix1.GetLength(1)];
            
            // mode в данном методе не испольщзуется, но я добавил его для единообразия.
            // Да и может понадобится добавлять другие простые операции в одной матрицей.
            int x1 = matrix1.GetLength(0), y1 = matrix1.GetLength(1);
            for (int x = 0; x < x1; x++)
            {
                for (int y = 0; y < y1; y++)
                    matrix3[x, y] = matrix1[x, y] * mult;
            }
            return matrix3;
        }

        /// <summary>
        /// Операции с двумя матрицами
        /// </summary>
        /// <param name="mode">2 = сложить, 3 = вычесть, 4 = перемножить</param>
        /// <param name="matrix1">первая матрица</param>
        /// <param name="matrix2">вторая матрица</param>
        /// <returns></returns>
        static int[,] MatrixCalc(int mode, int[,] matrix1, int[,] matrix2)
        {
            int x1 = matrix1.GetLength(0), y1 = matrix1.GetLength(1);
            int x2 = matrix2.GetLength(0), y2 = matrix2.GetLength(1);
            int[,] matrix3 = new int[x1, y2];
            switch (mode)
            {
                case 2:
                case 3:
                    for (int x = 0; x < x1; x++)
                        for (int y = 0; y < y1; y++)
                            if (mode == 2) matrix3[x, y] = matrix1[x, y] + matrix2[x, y];
                            else matrix3[x, y] = matrix1[x, y] - matrix2[x, y];
                    break;
                case 4:
                    for (int x = 0; x < x1; x++)
                        for (int y = 0; y < y2; y++)
                            for (int i = 0; i < y1; i++)
                                matrix3[x, y] += matrix1[x, i] * matrix2[i, y];
                    break;
            }
            return matrix3;
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
                    Console.WriteLine("Укажите количество строк в матрице от 1 до 10:");
                    x1 = CheckValidInput(1, 10);
                    Console.WriteLine("Укажите количество столбцов в матрице от 1 до 10:");
                    y1 = CheckValidInput(1, 10);
                    Console.WriteLine("Укажите множитель:");
                    mult = CheckValidInput(1, 10);
                    break;
                case 2:
                case 3:
                case 4:
                    Console.WriteLine("Укажите количество строк в первой матрице от 1 до 10:");
                    x1 = CheckValidInput(1, 10);
                    Console.WriteLine("Укажите количество столбцов в первой матрице от 1 до 10:");
                    y1 = CheckValidInput(1, 10);
                    Console.WriteLine("Укажите количество строк во второй матрице от 1 до 10:");
                    x2 = CheckValidInput(1, 10);
                    Console.WriteLine("Укажите количество столбцов во второй матрице от 1 до 10:");
                    y2 = CheckValidInput(1, 10);
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
            int[,] matrix1 = new int[x1, y1], matrix2 = new int[x2, y2], matrix3;
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
                case 1:
                    matrix3 = MatrixCalc(mode, mult, matrix1);
                    Console.WriteLine("Матрица");
                    MatrixPrint(matrix1);
                    Console.WriteLine($"умножить на {mult}");
                    Console.WriteLine("Результат операции = ");
                    MatrixPrint(matrix3);
                    break;
                case 2:
                case 3:
                    matrix3 = MatrixCalc(mode, matrix1, matrix2);
                    Console.WriteLine("Матрица 1");
                    MatrixPrint(matrix1);
                    if (mode == 2) Console.WriteLine("сложить с Матрицей 2");
                    else Console.WriteLine("вычесть Матрицу 2");
                    MatrixPrint(matrix2);
                    Console.WriteLine("Результат операции = ");
                    MatrixPrint(matrix3);
                    break;
                case 4:
                    matrix3 = MatrixCalc(mode, matrix1, matrix2);
                    Console.WriteLine("Матрица 1");
                    MatrixPrint(matrix1);
                    Console.WriteLine("перемнодить на Матрицу 2");
                    MatrixPrint(matrix2);
                    Console.WriteLine("Результат операции = ");
                    MatrixPrint(matrix3);
                    break;
            }

            Console.ReadLine();
        }
    }
}
