using ShapeOptimization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeOptimization.Interfaces
{
    public interface IHasToolContext
    {
        ITool SelectedTool { get; }
        EditMode Mode { get; }
        ITool SetTool(Type toolType);
    }
}
