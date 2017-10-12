using ShapeOptimization.ViewModels;
using System.Windows;

namespace ShapeOptimization.Interfaces
{
    public interface IShapeViewModelBase : IDrawableItem, ISelectableItem
    {
        double Left { get; }
        double Top { get; }
        double Right { get; }
        double Bottom { get; }
        IMainWindowViewModel Parent { get; }
        ITargetViewModel Target { get; set; }
    }
}