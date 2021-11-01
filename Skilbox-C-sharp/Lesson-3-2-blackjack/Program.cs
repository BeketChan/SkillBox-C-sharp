//Задание 2.Программа подсчёта суммы карт в игре «21»

//Что нужно сделать
//Есть довольно простая карточная игра, она называется Blackjack.
//Суть игры сводится к подсчёту карт. Каждая карта имеет свой «вес».
//Напишите программу, которая подсчитает сумму всех карт у нас на руках.

int number;

do
{
    int sum = 0;
    string kard;
    Console.WriteLine("Так как программа без проверок вводимых данных имейте совесть и вводите только то, что требуется :)");
    Console.WriteLine("Для завершения программы введите '0'. Введите количество карт у вас в руке:");
    number = int.Parse(Console.ReadLine());
    Console.WriteLine($"У вас на руках {number} карт.");
    for (int n = 1; n <= number; n++)
    {
        if (number == 0) break;
        Console.WriteLine($"Укажите номинал карты номер {n}. Число или : J = валет, Q = дама, K = король, T = туз (очень прошу вводите - только указанные символы).");
        kard = Console.ReadLine();
        switch (kard)
        {
            case "2": sum += 2; break;
            case "3": sum += 3; break;
            case "4": sum += 4; break;
            case "5": sum += 5; break;
            case "6": sum += 6; break;
            case "7": sum += 7; break;
            case "8": sum += 8; break;
            case "9": sum += 9; break;
            case "10": sum += 10; break;
            case "J": sum += 10; break;
            case "Q": sum += 10; break;
            case "K": sum += 10; break;
            case "T": sum += 10; break;
        }        
    }
    Console.WriteLine($"Вес ваших карт = {sum}");

} while (number != 0);