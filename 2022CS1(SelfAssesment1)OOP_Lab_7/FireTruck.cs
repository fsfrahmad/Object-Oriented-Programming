using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP_Lab_07
{
    public class FireTruck
    {
        private string TruckNo;
        private Ladder TruckLadder;
        private Hose_Pipe TruckPipe;
        public FireTruck(string TruckNo, Ladder TruckLadder, Hose_Pipe TruckPipe)
        {
            this.TruckNo = TruckNo;
            this.TruckLadder = TruckLadder;
            this.TruckPipe = TruckPipe;
        }
        public FireTruck(string TruckNo)
        {
            this.TruckNo = TruckNo;
        }

        public string GetTruckNo()
        {
            return TruckNo;
        }
    }
    
}