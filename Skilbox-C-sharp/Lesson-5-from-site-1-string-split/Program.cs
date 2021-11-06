// Задание 1. Метод разделения строки на слова

// Что нужно сделать
// Пользователь вводит в консольном приложении длинное предложение.
// Каждое слово в этом предложении отделено одним пробелом.
// Необходимо создать метод, который в качестве входного параметра принимает строковую переменную,
// а в качестве возвращаемого значения — массив слов. После вызова данного метода программа вызывает второй метод,
// который выводит каждое слово в отдельной строке.   
using static Lesson5.TextOperators;

Console.WriteLine("Введите предложение. Слова разделяйте пробелами:");
string sentence = Console.ReadLine();
Console.WriteLine("А теперь моЩЩЩный МЕТОД разделит предложение на слова !!!");
string[] words = SentenceSplit(sentence);
for(int i = 0; i < words.Length; i++)Console.WriteLine(words[i]);

Console.ReadLine();

/// <summary>
/// В /NET 6.0 изменили общую структуру программы.
/// По хорошему, разумеется, это всё в библиотеки убирать нужно. Я так понимаю.
/// Смотрел тут: https://docs.microsoft.com/ru-ru/dotnet/csharp/fundamentals/program-structure/
/// </summary>
namespace Lesson5
{
    /// <summary>
    /// Класс для манипуляций со строкой.
    /// </summary>
    public static class TextOperators
    {
        /// <summary>
        /// Разделение входящей строки на слова. Признак разделения слов = " ". Возвращает массив.
        /// </summary>
        /// <param name="Sent"></param>
        /// <returns></returns>
        public static string[] SentenceSplit(string Sent)
        {
            //string[] vs = Sent.Split(' '); = для слабаков ;)
            int wordsQty = 0;
            for (int i = 0; i < Sent.Length; i++)
            {
                if (Sent.Substring(i, 1) == " ") wordsQty++;
            }
            string[] words = new string[wordsQty + 1];
            int wordNum = 0;
            for (int i = 0; i < Sent.Length; i++)
            {
                if (Sent.Substring(i, 1) == " ") wordNum++;
                else words[wordNum] += Sent.Substring(i, 1);
            }
            return words;
        }
    }
}