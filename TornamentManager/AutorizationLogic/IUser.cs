using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TornamentManager.AutorizationLogic
{
    public interface IUser
    {
        public string Login { get; set; }
        public string Password { get; set; }

        EUserPrivileges UserPrivilages { get; set; }
    }
}
