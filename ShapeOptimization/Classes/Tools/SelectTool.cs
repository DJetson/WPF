using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ShapeOptimization.ViewModels;
using ShapeOptimization.Interfaces;

namespace ShapeOptimization.Classes.Tools
{
    public class SelectTool : ToolBase
    {
        public SelectTool() : base()
        {
        }

        public SelectTool(IMainWindowViewModel parent) : base(parent)
        {
        }

        public override void MouseDown(Point position)
        {
            base.MouseDown(position);
            //If we're here it means that no specific object was clicked so begin a Selection Rect
        }

        public override void MouseMove(Point position)
        {
            base.MouseMove(position);
            //Resize the selection Rect
        }

        public override void MouseUp(Point position)
        {
            base.MouseUp(position);
            //Select all items within the selection rect and
            //remove the selection rect
        }
    }
}
