using ShapeOptimization.Interfaces;
using System.Windows.Input;

namespace ShapeOptimization.Behaviors
{
    public class TrackMouseEvents : TrackMouseBase
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.MouseMove += AssociatedObject_MouseMove;
            AssociatedObject.MouseLeftButtonUp += AssociatedObject_MouseUp;
            AssociatedObject.MouseLeftButtonDown += AssociatedObject_MouseDown;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.MouseMove -= AssociatedObject_MouseMove;
            AssociatedObject.MouseLeftButtonUp -= AssociatedObject_MouseUp;
            AssociatedObject.MouseLeftButtonDown -= AssociatedObject_MouseDown;
        }

        private void AssociatedObject_MouseMove(object sender, MouseEventArgs e)
        {
            if (!e.Handled)
            {
                HandleMouseMove();
                e.Handled = true;
            }
        }

        private void HandleMouseMove()
        {
            var context = AssociatedObject.DataContext as IHandlesMouseEvents;
            context?.MouseMove(Mouse.GetPosition(Parent ?? AssociatedObject));
        }

        private void AssociatedObject_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!e.Handled)
            {
                HandleMouseUp();
                e.Handled = true;
            }
        }

        private void HandleMouseUp()
        {
            var context = AssociatedObject.DataContext as IHandlesMouseEvents;
            context?.MouseUp(Mouse.GetPosition(Parent ?? AssociatedObject));
        }

        private void AssociatedObject_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!e.Handled)
            {
                HandleMouseDown();
                e.Handled = true;
            }
        }

        private void HandleMouseDown()
        {
            var context = AssociatedObject.DataContext as IHandlesMouseEvents;
            context?.MouseDown(Mouse.GetPosition(Parent ?? AssociatedObject));
        }
    }
}
