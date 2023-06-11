
using System;
using System.Collections.Generic;
using System.Linq;

namespace IceCreams
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IceCream> ices = GetIceCreamsFromInput();
            Console.WriteLine(SweetestIceCream(ices));
        }

        public static List<IceCream> GetIceCreamsFromInput()
        {
            List<IceCream> iceCreams = new List<IceCream>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; ++i)
            {
                string[] _params = Console.ReadLine().Split(' ');
                IceCream _iceCream = new IceCream(_params[0], int.Parse(_params[1]));
                iceCreams.Add(_iceCream);
            }

            return iceCreams;
        }

        public static int SweetestIceCream(List<IceCream> icecream)
        {
            int large = 0;
            for(int i = 0; i < icecream.Count; i++)
            {
                if(icecream[i].CalculateSweetness() > large)
                {
                    large = icecream[i].CalculateSweetness();
                }
            }
            return large;
        }
    }

    public class IceCream
    {
        public string flavour;
        public int Sprinkles;
        public IceCream(string flavour, int Sprinkles)
        {
            this.flavour = flavour;
            this.Sprinkles = Sprinkles;
        }
        public int CalculateSweetness()
        {
            if(flavour == "Plain")
            {
                return Sprinkles;
            }
            else if(flavour == "Vanilla")
            {
                return Sprinkles + 5;
            }
            else if(flavour == "ChocolateChip")
            {
                return Sprinkles + 5;
            }
            else if(flavour == "Strawberry")
            {
                return Sprinkles + 10;
            }
            else if(flavour == "Chocolate")
            {
                return Sprinkles + 10;
            }
            else
            {
                return 0;
            }
            
        }
    }
}