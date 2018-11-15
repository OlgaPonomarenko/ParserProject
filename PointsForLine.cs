using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ParseProject
{
    public class PointsForLine
    {
        public Point startLine { get; private set; }
        public Point endLine { get; private set; }

        public PointsForLine(int _xStart, int _yStart, int _xEnd, int _yEnd)
        {
            startLine = new Point(_xStart, _yStart);
            endLine = new Point(_xEnd, _yEnd);
        }
    }
}
