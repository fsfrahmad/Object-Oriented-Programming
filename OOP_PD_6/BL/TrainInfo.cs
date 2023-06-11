using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_PD_6.BL
{
    public class TrainInfo
    {
        public string no;
        public string path;
        public string fair;
        public string timing;
        public TrainInfo()
        {
            no = "";
            path = "";
            fair = "";
            timing = "";
        }
        public TrainInfo(string no)
        {
            this.no = no;
        }
        public TrainInfo(string no, string path, string fair, string timing)
        {
            this.no = no;
            this.path = path;
            this.fair = fair;
            this.timing = timing;
        }
    }
}
