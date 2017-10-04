using ShapeOptimization.Models;
using ShapeOptimization.ViewModels;
using System;
using System.Windows.Input;

namespace ShapeOptimization.Commands
{
    public class SelectItemCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested += value;
        }

        public bool CanExecute(object parameter)
        {
            MainWindowViewModel Parameter = parameter as MainWindowViewModel;

            if (Parameter == null)
                return false;

            return true;
        }

        public void Execute(object parameter)
        {
            MainWindowViewModel Parameter = parameter as MainWindowViewModel;

            Parameter.SetMode(EditMode.SelectItem);
        }
    }
}
