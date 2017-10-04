using ShapeOptimization.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ShapeOptimization.Classes
{
    public class SelectionContext : ISelectionContext
    {
        private ISelectableItem _Current;
        public ISelectableItem Current
        {
            get { return _Current; }
            private set { _Current = value; }
        }

        private bool _IsMultiSelectEnabled;
        public bool IsMultiSelectEnabled
        {
            get { return _IsMultiSelectEnabled; }
            set { _IsMultiSelectEnabled = value; }
        }

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

            if (IsMultiSelectEnabled == false && Current != null)
                Deselect(Current);

            _SelectableItems[item] = true;
            Current = item;
            item.NotifyIsSelectedChanged();
        }

        public void Deselect(ISelectableItem item)
        {
            Register(item);
            int index = Math.Max(_SelectedItems.IndexOf(Current) - 1,0);

            _SelectableItems[item] = false;

            if (_SelectedItems.Count == 0)
                Current = null;
            else if (index - 1 < 0)
                Current = _SelectedItems.First();
            else if (index - 1 > _SelectedItems.Count)
                Current = _SelectedItems.Last();
            else
                Current = _SelectedItems[index - 1];

            item.NotifyIsSelectedChanged();
        }
    }
}
