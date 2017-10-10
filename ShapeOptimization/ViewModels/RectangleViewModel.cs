using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeOptimization.ViewModels
{
    public class RectangleViewModel : ShapeViewModelBase
    {
        public override double Left
        {
            get { return _Position.X - (Size.Width / 2); }
        }

        public override double Top
        {
            get { return _Position.Y - (Size.Height / 2); }
        }
    }
}
