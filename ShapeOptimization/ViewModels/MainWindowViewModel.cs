using ShapeOptimization.Classes;
using ShapeOptimization.Interfaces;
using ShapeOptimization.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace ShapeOptimization.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IHandlesMouseEvents
    {
        private static EditMode _Mode = EditMode.None;
        private bool _IsMousePressed = false;

        private ObservableCollection<IDrawableItem> _Items = new ObservableCollection<IDrawableItem>();
        public ObservableCollection<IDrawableItem> Items
        {
            get { return _Items; }
            set { _Items = value; NotifyPropertyChanged(); }
        }

        public static EditMode Mode { get => _Mode; }

        private ISelectionContext _SelectionContext = new SelectionContext();
        public ISelectionContext SelectionContext => _SelectionContext;

        public void SetMode(EditMode newMode)
        {
            _Mode = newMode;
        }

        public void MouseMove(Point position)
        {
        }

        public void MouseDown(Point position)
        {
            _IsMousePressed = true;

            if (_Mode == EditMode.AddPoint)
                AddPoint(position);
            if (_Mode == EditMode.AddLine)
                AddLine(position);
            if (_Mode == EditMode.SelectItem)
                DeselectAll();
        }

        private void DeselectAll()
        {
            SelectionContext.ClearSelection();
        }
        
        public void MouseUp(Point position)
        {
            if (_Mode == EditMode.AddPoint)
            {
                Items.Last().Position = position;
            }
            if (_Mode == EditMode.AddLine)
            {
                var current = Items.Last(e => e is LineViewModel) as LineViewModel;
                current.End = position;
            }

            _IsMousePressed = false;
        }

        private void AddLine(Point position)
        {
            Items.Add(new LineViewModel(SelectionContext) { Start = position, End = position });
        }

        private void AddPoint(Point position)
        {
            Items.Add(new PointViewModel(SelectionContext) { Position = position });
        }
    }
}
