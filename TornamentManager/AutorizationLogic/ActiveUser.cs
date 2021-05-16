using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TornamentManager.AutorizationLogic
{
   public class ActiveUser: User, IActiveUser
    {
        private DateTime _loginTimeDate;

        DateTime IActiveUser.LoginTimeDate
        {
            get => _loginTimeDate;
        }
        public ActiveUser(IUser user)
        {
            base.Login = user.Login;
            base.Password = user.Password;
            base.UserPrivilages = user.UserPrivilages;
            _loginTimeDate = DateTime.Now;
        }
    }
    
}
