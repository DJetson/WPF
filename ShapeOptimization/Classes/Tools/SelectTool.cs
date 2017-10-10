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
        private RectangleViewModel _SelectionRectangle = null;
        public RectangleViewModel SelectionRectangle
        {
            get { return _SelectionRectangle; }
            set { _SelectionRectangle = value; }
        }

        public SelectTool() : base()
        {
        }

        public SelectTool(IMainWindowViewModel parent) : base(parent)
        {

        }

        public override void MouseDown(Point position)
        {
            base.MouseDown(position);
            SelectionRectangle = new RectangleViewModel() { Position = position, Size = new Size(1, 1) };
            Parent.Items.Add(SelectionRectangle);
        }

        public override void MouseMove(Point position)
        {
            base.MouseMove(position);
            if (!IsMouseDown)
                return;

            //Resize the selection Rect
            var Start = new Point(Math.Min(position.X, SelectionRectangle.Position.X), Math.Min(position.Y, SelectionRectangle.Position.Y));
            var End = new Point(Math.Max(position.X, SelectionRectangle.Position.X), Math.Max(position.Y, SelectionRectangle.Position.Y));

            SelectionRectangle.Position = Start;
            SelectionRectangle.Size = new Size(End.X - Start.X, End.Y - Start.Y);
        }

        public override void MouseUp(Point position)
        {
            if (!IsMouseDown)
                return;

            base.MouseUp(position);


            //if (Vector.Subtract((Vector)position, (Vector)Start).Length < Math.Sqrt(2))
            //{ 
            //    Parent.SelectionContext.ClearSelection();
            //    return;
            //}


            //Parent.SelectionContext.IsMultiSelectEnabled = true;

            Parent.SelectionContext.SelectAll(new List<ISelectableItem>(from selectable in Parent.SelectionContext.SelectableItems.Keys
                                                                        let item = selectable as IDrawableItem
                                                                        where item != null && new Rect(SelectionRectangle.Position, SelectionRectangle.Size).Contains(item.Position)
                                                                        select selectable));
            //Select all items within the selection rect and
            Parent.Items.Remove(SelectionRectangle);
            SelectionRectangle = null;
            //remove the selection rect
        }
    }
}
