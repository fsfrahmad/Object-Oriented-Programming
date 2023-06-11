using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022CS1_SelfAssesment2_OOP_Lab_7
{
    public class MenuUI
    {
        public static int Menu()
        {
            Console.WriteLine("1. Add Bicycle");
            Console.WriteLine("2. Add Motorcycle");
            Console.WriteLine("3. Increase Speed");
            Console.WriteLine("4. Decrease Speed");
            Console.WriteLine("5. Change Cadence");
            Console.WriteLine("6. Change Gear");
            Console.WriteLine("7. Change SeatHeight");
            Console.WriteLine("Enter any option to Continue>>>");
            return int.Parse(Console.ReadLine());
        }
        public static Bicycle AddBicycle()
        {
            Console.WriteLine("Enter Cadence");
            int cadence = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Gear");
            int gear = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Speed");
            int speed = int.Parse(Console.ReadLine());
            Bicycle NewBicycle = new Bicycle(cadence, gear, speed);
            return NewBicycle;
        }
        public static MountainBike AddMountainBike()
        {
            Console.WriteLine("Enter Cadence");
            int cadence = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Gear");
            int gear = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Speed");
            int speed = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter SeatHeight");
            int SeatHeight = int.Parse(Console.ReadLine());
            MountainBike NewMountainBike = new MountainBike(cadence, gear, speed, SeatHeight);
            return NewMountainBike;
        }
    }
}
