using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_07
{
    class FireFighterMenuUI
    {
        public static Ladder AddLadder()
        {
            Console.WriteLine("Enter Ladder Size:");
            int size = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Ladder Color: ");
            string colour = Console.ReadLine();
            Ladder NewLadder = new Ladder(size, colour);
            return NewLadder;
        }
        public static Hose_Pipe AddHosePipe()
        {
            Console.Write("Enter the Made value: ");
            string made = Console.ReadLine();
            Console.Write("Enter the Shape value: ");
            string shape = Console.ReadLine();
            Console.Write("Enter the Diameter value: ");
            float diameter = float.Parse(Console.ReadLine());
            Console.Write("Enter the FlowRate value: ");
            float flowRate = float.Parse(Console.ReadLine());
            Hose_Pipe NewPipe = new Hose_Pipe(made, shape, diameter, flowRate);
            return NewPipe;
        }
        public static FireTruck AddFireTruck()
        {
            Ladder TruckLadder = AddLadder();
            Hose_Pipe TruckPipe = AddHosePipe();
            Console.WriteLine("Enter Truck Number:");
            string TruckNo = Console.ReadLine();
            FireTruck NewTruck = new FireTruck(TruckNo, TruckLadder, TruckPipe);
            return NewTruck;
        }
        public static int Menu()
        {
            int option;
            Console.WriteLine("1.Add Truck");
            Console.WriteLine("2.Add FireFighter");
            Console.WriteLine("3.Add FireCheif");
            Console.WriteLine("Enter Any option: ");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        public static void AddFireFighter()
        {
            Console.WriteLine("Enter Name: ");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter Truck No : ");
            FireTruck NewTruck = new FireTruck(Console.ReadLine());
            FireFighter NewFighter = new FireFighter(Name, NewTruck);
        }
        public static void AddFireChief()
        {
            Console.WriteLine("Enter Name: ");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter Truck No : ");
            FireTruck NewTruck = new FireTruck(Console.ReadLine());
            FireChief NewChief = new FireChief(Name, NewTruck);
        }
    }
}
