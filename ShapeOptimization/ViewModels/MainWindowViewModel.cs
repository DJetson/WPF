using ShapeOptimization.Classes;
using ShapeOptimization.Classes.Tools;
using ShapeOptimization.Interfaces;
using ShapeOptimization.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace ShapeOptimization.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        private Dictionary<EditMode, ITool> _Tools
            => new Dictionary<EditMode, ITool>
            {
                { EditMode.AddPoint, GetTool<AddPointTool>(EditMode.AddPoint) },
                { EditMode.AddLine, GetTool<AddLineTool>(EditMode.AddLine) },
                { EditMode.SelectItem, GetTool<SelectTool>(EditMode.SelectItem) },
                { EditMode.SetTarget, GetTool<SetTargetTool>(EditMode.SetTarget) }
            };

        private ITool GetTool<T>(EditMode mode) where T : ITool, new()
        {
            ITool tool = new T { Parent = this };

            return tool;
        }

        private ITool _SelectedTool;
        public ITool SelectedTool
        {
            get { return _SelectedTool; }
            private set { _SelectedTool = value; }
        }

        public bool IsInAddPointMode
        {
            get => SelectedTool is AddPointTool;
            set { if (value) SetMode(EditMode.AddPoint); }
        }

        public bool IsInAddLineMode
        {
            get => SelectedTool is AddLineTool;
            set { if (value) SetMode(EditMode.AddLine); }
        }

        public bool IsInSelectMode
        {
            get => SelectedTool is SelectTool;
            set { if (value) SetMode(EditMode.SelectItem); }
        }

        public bool IsInSetTargetMode
        {
            get => SelectedTool is SetTargetTool;
            set { if (value) SetMode(EditMode.SetTarget); }
        }

        public MainWindowViewModel()
        {
            SelectedTool = _Tools[EditMode.AddPoint];
        }

        private ObservableCollection<IDrawableItem> _Items = new ObservableCollection<IDrawableItem>();
        public ObservableCollection<IDrawableItem> Items
        {
            get { return _Items; }
            set { _Items = value; NotifyPropertyChanged(); }
        }

        private EditMode _Mode = EditMode.None;
        public EditMode Mode { get => _Mode; }

        private ISelectionContext _SelectionContext = new SelectionContext();
        public ISelectionContext SelectionContext => _SelectionContext;

        public void SetMode(EditMode newMode)
        {
            _Mode = newMode;
            SelectedTool = _Tools[_Mode];
        }

        public ITool SetTool(Type toolType)
        {
            if (!toolType.GetInterfaces().Contains(typeof(ITool)))
                throw new ArgumentException($"Cannot execute SetTool({toolType.Name}). It requires the runtime Type for a class which implements the ITool interface.");

            var lastTool = SelectedTool;
            SetMode(_Tools.Where(e => e.Value.GetType() == toolType).Select(e => e.Key).First());

            return lastTool;
        }

        public void MouseMove(Point position)
        {
            SelectedTool.MouseMove(position);
        }

        public void MouseDown(Point position)
        {
            SelectedTool.MouseDown(position);
        }

        private void DeselectAll()
        {
            SelectionContext.ClearSelection();
        }

        public void MouseUp(Point position)
        {
            SelectedTool.MouseUp(position);
        }

        private void AddLine(Point position)
        {
            Items.Add(new LineViewModel(SelectionContext, this) { Start = position, End = position });
        }

        private void AddPoint(Point position)
        {
            Items.Add(new PointViewModel(SelectionContext, this) { Position = position });
        }
    }
}
