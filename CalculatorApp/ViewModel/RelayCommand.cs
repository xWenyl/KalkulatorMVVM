using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

public class RelayCommand : ICommand
{
    private Action<object> execute;
    private Predicate<object> canExecute;

    public RelayCommand(Action<object> execute, Predicate<object> canExecute)
    {
        if (execute == null) throw new ArgumentNullException(nameof(execute));
        else this.execute = execute;
        this.canExecute = canExecute;
    }

    public RelayCommand(Action<object> execute)
    {
        if (execute == null) throw new ArgumentNullException(nameof(execute));
        else this.execute = execute;
    }

    public event EventHandler? CanExecuteChanged
    {
        add
        {
            CommandManager.RequerySuggested += value;
        }
        remove
        {
            CommandManager.RequerySuggested -= value;
        }
    }

    public bool CanExecute(object? parameter)
    {
        if (canExecute == null) return true;
        else return canExecute(parameter);
    }

    public void Execute(object? parameter)
    {
        execute(parameter);
    }
}

