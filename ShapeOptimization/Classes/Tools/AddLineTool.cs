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
    public class AddLineTool : ToolBase
    {
        private LineViewModel _ToAdd;

        public AddLineTool() : base()
        {
        }

        public AddLineTool(IMainWindowViewModel parent) : base(parent)
        {
        }

        public override void MouseDown(Point position)
        {
            base.MouseDown(position);
            _ToAdd = new LineViewModel(Parent.SelectionContext, Parent) { Start = position, End = position };
            Parent.Items.Add(_ToAdd);
        }

        public override void MouseMove(Point position)
        {
            base.MouseMove(position);
            if (!IsMouseDown)
                return;

            _ToAdd.End = position;
        }

        public override void MouseUp(Point position)
        {
            base.MouseUp(position);
            _ToAdd.End = position;
            _ToAdd = null;
        }
    }
}
