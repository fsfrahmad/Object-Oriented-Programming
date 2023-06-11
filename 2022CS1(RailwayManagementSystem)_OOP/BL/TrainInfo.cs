using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022CS1_RailwayManagementSystem__OOP.BL
{
    public class TrainInfo
    {
        private string no;
        private string path;
        private string fare;
        private string timing;
        public TrainInfo()
        {
            no = "";
            path = "";
            fare = "";
            timing = "";
        }
        public TrainInfo(string no)
        {
            this.no = no;
        }
        public TrainInfo(string no, string path, string fare, string timing)
        {
            this.no = no;
            this.path = path;
            this.fare = fare;
            this.timing = timing;
        }
        public void SetNo(string no)
        {
            this.no = no;
        }
        public void SetPath(string path)
        {
            this.path = path;
        }
        public void SetFare(string fare)
        {
            this.fare = fare;
        }
        public void SetTiming(string timing)
        {
            this.timing = timing;
        }
        public string GetNo()
        {
            return no;
        }
        public string GetPath()
        {
            return path;
        }public string GetFare()
        {
            return fare;
        }public string GetTiming()
        {
            return timing;
        }

    }
}
