namespace Lesson_11.Classes
{
    internal class Worker : Executor
    {
        #region Конструктор

        /// <summary>
        /// Руководитель подразделения.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="parent">Подразделение.</param>
        public Worker(string name, string parent) : base(name, "Работник", parent, 8) { }

        #endregion
    }
}
