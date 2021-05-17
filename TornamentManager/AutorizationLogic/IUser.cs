namespace TornamentManager.AutorizationLogic
{
    public interface IUser
    {
        public string Login { get; set; }
        public string Password { get; set; }

        EUserPrivileges UserPrivilages { get; set; }
    }
}
