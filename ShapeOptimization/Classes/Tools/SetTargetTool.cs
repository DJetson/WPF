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
    public class SetTargetTool : ToolBase
    {
        public SetTargetTool() : base()
        {
        }

        public SetTargetTool(IMainWindowViewModel parent) : base(parent)
        {

        }

        public override void Initialize()
        {
            base.Initialize();
            var selectedShape = Parent.SelectionContext.Current as IShapeViewModelBase;

            selectedShape.Target = new PointTargetViewModel(selectedShape);
        }

        public override void MouseDown(Point position)
        {
            base.MouseDown(position);

            var selectedShape = Parent.SelectionContext.Current as IShapeViewModelBase;

            selectedShape.Target.Position = position;
            if (!Parent.Items.Contains(selectedShape.Target))
                Parent.Items.Add(selectedShape.Target);
        }

        public override void MouseMove(Point position)
        {
            base.MouseMove(position);
            if (IsMouseDown)
            {
                var selectedShape = Parent.SelectionContext.Current as IShapeViewModelBase;

                selectedShape.Target.Tolerance = Vector.Subtract((Vector)position, (Vector)Start).Length / Math.Max(selectedShape.Size.Width, selectedShape.Size.Height);// Math.Sqrt(((selectedShape.Size.Width * selectedShape.Size.Width) + (selectedShape.Size.Height * selectedShape.Size.Height)));
                selectedShape.Target.Size = new Size(selectedShape.Size.Width * (selectedShape.Target.Tolerance * 1.75), selectedShape.Size.Height * (selectedShape.Target.Tolerance * 1.75));
            }
        }

        public override void MouseUp(Point position)
        {
            base.MouseUp(position);
        }
    }
}
