using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using PointGame.BL;
using EZInput;

namespace PointGame.BL
{
    public class GameObject
    {
        public char[,] Shape;
        public MyPoint StartingPoint;
        public Boundary Premises;
        public string Direction;

        public GameObject()
        {
            Shape = new char[3, 3]
            {
                { '-', '-', '-'},
                { '-', '-', '-'},
                { '-', '-', '-'}
            };
            StartingPoint = new MyPoint();
            Premises = new Boundary();
            Direction = "LeftToRight";
        }
        public GameObject(char[,] Shape, MyPoint StartingPoint,string Direction, Boundary Premises)
        {
            this.Shape = Shape;
            this.StartingPoint = StartingPoint;
            this.Premises = Premises;
            this.Direction = Direction;
        }
        public void Move()
        {
            if(Direction == "LeftToRight")
            {
                while (StartingPoint.x != Premises.BottomRight.x && StartingPoint.x != Premises.TopRight.x) 
                {
                    Draw(StartingPoint);
                    Thread.Sleep(1000);
                    Erase(StartingPoint);
                    StartingPoint.x++;
                }
                    
            }
            else if(Direction == "RightToLeft")
            {
                while (StartingPoint.x != Premises.TopLeft.x && StartingPoint.x != Premises.BottomLeft.x) 
                {
                    Draw(StartingPoint);
                    Thread.Sleep(1000);
                    Erase(StartingPoint);
                    StartingPoint.x--;
                }
                    
            }
        }
        public void Draw(MyPoint Point)
        {
            Console.SetCursorPosition(Point.x, Point.y);
            for (int row = 0; row < Shape.GetLength(0); row++)
            {
                for (int col = 0; col < Shape.GetLength(1); col++)
                {
                    Console.Write(Shape[row,col]);
                }
                Point.y++;
                Console.SetCursorPosition(Point.x, Point.y);
            }
            Point.y = Point.y - Shape.GetLength(0);
        }
        public void Erase(MyPoint Point)
        {
            Console.SetCursorPosition(Point.x, Point.y);
            for (int row = 0; row < Shape.GetLength(0); row++)
            {
                for (int col = 0; col < Shape.GetLength(1); col++)
                {
                    Console.Write(" ");
                }
                Point.y++;
                Console.SetCursorPosition(Point.x, Point.y);
            }
            Point.y = Point.y - Shape.GetLength(0);
        }
    }
}
