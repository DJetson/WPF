using ShapeOptimization.ViewModels;
using System.Windows;

namespace ShapeOptimization.Interfaces
{
    public interface IShapeViewModelBase : IDrawableItem, ISelectableItem
    {
        double Left { get; }
        IMainWindowViewModel Parent { get; }
        double Top { get; }
        ITargetViewModel Target { get; set; }
    }
}