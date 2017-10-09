using System.Windows;

namespace ShapeOptimization.Interfaces
{
    public interface IDrawableItem : IHandlesMouseEvents, IHasPosition
    {
        Size Size { get; set; }
    }
}
