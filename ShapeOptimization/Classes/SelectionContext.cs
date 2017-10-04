using ShapeOptimization.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ShapeOptimization.Classes
{
    public class SelectionContext : ISelectionContext
    {
        private List<ISelectableItem> _SelectedItems { get => _SelectableItems.Where(e => e.Value == true).Select(e => e.Key).ToList(); }
        public IReadOnlyCollection<ISelectableItem> SelectedItems
        {
            get => new ReadOnlyCollection<ISelectableItem>(_SelectedItems);
        }

        private Dictionary<ISelectableItem, bool> _SelectableItems = new Dictionary<ISelectableItem, bool>();
        public IReadOnlyDictionary<ISelectableItem, bool> SelectableItems
        {
            get => new ReadOnlyDictionary<ISelectableItem, bool>(_SelectableItems);
        }

        public void Register(ISelectableItem item)
        {
            if (!_SelectableItems.ContainsKey(item))
                _SelectableItems.Add(item, false);
        }

        public void Register(IEnumerable<ISelectableItem> items)
        {
            items.ToList().ForEach(e => Register(e));
        }

        public void ClearSelection()
        {
            _SelectedItems.ForEach(e => Deselect(e));
        }

        public void SelectAll()
        {
            SelectAll(_SelectableItems.Where(e => e.Value == false).Select(e => e.Key));
        }

        public void SelectAll(IEnumerable<ISelectableItem> items)
        {
            items.ToList().ForEach(e => Select(e));
        }

        public void InvertSelection()
        {
            _SelectableItems.ToList().ForEach(e => { if (e.Value) Deselect(e.Key); Select(e.Key); });
        }

        public void Select(ISelectableItem item)
        {
            Register(item);
            _SelectableItems[item] = true;
            item.NotifyIsSelectedChanged();
        }

        public void Deselect(ISelectableItem item)
        {
            Register(item);
            _SelectableItems[item] = false;
            item.NotifyIsSelectedChanged();
        }
    }
}
