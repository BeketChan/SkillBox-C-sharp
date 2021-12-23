namespace Lesson_13.Classes.Accaunt_Classes
{
    /// <summary>
    /// Интерфейс создания нового счёта.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface INewAccCovariant<out T>
    {
        internal T NewAcc(string value);
    }
}
