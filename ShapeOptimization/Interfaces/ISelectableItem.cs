using System.ComponentModel;

namespace ShapeOptimization.Interfaces
{
    public interface ISelectableItem : INotifyPropertyChanged
    {
        void NotifyIsSelectedChanged();
        ISelectionContext SelectionContext { get; }
        bool IsSelected { get; }
        void Select();
        void Deselect();
    }
}
