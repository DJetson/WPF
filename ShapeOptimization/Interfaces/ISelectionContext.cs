using System.Collections.Generic;

namespace ShapeOptimization.Interfaces
{
    public interface ISelectionContext
    {
        IReadOnlyCollection<ISelectableItem> SelectedItems { get; }
        IReadOnlyDictionary<ISelectableItem,bool> SelectableItems { get; }
        void Register(ISelectableItem item);
        void Register(IEnumerable<ISelectableItem> items);
        void ClearSelection();
        void SelectAll();
        void SelectAll(IEnumerable<ISelectableItem> items);
        void InvertSelection();
        void Select(ISelectableItem item, bool? changeMultiSelectMode = null);
        void Deselect(ISelectableItem item);
        ISelectableItem Current { get; }
        bool IsMultiSelectEnabled { get; }
    }
}
