using Lesson_13.Classes.Accaunt_Classes;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Lesson_13.Classes.Klients_Classes
{
    public class Individual : Klient
    {
        #region Конструкторы

        /// <summary>
        /// Пустой Конструктор
        /// </summary>
        public Individual() { }

        /// <summary>
        /// Новый клиент.
        /// </summary>
        /// <param name="name">Название</param>
        public Individual(string name) : base(name, "Физ.клиент", new List<string> { "Р/счёт", "Депозит" }) { }

        #endregion
    }
}
