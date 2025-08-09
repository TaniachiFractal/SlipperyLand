using System;
using System.Windows.Input;

namespace SlipperyLand.Contracts
{
#nullable enable
    /// <summary>
    /// <see cref="ICommand"/> with no parameters
    /// </summary>
    public class NoParamCommand : ICommand
    {
        private readonly Action execute;
        private readonly Predicate<object?>? canExecute;

        /// <summary>
        /// Constructor for <see cref="NoParamCommand"/>
        /// </summary>
        public NoParamCommand(Action execute, Predicate<object?>? canExecute = null)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }

        /// <inheritdoc cref="ICommand.Execute(object)"/>
        public void Execute()
            => execute();

        bool ICommand.CanExecute(object? parameter)
            => canExecute == null || canExecute(parameter);

        void ICommand.Execute(object? parameter)
            => execute();

        event EventHandler? ICommand.CanExecuteChanged
        {
            add { }
            remove { }
        }
    }
}
