using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointGame.BL;

namespace PointGame
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] Triangle = new char[5, 3]
            {
                {'@', ' ', ' ' },
                {'@', '@', ' ' },
                {'@', '@', '@' },
                {'@', '@', ' ' },
                {'@', ' ', ' ' }
            };
            char[,] OpTriangle = new char[5, 3]
            {
                {' ', ' ', '@' },
                {' ', '@', '@' },
                {'@', '@', '@' },
                {' ', '@', '@' },
                {' ', ' ', '@' }
            };
            Boundary b = new Boundary();
            GameObject g1 = new GameObject(Triangle, new MyPoint(5, 5), "LeftToRight", b);
            GameObject g2 = new GameObject(OpTriangle, new MyPoint(30, 60), "RightToLeft", b);
            g1.Move();
            g2.Move();
            Console.ReadKey();

        }
    }
}
