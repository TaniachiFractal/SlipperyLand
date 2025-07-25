using System;
using System.Windows.Input;

namespace Common.Types
{
    /// <summary>
    /// <see cref="ICommand"/> with no parameters
    /// </summary>
    public class NoParamAction : ICommand
    {
        private readonly Action execute;
        private readonly Predicate<object> canExecute;

        /// <summary>
        /// Constructor for <see cref="NoParamAction"/>
        /// </summary>
        public NoParamAction(Action execute, Predicate<object> canExecute = null)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }

        /// <inheritdoc cref="ICommand.Execute(object)"/>
        public void Execute()
            => execute();

        bool ICommand.CanExecute(object parameter)
            => canExecute == null || canExecute(parameter);

        void ICommand.Execute(object parameter)
            => execute();

        event EventHandler ICommand.CanExecuteChanged
        {
            add { }
            remove { }
        }
    }
}
