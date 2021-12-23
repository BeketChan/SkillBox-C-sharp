using Lesson_13.Classes.Accaunt_Classes;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Lesson_13.Classes.Klients_Classes
{
    public class Individual : Klient<Deposit>
    {
        #region Конструкторы

        /// <summary>
        /// Новый VIP клиент.
        /// </summary>
        /// <param name="name">Название</param>
        public Individual(string name) : base(name) { }

        #endregion
    }
}
