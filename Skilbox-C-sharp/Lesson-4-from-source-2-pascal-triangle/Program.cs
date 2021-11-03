// * Задание 2

// Заказчику требуется приложение строящее первых N строк треугольника паскаля. N < 25

Console.WriteLine("Укажите число от 2 до 25:");
int N = int.Parse(Console.ReadLine());
Console.WriteLine($"Треугольник Паскаля до {N}");

int[][] pascal = new int[N][];
for (int i = 0; i < N; i++) pascal[i] = new int[i+1]; 

int first, second;
pascal[0][0] = 1;
for (int x = 0; x < N; x++)
{
    for(int y = 0; y < (pascal[x].Length); y++)
    {
        if (x == 0 & y == 0)
        {
            Console.Write(pascal[x][y]);
            continue;
        }
        
        if (y == 0) first = 0;
        else first = pascal[x - 1][y - 1];

        if (x == 0) second = 0;
        else if (y == (pascal[x].Length - 1)) second = 0;
        else second = pascal[x - 1][y];

        pascal[x][y] = first + second;

        Console.Write($"{pascal[x][y]}  ");
    }
    Console.WriteLine();
}

Console.ReadLine();