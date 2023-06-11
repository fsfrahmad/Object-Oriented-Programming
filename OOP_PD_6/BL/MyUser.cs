using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_PD_6.BL
{
    public class MyUser
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

    }
}
