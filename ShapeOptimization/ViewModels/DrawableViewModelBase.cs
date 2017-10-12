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
            set { _Size = value; NotifyPropertyChanged(); NotifyBoundsChanged(); }
        }

        protected Point _Position;
        public Point Position
        {
            get { return _Position; }
            set { _Position = value; NotifyPropertyChanged(); NotifyBoundsChanged(); }
        }

        public abstract double Left { get; }

        public abstract double Top { get; }

        public abstract double Right { get; }

        public abstract double Bottom { get; }

        protected void NotifyBoundsChanged()
        {
            NotifyPropertyChanged("Top");
            NotifyPropertyChanged("Left");
            NotifyPropertyChanged("Right");
            NotifyPropertyChanged("Bottom");

        }

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
