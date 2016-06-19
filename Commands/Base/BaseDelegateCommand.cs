using System;
using System.Windows.Input;

namespace Commands.Base
{
    /// <summary>
    /// Базовый класс делегата комманды.
    /// </summary>
    public class BaseDelegateCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action _executeNotParameters;

        /// <summary>
        /// Конструктор.
        /// </summary>
        public BaseDelegateCommand()
        {
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="execute">Действие.</param>
        /// <param name="canExecute">Предикат для проверки перед выполенением действия.</param>
        public BaseDelegateCommand(Action execute, Predicate<object> canExecute)
        {
            _canExecute = canExecute;
            _executeNotParameters = execute;
        }

        /// <summary>
        /// Событие для отслеживания изменений доступности комманды.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Признак возможного выполения действия комманды.
        /// </summary>
        /// <param name="parameter">Параметр комманды.</param>
        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }

        /// <summary>
        /// Вызывающий метод действия.
        /// </summary>
        /// <param name="parameter">Параметр для действия.</param>
        public void Execute(object parameter)
        {
            _executeNotParameters.Invoke();
        }
    }
}
