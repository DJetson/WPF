using ShapeOptimization.Adorners;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Interactivity;
using System.Windows.Markup;

namespace ShapeOptimization.Behaviors
{
    [ContentProperty("AdornerContent")]
    public class AttachAdorners : Behavior<UIElement>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName]string property = "")
    => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

        //TODO: Change this to a collection so that multiple adorners may be added.
        //private static readonly DependencyProperty AdornerProperty = DependencyProperty.Register("Adorner", typeof(AdornerMetadata), typeof(AttachAdorners));
        //public AdornerMetadata Adorner
        //{
        //    get { return (AdornerMetadata)GetValue(AdornerProperty); }
        //    set { SetValue(AdornerProperty, value); }
        //}

        private ContentControl _AdornerContent = new ContentControl();
        public object AdornerContent
        {
            get { return _AdornerContent.Content; }
            set { _AdornerContent.Content = value; NotifyPropertyChanged(); }
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
            _Adorner = new AdornerExtension(AssociatedObject, AdornerContent);
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
