using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TornamentManager.AutorizationLogic
{
    public interface IActiveUser : IUser
    {
        public DateTime LoginTimeDate { get; }
    }
}
