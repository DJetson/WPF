using ShapeOptimization.Interfaces;
using System.Windows.Input;

namespace ShapeOptimization.Behaviors
{
    public class TrackMouseMove : TrackMouseBase
    {
        protected override void OnAttached()
        {
            AssociatedObject.MouseMove += AssociatedObject_MouseMove;
        }

        private void AssociatedObject_MouseMove(object sender, MouseEventArgs e)
        {
            if (!e.Handled)
            {
                Handle();
                e.Handled = true;
            }
        }

        public override void Handle()
        {
            var context = AssociatedObject.DataContext as IHandlesMouseMove;
            context?.MouseMove(Mouse.GetPosition(Parent ?? AssociatedObject));
        }

        protected override void OnDetaching()
        {
            AssociatedObject.MouseLeftButtonDown -= AssociatedObject_MouseMove;
        }
    }
}
