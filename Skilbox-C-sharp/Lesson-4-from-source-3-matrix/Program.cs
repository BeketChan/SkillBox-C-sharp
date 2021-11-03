// * Задание 3.1
// Заказчику требуется приложение позволяющщее умножать математическую матрицу на число
// ** Задание 3.2
// Заказчику требуется приложение позволяющщее складывать и вычитать математические матрицы
// *** Задание 3.3
// Заказчику требуется приложение позволяющщее перемножать математические матрицы

// Добавить возможность ввода количество строк и столцов матрицы и число, на которое будет производиться умножение.
// Матрицы заполняются автоматически. 
// Если по введённым пользователем данным действие произвести невозможно - сообщить об этом

Console.WriteLine("Калькулятор МАТРИЦ запущен. Выберите опцию:");
Console.WriteLine("1 = умножить матрицу на целое число\n2 = сложить две матрицы\n3 = вычесть из первой матрицы вторую\n4 = перемножить матрицы.");
int mode = int.Parse(Console.ReadLine());
int x1 = 0, x2 = 0, y1 = 0, y2 = 0, mult = 0;

// получаем данные от пользователя
switch (mode)
{
    case 1 :
        Console.WriteLine("Укажите количество строк в матрице:");
        x1=int.Parse(Console.ReadLine());
        Console.WriteLine("Укажите количество столбцов в матрице:");
        y1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Укажите множитель:");
        mult = int.Parse(Console.ReadLine());
        break;
    case 2 :
    case 3 :
    case 4 :
        Console.WriteLine("Укажите количество строк в первой матрице:");
        x1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Укажите количество столбцов в первой матрице:");
        y1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Укажите количество строк во второй матрице:");
        x2 = int.Parse(Console.ReadLine());
        Console.WriteLine("Укажите количество столбцов во второй матрице:");
        y2 = int.Parse(Console.ReadLine());
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
int[,] matrix1 = new int[x1, y1], matrix2 = new int[x2, y2], matrix3 = new int[x1, y2];
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
        break;
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

Console.ReadLine();