using ShapeOptimization.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShapeOptimization.Interfaces
{
    public interface ITool : IHandlesMouseEvents
    {
        IMainWindowViewModel Parent { get; set; }
        bool IsMouseDown { get; set; }
        Point Start { get; set; }
        void Initialize();
    }
}
