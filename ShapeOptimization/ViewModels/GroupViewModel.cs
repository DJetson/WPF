using ShapeOptimization.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShapeOptimization.ViewModels
{
    public class GroupViewModel : ShapeViewModelBase, IGroupableItem
    {
        public override double Left
        {
            get { return _Position.X - (Size.Width / 2); }
        }

        public override double Top
        {
            get { return _Position.Y - (Size.Height / 2); }
        }

        public override double Right
        {
            get { return _Position.X + (Size.Width / 2); }
        }

        public override double Bottom
        {
            get { return _Position.Y + (Size.Height / 2); }
        }

        private ObservableCollection<IGroupableItem> _Items = new ObservableCollection<IGroupableItem>();
        public ObservableCollection<IGroupableItem> Items
        {
            get { return _Items; }
            set { _Items = value; NotifyPropertyChanged(); }
        }

        public GroupViewModel(ISelectionContext context, IMainWindowViewModel parent) : base(context, parent)
        {
        }

        public void Add(IGroupableItem item)
        {
            if (Items.Contains(item))
                return;

            item.DrawableParent = this;

            Items.Add(item);
            RecalculatePosition();
            Resize();
        }

        public void Remove(IGroupableItem item)
        {
            if (!Items.Contains(item))
                return;

            item.DrawableParent = null;
            Items.Remove(item);

            RecalculatePosition();
            Resize();
        }

        public void AddRange(IEnumerable<IGroupableItem> items)
        {
            items.ToList().ForEach(e => Add(e));
        }

        public void RemoveRange(IEnumerable<IGroupableItem> items)
        {
            items.ToList().ForEach(e => Remove(e));
        }

        private void RecalculatePosition()
        {
            //Point newPosition = Items.First().Position;

            double totalX = 0;
            double totalY = 0;

            foreach (IShapeViewModelBase item in Items)
            {
                //if (item == Items.First())
                //    continue;

                //newPosition = new Point((item.Position.X - newPosition.X) / 2, (item.Position.Y - newPosition.Y) / 2);
                totalX += item.Position.X;
                totalY += item.Position.Y;
            }

            Position = new Point(totalX / Items.Count, totalY / Items.Count);

            foreach (IGroupableItem item in Items)
            {
                item.LocalPosition = (Point)(item.Position - Position);
            }
        }

        private void Resize()
        {
            double minX = double.MaxValue;
            double minY = double.MaxValue;
            double maxX = double.MinValue;
            double maxY = double.MinValue;

            foreach (IShapeViewModelBase item in Items)
            {
                minX = Math.Min(item.Left - Position.X, minX);
                minY = Math.Min(item.Top - Position.Y, minY);
                maxX = Math.Max(item.Right - Position.X, maxX);
                maxY = Math.Max(item.Bottom - Position.Y, maxY);
            }

            Size = new Size(Math.Max(maxX, minX) - Math.Min(maxX, minX), Math.Max(maxY, minY) - Math.Min(maxY, minY));
        }
    }
}
