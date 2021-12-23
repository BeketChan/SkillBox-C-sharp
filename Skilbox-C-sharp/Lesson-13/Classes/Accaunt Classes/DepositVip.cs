namespace Lesson_13.Classes.Accaunt_Classes
{
    public class DepositVip : Deposit
    {
        #region Конструкторы

        /// <summary>
        /// Базовый конструктор.
        /// </summary>
        public DepositVip() { }

        /// <summary>
        /// Новый счёт физического лица.
        /// </summary>
        /// <param name="name"></param>
        public DepositVip(string name) : base(name, 20) { }

        #endregion
    }
}
