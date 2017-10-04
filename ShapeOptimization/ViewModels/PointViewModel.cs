using ShapeOptimization.Interfaces;
using ShapeOptimization.Models;
using System.Windows;

namespace ShapeOptimization.ViewModels
{
    public class PointViewModel : SelectableItemViewModelBase
    {
        private bool _IsMouseDown = false;

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

        public PointViewModel(ISelectionContext context) : base(context)
        {
            Size = new Size(10, 10);
        }

        public override void MouseDown(Point position)
        {
            _IsMouseDown = true;

            if (MainWindowViewModel.Mode == EditMode.SelectItem)
                Select();
        }

        public override void MouseMove(Point position)
        {
            if (_IsMouseDown)
                Position = position;
        }

        public override void MouseUp(Point position)
        {
            if(_IsMouseDown)
            {

            }

            _IsMouseDown = false;
        }
    }
}
