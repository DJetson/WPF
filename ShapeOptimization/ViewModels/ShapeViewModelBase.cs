using ShapeOptimization.Interfaces;
using ShapeOptimization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShapeOptimization.ViewModels
{
    public abstract class ShapeViewModelBase : SelectableItemViewModelBase, IShapeViewModelBase, IGroupableItem
    {
        protected bool IsMouseDown { get; set; }

        public override abstract double Left { get; }

        public override abstract double Top { get; }

        public override abstract double Right { get; }

        public override abstract double Bottom { get; }

        public IMainWindowViewModel Parent { get; }

        private ITargetViewModel _Target = null;
        public ITargetViewModel Target
        {
            get { return _Target; }
            set { _Target = value; NotifyPropertyChanged(); }
        }

        public Point LocalPosition
        {
            get { return (Point)(_Position - (DrawableParent?.Position ?? new Point(0, 0))); }
            set { Position = (value + (Vector)(DrawableParent?.Position ?? new Point(0, 0))); NotifyPropertyChanged(); }
        }

        private IDrawableItem _DrawableParent = null;
        public IDrawableItem DrawableParent
        {
            get { return _DrawableParent; }
            set { _DrawableParent = value; NotifyPropertyChanged(); NotifyPropertyChanged("LocalPosition"); }
        }

        protected ShapeViewModelBase() : base()
        {
        }

        public ShapeViewModelBase(ISelectionContext context, IMainWindowViewModel parent) : base(context)
        {
            Parent = parent;
        }

        public override void MouseDown(Point position)
        {
            IsMouseDown = true;

            if (Parent.Mode == EditMode.SelectItem)
                Select();
            else
                Parent.SelectedTool.MouseDown(position);
        }

        public override void MouseMove(Point position)
        {
            Parent.SelectedTool.MouseMove(position);
        }

        public override void MouseUp(Point position)
        {
            Parent.SelectedTool.MouseUp(position);
            IsMouseDown = false;
        }
    }
}
