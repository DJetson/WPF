using ShapeOptimization.Classes.Tools;
using ShapeOptimization.Interfaces;
using ShapeOptimization.Models;
using ShapeOptimization.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShapeOptimization.Commands
{
    public class SelectAddPointToolCommand : SelectToolCommandBase
    {
        public override bool CanExecute(object parameter)
        {
            IMainWindowViewModel Parameter = parameter as IMainWindowViewModel;

            if (Parameter == null)
                return false;

            return true;
        }

        public override void Execute(object parameter)
        {
            IMainWindowViewModel Parameter = parameter as IMainWindowViewModel;

            Parameter?.SetTool(typeof(AddPointTool));
        }
    }
}
