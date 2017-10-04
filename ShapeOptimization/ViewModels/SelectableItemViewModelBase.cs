using ShapeOptimization.Interfaces;
using System.Windows;

namespace ShapeOptimization.ViewModels
{
    public abstract class SelectableItemViewModelBase : DrawableViewModelBase, ISelectableItem, IHandlesMouseEvents
    {
        public virtual void NotifyIsSelectedChanged()
        {
            base.NotifyPropertyChanged("IsSelected");
        }

        public bool IsSelected
        {
            get { return SelectionContext.SelectableItems[this]; }
        }

        private ISelectionContext _SelectionContext;
        public ISelectionContext SelectionContext
        {
            get => _SelectionContext;
            private set { _SelectionContext = value; _SelectionContext.Register(this); }
        }

        protected SelectableItemViewModelBase()
        {

        }

        public SelectableItemViewModelBase(ISelectionContext context)
        {
            SelectionContext = context;
        }

        public void Select()
        {
            SelectionContext.Select(this);
        }

        public void Deselect()
        {
            SelectionContext.Deselect(this);
        }

        public abstract void MouseDown(Point position);

        public abstract void MouseMove(Point position);

        public abstract void MouseUp(Point position);

    }
}
