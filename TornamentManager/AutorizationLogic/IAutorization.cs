using System.IO;

namespace TornamentManager.AutorizationLogic
{
    public interface IAutorization
    {
        void LoadUsers(StreamReader streamReader);
        void SaveUsers(StreamWriter streamWriter);

        IActiveUser AutorizeUser(string login, string password);
        IUser CreateUser(string login, string password, EUserPrivileges userPrivilages);

        bool ChangeUserPassword(string login, string oldPassword, string newPassword);

        public bool validateLogin(string login);
        public bool validatePassword(string password);
    }
}
