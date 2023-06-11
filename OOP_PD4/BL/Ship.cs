using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_PD4.BL
{
    class Ship
    {
        public string Number;
        public Angle Longitude;

        public Angle Latitude;
        public Ship(string number, Angle Longitude, Angle Latitude)
        {
            this.Number = number;
            this.Longitude = Longitude;
            this.Latitude = Latitude;
        }
        public Ship(string number)
        {
            this.Number = number;
        }
        public Ship(Angle Longitude, Angle Latitude)
        {
            this.Longitude = Longitude;
            this.Latitude = Latitude;
        }
        public Ship ShipExists(List<Ship> Ships)
        {
            for (int i = 0; i < Ships.Count; i++)
            {
                if (Number == Ships[i].Number)
                {
                    return Ships[i];
                }
            }
            return null;
        }
        public Ship FindShipNumberByDirection(List<Ship> Ships)
        {
            for (int i = 0; i < Ships.Count; i++)
            {
                if(Latitude.Degree == Ships[i].Latitude.Degree && Latitude.Minute == Ships[i].Latitude.Minute && Latitude.Direction == Ships[i].Latitude.Direction && Longitude.Degree == Ships[i].Longitude.Degree && Longitude.Minute == Ships[i].Longitude.Minute && Longitude.Direction== Ships[i].Longitude.Direction)
                {
                    return Ships[i];
                }
            }
            return null;
        }
    }
    class Angle
    {
        public int Degree;
        public float Minute;
        public char Direction;
        public Angle(int Degree, float Minute, char Direction)
        {
            this.Degree = Degree;
            this.Minute = Minute;
            this.Direction = Direction;
        }

    }
}
