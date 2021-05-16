using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TornamentManager.AutorizationLogic
{
    public class User : IUser
    {
        public string Login { get ; set ; }
        public string Password { get ; set ; }
        public EUserPrivileges UserPrivilages { get ; set ; }
        public User(string login, string password, EUserPrivileges userPrivileges)
        {
            Login = login;
            Password = password;
            UserPrivilages = userPrivileges;
        }
    }
}
