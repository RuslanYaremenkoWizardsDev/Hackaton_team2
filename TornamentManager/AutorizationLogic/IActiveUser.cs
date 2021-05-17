using System;

namespace TornamentManager.AutorizationLogic
{
    public interface IActiveUser : IUser
    {
        public DateTime LoginTimeDate { get; }
    }
}
