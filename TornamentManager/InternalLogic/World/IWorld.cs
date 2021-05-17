using TornamentManager.AutorizationLogic;

namespace TornamentManager
{
    public interface IWorld
    {
        public static IWorld WorldInstance { get; }

        public ITournamentsList TournamentsList { get; }

        public TeamDictionary TeamDictionary { get; }

        public IActiveUser ActiveUser { get; set; }
    }
}
