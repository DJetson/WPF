using System.Windows;
using System.Windows.Interactivity;

namespace ShapeOptimization.Behaviors
{
    public abstract class TrackMouseBase : Behavior<FrameworkElement>
    {
        protected static readonly DependencyProperty ParentProperty = DependencyProperty.Register("Parent", typeof(FrameworkElement), typeof(TrackMouseBase));
        public FrameworkElement Parent
        {
            get { return (FrameworkElement)GetValue(ParentProperty); }
            set { SetValue(ParentProperty, value); }
        }

        public virtual void Handle()
        {

        }
    }
}
