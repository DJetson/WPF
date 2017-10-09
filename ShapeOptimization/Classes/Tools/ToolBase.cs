using ShapeOptimization.Interfaces;
using ShapeOptimization.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShapeOptimization.Classes.Tools
{
    public class ToolBase : ITool
    {
        private IMainWindowViewModel _Parent;
        public IMainWindowViewModel Parent
        {
            get => _Parent;
            set { _Parent = value; }
        }

        private bool _IsMouseDown;
        public bool IsMouseDown
        {
            get => _IsMouseDown;
            set { _IsMouseDown = value; }
        }

        private Point _Start;
        public Point Start
        {
            get => _Start;
            set { _Start = value; }
        }

        protected ToolBase()
        {

        }

        public virtual void Initialize()
        {

        }

        public ToolBase(IMainWindowViewModel parent)
        {
            _Parent = parent;
        }

        public virtual void MouseDown(Point position)
        {
            _IsMouseDown = true;
            Start = position;
        }

        public virtual void MouseDown(IDrawableItem item)
        {

            item.MouseDown(item.Position);
        }

        public virtual void MouseMove(Point position)
        {
        }

        public virtual void MouseMove(IDrawableItem item)
        {
            item.MouseMove(item.Position);
        }

        public virtual void MouseUp(Point position)
        {
            _IsMouseDown = false;

        }

        public virtual void MouseUp(IDrawableItem item)
        {
            item.MouseUp(item.Position);
        }

        private void AddPoint(Point position)
        {
            _Parent.Items.Add(new PointViewModel(_Parent.SelectionContext, _Parent) { Position = position });
        }
    }
}
