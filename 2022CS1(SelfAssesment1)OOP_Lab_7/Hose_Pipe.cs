using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP_Lab_07
{
    public class Hose_Pipe
    {
        private string Made;
        private string shape;
        private float Diameter;
        private float WaterFlowRate;
        public Hose_Pipe(string Made, string shape, float Diameter, float WaterFlowRate)
        {
            this.Made = Made;
            this.shape = shape;
            this.Diameter = Diameter;
            this.WaterFlowRate = WaterFlowRate;
        }
        public string GetMade()
        {
            return Made;
        }
        public string GetShape()
        {
            return shape;
        }
        public float GetDiameter()
        {
            return Diameter;
        }
        public float GetWaterFlowRate()
        {
            return WaterFlowRate;
        }
    }
}