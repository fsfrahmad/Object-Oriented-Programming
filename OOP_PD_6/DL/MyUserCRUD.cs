using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_PD_6.BL;

namespace OOP_PD_6.DL
{
    public class MyUserCRUD
    {
        static List<MyUser> UsersList = new List<MyUser>();
        public MyUser UserExists(MyUser NewUser)
        {
            for (int i = 0; i < UsersList.Count; i++)
            {
                if ((NewUser.name == UsersList[i].name) && (NewUser.password == UsersList[i].password))
                {
                    return UsersList[i];
                }
            }
            return null;
        }

    }
}
