using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022CS1_SelfAssesment2_OOP_Lab_7
{
    public class MountainBike : Bicycle
    {
        private int SeatHeight;
        public MountainBike()
        {
        }

        public MountainBike(int cadence, int gear, int speed, int SeatHeight) : base(cadence, gear, speed)
        {
            this.SeatHeight = SeatHeight;
        }
        public void SetSeatHeight(int SeatHeight)
        {
            this.SeatHeight = SeatHeight;
        }
    }
}
