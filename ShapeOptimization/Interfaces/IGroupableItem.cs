using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShapeOptimization.Interfaces
{
    public interface IGroupableItem : IDrawableItem
    {
        Point LocalPosition { get; set; }
        IDrawableItem DrawableParent { get; set; }
    }
}
