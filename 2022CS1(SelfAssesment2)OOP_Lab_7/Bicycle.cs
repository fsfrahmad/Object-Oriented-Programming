using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022CS1_SelfAssesment2_OOP_Lab_7
{
    public class Bicycle
    {
        protected int cadence;
        protected int gear;
        protected int speed;

        public Bicycle()
        {
        }
        public Bicycle(int cadence,int gear,int speed)
        {
            this.cadence = cadence;
            this.gear = gear;
            this.speed = speed;
        }
        public void SetCadence(int cadence)
        {
            this.cadence = cadence;
        }
        public void SetGear(int gear)
        {
            this.gear = gear;
        }
        public void ApplyBrakes(int Decrement)
        {
            speed = speed - Decrement;
        }
        public void SpeedUp(int Increment)
        {
            speed = speed + Increment;
        }
    }
}
