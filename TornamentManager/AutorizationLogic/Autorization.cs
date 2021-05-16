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
            IUser tmpUser = null;
            foreach (IUser u in usersList)
            {

                if (u.Login == login)
                {
                    tmpUser = u;
                    break;
                }

            }

            if (tmpUser == null)
            {
                return null;
            }
            else
            {
                if (tmpUser.Password == password)
                {
                    return new ActiveUser(tmpUser);
                }
                else
                {
                    return null;
                }
            }
        }

        public bool ChangeUserPassword(string login, string oldPassword, string newPassword)
        {
            IUser tmpUser = null;
            foreach (IUser u in usersList)
            {
                if (u.Login == login)
                {
                    tmpUser = u;
                    break;
                }
            }
            if (tmpUser == null)
            {
                return false;
            }
            else
            {
                if (tmpUser.Password == oldPassword)
                {
                    tmpUser.Password = newPassword;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public IUser CreateUser(string login, string password, EUserPrivileges userPrivilages)
        {
            bool uniqueUser = true;
            foreach (IUser u in usersList)
            {
                if (u.Login == login)
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
