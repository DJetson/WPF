using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeOptimization.Interfaces
{
    public interface IHasDrawingContext
    {
        ObservableCollection<IDrawableItem> Items { get; set; }
    }
}
