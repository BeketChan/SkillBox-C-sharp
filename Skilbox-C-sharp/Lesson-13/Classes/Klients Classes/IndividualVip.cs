using Lesson_13.Classes.Accaunt_Classes;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Lesson_13.Classes.Klients_Classes
{
    public class IndividualVip : Klient
    {
        /// <summary>
        /// Пустой Конструктор
        /// </summary>
        public IndividualVip() { }

        /// <summary>
        /// Новый VIP клиент.
        /// </summary>
        /// <param name="name">Название</param>
        public IndividualVip(string name) : base(name, "Физ.клиент VIP", new List<string> { "Р/счёт", "Депозит", "Депозит VIP" }) { }
    }
}
