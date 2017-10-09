using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ShapeOptimization.Interfaces;

namespace ShapeOptimization.ViewModels
{
    public class PointTargetViewModel : PointViewModel, ITargetViewModel
    {
        private IShapeViewModelBase _OriginalShape;
        public IShapeViewModelBase OriginalShape
        {
            get { return _OriginalShape; }
            private set { _OriginalShape = value; }
        }

        //Since this represents a scale factor for the original shape, it doesn't make sense for it to ever be less than 1
        private double _Tolerance = 1.0f;
        public double Tolerance
        {
            get { return _Tolerance; }
            set { _Tolerance = value >= 1.0f ? value : 1.0f; NotifyPropertyChanged(); NotifyPropertyChanged("Left"); NotifyPropertyChanged("Top"); }
        }

        public PointTargetViewModel(IShapeViewModelBase originalShape) : base(originalShape.SelectionContext, originalShape.Parent)
        {
            OriginalShape = originalShape;
        }

        protected PointTargetViewModel()
        {
        }

        public override void MouseDown(Point position)
        {
            base.MouseDown(position);
        }

        public override void MouseMove(Point position)
        {
            base.MouseMove(position);
        }

        public override void MouseUp(Point position)
        {
            base.MouseUp(position);
        }
    }
}
