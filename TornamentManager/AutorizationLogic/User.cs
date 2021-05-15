using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TornamentManager.AutorizationLogic
{
    public class User : IUser
    {
        string IUser.Login { get ; set ; }
        string IUser.Password { get ; set ; }
        EUserPrivileges IUser.UserPrivilages { get ; set ; }
    }
}
