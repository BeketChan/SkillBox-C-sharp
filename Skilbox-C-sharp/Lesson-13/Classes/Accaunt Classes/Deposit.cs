namespace Lesson_13.Classes.Accaunt_Classes
{
    public class Deposit : Accaunt
    {
        #region Поля

        /// <summary>
        /// Годовая ставка, %.
        /// </summary>
        double stavka = 10;

        #endregion

        #region Свойства

        /// <summary>
        /// Узнать готовую ставку.
        /// </summary>
        public double Stavka
        {
            get => stavka;
        }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Базовый конструктор.
        /// </summary>
        public Deposit() { }

        /// <summary>
        /// Новый счёт физического лица.
        /// </summary>
        /// <param name="name"></param>
        public Deposit(string name) : base(name) { }

        /// <summary>
        /// Новый счёт с устанавливаемой ставкой.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="stavka"></param>
        internal Deposit(string name, double stavka) : base(name)
        {
            this.stavka = stavka;
        }

        #endregion
    }
}
