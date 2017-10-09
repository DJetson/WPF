using ShapeOptimization.Interfaces;
using ShapeOptimization.Models;
using System.Windows;

namespace ShapeOptimization.ViewModels
{
    public class PointViewModel : ShapeViewModelBase
    {
        public override double Left
        {
            get { return _Position.X - (Size.Width / 2); }
        }

        public override double Top
        {
            get { return _Position.Y - (Size.Height / 2); }
        }

        protected PointViewModel() : base()
        {
            Size = new Size(10, 10);
        }

        public PointViewModel(ISelectionContext context, IMainWindowViewModel parent) : base(context, parent)
        {
            Size = new Size(10, 10);
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
        }
    }
}
