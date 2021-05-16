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
            usersList.Clear();
            int usersNumber;
            usersNumber = Convert.ToInt32(streamReader.ReadLine());
            for (int i=1; i<=usersNumber; i++)
            {
                string userLogin = streamReader.ReadLine();
                string userPassword = streamReader.ReadLine();
                EUserPrivileges userPrivilages = (EUserPrivileges)Convert.ToInt32(streamReader.ReadLine());
                
            }
        }

        public void SaveUsers(StreamWriter streamWriter)
        {
            streamWriter.WriteLine(usersList.Count.ToString());
            foreach(IUser u in usersList)
            {
                streamWriter.WriteLine(u.Login);
                streamWriter.WriteLine(u.Password);
                streamWriter.WriteLine(u.UserPrivilages.ToString());
            }
            streamWriter.Close();
        }
    }
}
