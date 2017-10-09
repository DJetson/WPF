using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeOptimization.Interfaces
{
    public interface IMainWindowViewModel : IHasDrawingContext, IHasToolContext, IHandlesMouseEvents
    {
        ISelectionContext SelectionContext { get; }
    }
}
