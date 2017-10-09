using ShapeOptimization.Interfaces;
using ShapeOptimization.Models;
using System;
using System.Windows;

namespace ShapeOptimization.ViewModels
{
    public class LineViewModel : ShapeViewModelBase, IHandlesMouseEvents
    {
        public override double Left
        {
            get { return Math.Min(Start.X, End.X); }
        }

        public override double Top
        {
            get { return Math.Min(Start.Y, End.Y); }
        }

        private double _Angle;
        public double Angle
        {
            get { return _Angle; }
            set { _Angle = value; NotifyPropertyChanged(); }
        }

        private Point _Start;
        public Point Start
        {
            get { return _Start; }
            set { _Start = value; NotifyPropertyChanged(); NotifyPropertyChanged("Left"); NotifyPropertyChanged("Top"); }
        }

        private Point _End;
        public Point End
        {
            get { return _End; }
            set { _End = value; UpdateOrientation(); NotifyPropertyChanged(); NotifyPropertyChanged("Left"); NotifyPropertyChanged("Top"); }
        }

        private void UpdateOrientation()
        {
            Vector path = new Vector(End.X - Start.X, End.Y - Start.Y);

            Angle = Vector.AngleBetween(new Vector(1, 0), path);

            Size = new Size(path.Length, Size.Height);
        }

        protected LineViewModel() : base()
        {
            Size = new Size(0, 10);
        }

        public LineViewModel(ISelectionContext context, IMainWindowViewModel parent) : base(context, parent)
        {
            Size = new Size(0, 10);
        }

        public override void MouseDown(Point position)
        {
            IsMouseDown = true;

            //If we're here it means that a specific object has been clicked
            //TODO: Figure out where modified selection logic should go. (i.e. Modifier keys)
            //TODO: This needs to handle MouseDown events for any kind of tool that has a single item behavior
            //      This might mean that the tool has a general and a specific mouse down event
            if (Parent.Mode == EditMode.SelectItem)
                Select();
            else
                base.MouseDown(position);
            //TODO:
            //Check whether it's closer to the start point, end point, or center
            //track which of the above three and the start point of the path we're about to trace
        }

        public override void MouseMove(Point position)
        {
            //TODO:
            //If the closest existing point is the center, begin moving the entire line to the new position
            //Otherwise, move the appropriate terminating point (closest of start or end) to the new position
        }
    }
}
