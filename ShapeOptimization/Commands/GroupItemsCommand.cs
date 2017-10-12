using ShapeOptimization.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShapeOptimization.Commands
{
    public class GroupItemsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            IMainWindowViewModel Parameter = parameter as IMainWindowViewModel;

            if (Parameter?.SelectionContext?.Current == null)
                return false;

            return true;
        }

        public void Execute(object parameter)
        {
            IMainWindowViewModel Parameter = parameter as IMainWindowViewModel;

            Parameter?.CreateGroup();
        }
    }
}
