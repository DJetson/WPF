using System.Windows;

namespace ShapeOptimization.Interfaces
{
    public interface IHandlesMouseEvents
    {
        void MouseDown(Point position);
        void MouseMove(Point position);
        void MouseUp(Point position);
    }
}
