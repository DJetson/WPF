using ShapeOptimization.Interfaces;
using System.Windows.Input;

namespace ShapeOptimization.Behaviors
{
    public class TrackMouseDown : TrackMouseBase
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.MouseLeftButtonDown += AssociatedObject_MouseDown;
        }

        private void AssociatedObject_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!e.Handled)
            {
                Handle();
                e.Handled = true;
            }
        }

        public override void Handle()
        {
            var context = AssociatedObject.DataContext as IHandlesMouseDown;
            context?.MouseDown(Mouse.GetPosition(Parent ?? AssociatedObject));
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.MouseLeftButtonDown -= AssociatedObject_MouseDown;
        }
    }
}
