using ShapeOptimization.Adorners;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Interactivity;
using System.Windows.Markup;

namespace ShapeOptimization.Behaviors
{
    [ContentProperty("Content")]
    public class XamlAdorner : Behavior<UIElement>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName]string property = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

        //TODO: Change this to a collection so that multiple adorners may be added.
        private static readonly DependencyProperty ContentProperty = DependencyProperty.Register("Content", typeof(object), typeof(XamlAdorner));
        public object Content
        {
            get { return (object)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        private Adorner _Adorner;
        private AdornerLayer _AdornerLayer = null;

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.AddHandler(FrameworkElement.LoadedEvent, new RoutedEventHandler(AssociatedObject_Loaded));
        }

        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            _AdornerLayer = AdornerLayer.GetAdornerLayer(AssociatedObject);
            _Adorner = new AdornerExtension(AssociatedObject, Content);
            _AdornerLayer.Add(_Adorner);
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.RemoveHandler(FrameworkElement.LoadedEvent, new RoutedEventHandler(AssociatedObject_Loaded));
            _AdornerLayer.Remove(_Adorner);
        }
    }
}
