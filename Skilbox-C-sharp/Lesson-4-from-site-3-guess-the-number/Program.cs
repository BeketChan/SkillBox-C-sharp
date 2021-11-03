//Задание 3. Игра «Угадай число»

//Что нужно сделать
//Разработайте программу по следующему алгоритму:

//Пользователь вводит максимальное целое число диапазона. 
//На основе диапазона целых чисел (от 0 до «введено пользователем») программа генерирует случайное целое число из диапазона. 
//Пользователю предлагается ввести загаданное программой случайное число. Пользователь вводит свои предположения в консоли приложения. 
//Если число меньше загаданного, программа сообщает об этом пользователю. 
//Если больше, то тоже сообщает, что число больше загаданного. 
//Программа завершается, когда пользователь угадал число. 
//Если пользователь устал играть, то вместо ввода числа он вводит пустую строку и нажимает Enter.
//Тогда программа завершается, предварительно показывая, какое число было загадано.

bool endCheck = false;
string inputData = null;
Console.WriteLine("Игра 'Угадай число'");
Console.WriteLine("Введи максимальное целое положительное число диапазоны:");
int maxNumber = int.Parse(Console.ReadLine());
Random rnd = new Random();
int hideNumder = rnd.Next(0, maxNumber+1);
Console.WriteLine($"В диапазоне от 0 до {maxNumber} я загадал число. Отгадывай !");

do
{
    Console.WriteLine("Введи число:");
    inputData = Console.ReadLine();
    switch (inputData)
    {
        case "" :
            Console.WriteLine($"Сдался ? А я загадал {hideNumder}");
            endCheck = true;
            break;
        default :
            if (Convert.ToInt32(inputData) < hideNumder) Console.WriteLine("Загаданное число больше введённого.");
            if (Convert.ToInt32(inputData) > hideNumder) Console.WriteLine("Загаданное число меньше введённого.");
            if (Convert.ToInt32(inputData) == hideNumder)
            {
                Console.WriteLine("УГАДАЛ !");
                endCheck = true;
            }
            break;
    }
    
} while (!endCheck);

Console.ReadLine();