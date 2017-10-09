using ShapeOptimization.Interfaces;
using System.Windows;

namespace ShapeOptimization.ViewModels
{
    public abstract class DrawableViewModelBase : ViewModelBase, IDrawableItem
    {
        protected Size _Size;
        public Size Size
        {
            get { return _Size; }
            set { _Size = value; NotifyPropertyChanged(); NotifyPropertyChanged("Top"); NotifyPropertyChanged("Left"); }
        }

        protected Point _Position;
        public Point Position
        {
            get { return _Position; }
            set { _Position = value; NotifyPropertyChanged(); NotifyPropertyChanged("Top"); NotifyPropertyChanged("Left"); }
        }

        public abstract double Left { get; }

        public abstract double Top { get; }

        public DrawableViewModelBase()
        {
        }

        public DrawableViewModelBase(double x, double y, double w, double h)
        {
            Position = new Point(x, y);
            Size = new Size(w, h);
        }

        public DrawableViewModelBase(double x, double y)
        {
            Position = new Point(x, y);
        }

        public abstract void MouseDown(Point position);

        public abstract void MouseMove(Point position);

        public abstract void MouseUp(Point position);
    }
}
