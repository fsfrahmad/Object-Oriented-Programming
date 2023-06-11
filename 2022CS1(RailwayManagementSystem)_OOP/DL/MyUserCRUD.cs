using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using _2022CS1_RailwayManagementSystem__OOP.BL;

namespace _2022CS1_RailwayManagementSystem__OOP.DL
{
    public class MyUserCRUD
    {
        private static List<MyUser> UsersList = new List<MyUser>();

        public static void AddToUserList(MyUser NewUser)
        {
            UsersList.Add(NewUser);
        }
        public List<MyUser> GetList()
        {
            return UsersList;
        }
        public static void LoadData(string path)
        {
            string record;
            StreamReader file = new StreamReader(path);
            while ((record = file.ReadLine()) != null)
            {
                string[] Data = record.Split(',');
                string name = Data[0];
                string password = Data[1];
                string role = Data[2];
                int loan = int.Parse(Data[3]);
                MyUser item = new MyUser(name, password, role, loan);
                UsersList.Add(item);
            }
            file.Close();
        }
        public static void storeDataInFile(string path, MyUser user)
        {
            StreamWriter file = new StreamWriter("E:\\OOPs\\Lab01\\OOP PD 1\\records.txt", true);
            file.WriteLine(user.GetName() + "," + user.GetPassword() + "," + user.GetRole() + "," + user.GetLoan());
            file.Flush();
            file.Close();
        }
        public static MyUser UserExists(MyUser NewUser)
        {

            for (int i = 0; i < UsersList.Count; i++)
            {
                if ((NewUser.GetName() == UsersList[i].GetName()) && (NewUser.GetPassword() == UsersList[i].GetPassword()))
                {
                    return UsersList[i];
                }
            }
            return null;
        }
        
    }
}
