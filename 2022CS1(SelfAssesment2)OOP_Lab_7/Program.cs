using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022CS1_SelfAssesment2_OOP_Lab_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int Option = MenuUI.Menu();
            Console.ReadKey();
            Console.Clear();
            Bicycle NewBicycle = new Bicycle();
            MountainBike NewMountainBike = new MountainBike();
            if (Option == 1)
            {
                NewBicycle = MenuUI.AddBicycle();
            }
            else if(Option == 2)
            {
                NewMountainBike = MenuUI.AddMountainBike();
            }
            else if(Option == 3)
            {
                Console.WriteLine("Enter Increment");
                int increment = int.Parse(Console.ReadLine());
                if(NewBicycle != null)
                NewBicycle.SpeedUp(increment);
                if(NewMountainBike != null)
                NewMountainBike.SpeedUp(increment);
            }
            else if(Option == 4)
            {
                Console.WriteLine("Enter |Decrement");
                int decrement = int.Parse(Console.ReadLine());
                if (NewBicycle != null)
                    NewBicycle.ApplyBrakes(decrement);
                if (NewMountainBike != null)
                    NewMountainBike.ApplyBrakes(decrement);
            }
            else if(Option == 5)
            {
                Console.WriteLine("Enter Cadence");
                int cadence = int.Parse(Console.ReadLine());
                if (NewBicycle != null)
                    NewBicycle.SetCadence(cadence);
                if (NewMountainBike != null)
                    NewMountainBike.SetCadence(cadence);
            }
            else if(Option == 6)
            {
                Console.WriteLine("Enter Gear");
                int gear = int.Parse(Console.ReadLine());
                if (NewBicycle != null)
                    NewBicycle.SetGear(gear);
                if (NewMountainBike != null)
                    NewMountainBike.SetGear(gear);
            }
            else if(Option == 7)
            {
                Console.WriteLine("Enter SeatHeight");
                int SeatHeight = int.Parse(Console.ReadLine());
                if (NewMountainBike != null)
                    NewMountainBike.SetSeatHeight(SeatHeight);
            }
        }
    }
}
