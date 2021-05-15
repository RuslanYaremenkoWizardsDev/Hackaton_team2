using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TornamentManager.AutorizationLogic
{
    public interface IAutorization
    {
        void LoadUsers(StreamReader streamReader);
        IActiveUser AutorizeUser(string login, string password);

    }
}
