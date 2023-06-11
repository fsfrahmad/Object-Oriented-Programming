using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointGame.BL;

namespace PointGame.BL
{
    public class Boundary
    {
        public MyPoint TopLeft;
        public MyPoint TopRight;
        public MyPoint BottomLeft;
        public MyPoint BottomRight;
        public Boundary()
        {
            TopLeft = new MyPoint(0, 0);
            TopRight = new MyPoint(0, 90);
            BottomLeft = new MyPoint(90, 0);
            BottomRight = new MyPoint(90, 90);
        }
        public Boundary(MyPoint TopLeft, MyPoint TopRight, MyPoint BottomLeft, MyPoint BottomRight)
        {
            this.TopLeft = TopLeft;
            this.TopRight = TopRight;
            this.BottomLeft = BottomLeft;
            this.BottomRight = BottomRight;
        }
    }
}
