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
            if (validateLogin(login) && validatePassword(password))
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
            else
            {
                return null;
            }
        }

        public bool ChangeUserPassword(string login, string oldPassword, string newPassword)
        {

            if (validateLogin(login) && validatePassword(oldPassword) && validatePassword(newPassword))
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
            else
            {
                return false;
            }
        }

        public IUser CreateUser(string login, string password, EUserPrivileges userPrivilages)
        {
            if (validateLogin(login) && validatePassword(password))
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
            for (int i = 1; i <= usersNumber; i++)
            {
                string userLogin = streamReader.ReadLine();
                string userPassword = streamReader.ReadLine();
                EUserPrivileges userPrivilages = (EUserPrivileges)Convert.ToInt32(streamReader.ReadLine());
            }
        }

        public void SaveUsers(StreamWriter streamWriter)
        {
            streamWriter.WriteLine(usersList.Count.ToString());
            foreach (IUser u in usersList)
            {
                streamWriter.WriteLine(u.Login);
                streamWriter.WriteLine(u.Password);
                streamWriter.WriteLine(u.UserPrivilages.ToString());
            }
            streamWriter.Close();
        }

        public bool validateLogin(string login)
        {
            return universalValidate(login);
        }

        public bool validatePassword(string password)
        {
            return universalValidate(password);
        }

        private bool universalValidate(string str)
        {
            string[] allowedChars = new string[]
            {
                "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o",
                "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",

                "1", "2", "3", "4", "5", "6", "7", "8", "9", "0"
            };
            bool allCharsAllowed = true;
            for (int i = 0; i <= str.Length - 1; i++)
            {
                string currentChar = str.Substring(i, 1);
                if (Array.IndexOf(allowedChars, currentChar.ToLower()) == -1)
                {
                    allCharsAllowed = false;
                    break;
                }
            }
            return allCharsAllowed;
        }
    }
}
