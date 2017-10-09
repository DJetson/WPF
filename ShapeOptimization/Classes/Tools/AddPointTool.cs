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
    public class AddPointTool : ToolBase, ITool
    {
        public AddPointTool() : base()
        {

        }

        public AddPointTool(IMainWindowViewModel parent) : base(parent)
        {
        }

        public override void MouseDown(Point position)
        {
            base.MouseDown(position);
            Parent.Items.Add(new PointViewModel(Parent.SelectionContext, Parent) { Position = position });
        }
    }
}
