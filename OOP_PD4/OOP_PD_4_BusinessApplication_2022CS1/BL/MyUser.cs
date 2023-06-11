using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_PD_4_BusinessApplication_2022CS1.BL
{
    class MyUser
    {
        public string name;
        public string password;
        public string role;
        public MyUser()
        {
            name = "";
            password = "";
            role = "";
        }
        public MyUser(string name)
        {
            this.name = name;
        }
        public MyUser(string name, string password)
        {
            this.name = name;
            this.password = password;
        }
        public MyUser(string name, string password, string role)
        {
            this.name = name;
            this.password = password;
            this.role = role;
        }
        public MyUser UserExists(List<MyUser> Users)
        {
            for(int i = 0; i < Users.Count;i++)
            {
                if((name == Users[i].name) && (password == Users[i].password))
                {
                    return Users[i];
                }
            }
            return null;
        }
        public string CheckRole()
        {
            return role;
        }
        
    }
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
        public TrainInfo TrainExists(List<TrainInfo> Trains)
        {
            for(int i = 0; i < Trains.Count; i++)
            {
                if(no == Trains[i].no)
                {
                    return Trains[i];
                }
            }
            return null;
        }

    }

}
