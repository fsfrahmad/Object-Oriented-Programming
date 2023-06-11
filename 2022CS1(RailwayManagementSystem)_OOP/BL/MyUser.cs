using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022CS1_RailwayManagementSystem__OOP.BL
{
    public class MyUser
    {
        private string name;
        private string password;
        private string role;
        private int loan;
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
        public MyUser(string name, string password, string role, int loan)
        {
            this.name = name;
            this.password = password;
            this.role = role;
            this.loan = loan;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetPassword(string password)
        {
            this.password = password;
        }
        public void SetRole(string role)
        {
            this.role = role;
        }
        public void SetLoan(int loan)
        {
            this.loan = loan; 
        }
        public string GetName()
        {
            return name;
        }
        public string GetPassword()
        {
            return password;
        }
        public string GetRole()
        {
            return role;
        }
        public int GetLoan()
        {
            return loan;
        }

    }
}
