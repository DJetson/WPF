using ShapeOptimization.Interfaces;
using System.Windows.Input;

namespace ShapeOptimization.Behaviors
{
    public class TrackMouseUp : TrackMouseBase
    {
        protected override void OnAttached()
        {
            AssociatedObject.MouseLeftButtonUp += AssociatedObject_MouseUp;
        }

        private void AssociatedObject_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!e.Handled)
            {
                Handle();
                e.Handled = true;
            }
        }

        public override void Handle()
        {
            var context = AssociatedObject.DataContext as IHandlesMouseEvents;
            context?.MouseUp(Mouse.GetPosition(Parent ?? AssociatedObject));
        }

        protected override void OnDetaching()
        {
            AssociatedObject.MouseLeftButtonUp -= AssociatedObject_MouseUp;
        }
    }
}
