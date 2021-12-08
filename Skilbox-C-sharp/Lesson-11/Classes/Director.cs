namespace Lesson_11.Classes
{
    internal class Director : Executor
    {
        #region Конструктор

        /// <summary>
        /// Руководитель подразделения.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="parent">Подразделение.</param>
        public Director(string name, Department parent) : base(name, "Руководитель", 15) { }

        #endregion
    }
}
