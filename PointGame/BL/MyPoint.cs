using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointGame.BL
{
    public class MyPoint
    {
        public int x;
        public int y;
        public MyPoint()
        {
            x = 0;
            y = 0;
        }
        public MyPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int GetX()
        {
            return x;
        }
        public int GetY()
        {
            return y;
        }
        public void SetX(int x)
        {
            this.x = x;
        }
        public void SetY(int y)
        {
            this.y = y;
        }
        public void SetXY(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public double Distance(int x1, int y1)
        {
            return Math.Sqrt(Math.Pow((x - x1), 2) + Math.Pow((y - y1), 2));
        }
    }
}
