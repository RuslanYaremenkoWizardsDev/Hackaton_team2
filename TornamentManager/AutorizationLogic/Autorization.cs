using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TornamentManager.AutorizationLogic
{
    class Autorization : IAutorization
    {
        private List<IUser> usersList = new List<IUser>();
        public IActiveUser AutorizeUser(string login, string password)
        {
            throw new NotImplementedException();
        }

        public bool ChangeUserPassword(string login, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public IUser CreateUser(string login, string password, EUserPrivileges userPrivilages)
        {
            bool uniqueUser = true;
            foreach (IUser u in usersList)
            {
                if (u.Login==login)
                {
                    uniqueUser = false;
                    break;
                }

            }
            if (uniqueUser)
            {
                IUser tmpUser = new User(login, password, userPrivilages);
                usersList.Add(tmpUser);
                return tmpUser;
            }
            else
            {
                return null;
            }
        }

        public void LoadUsers(StreamReader streamReader)
        {
            throw new NotImplementedException();
        }

        public void SaveUsers(StreamWriter streamWriter)
        {
            throw new NotImplementedException();
        }
    }
}
