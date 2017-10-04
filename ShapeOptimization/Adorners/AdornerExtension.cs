using ShapeOptimization.Interfaces;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;

namespace ShapeOptimization.Adorners
{
    [ContentProperty("ContentControl")]
    public class AdornerExtension : Adorner, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName]string property = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

        private VisualCollection _VisualTree;

        public AdornerExtension(UIElement adornedElement, object adornerContent) : base(adornedElement)
        {
            this.HorizontalAlignment = HorizontalAlignment.Stretch;
            this.VerticalAlignment = VerticalAlignment.Stretch;

            DataContext = (adornedElement as FrameworkElement)?.DataContext;
            var target = DataContext as INotifyPropertyChanged;

            target.PropertyChanged += Target_PropertyChanged;

            _VisualTree = new VisualCollection(this);
            ContentControl = new ContentControl() { DataContext = this.DataContext };
            ContentControl.Content = adornerContent;
            _VisualTree.Add(ContentControl);
        }

        private void Target_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (!(sender is IDrawableItem))
                return;

            this.InvalidateMeasure();
            this.InvalidateArrange();
            this.InvalidateVisual();
        }

        private ContentControl _ContentControl;
        public ContentControl ContentControl
        {
            get { return _ContentControl; }
            set { _ContentControl = value; NotifyPropertyChanged(); }
        }

        protected override Size MeasureOverride(Size constraint)
        {
            ContentControl.Measure(constraint);
            return ContentControl.DesiredSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            ContentControl.Arrange(new Rect(0, 0,
                 AdornedElement.DesiredSize.Width, AdornedElement.DesiredSize.Height));
            return ContentControl.RenderSize;
        }

        protected override Visual GetVisualChild(int index)
        { return _VisualTree[index]; }

        protected override int VisualChildrenCount
        { get { return _VisualTree.Count; } }
    }
}
