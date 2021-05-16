using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TornamentManager
{
    public class World : IWorld
    {
        static World _instance;
        public TeamDictionary TeamList { get; private set; }
        public ITournamentsList TournamentsList { get; private set; }

        TeamDictionary IWorld.TeamDictionary
        {
            get => TeamList;
        }

        public static IWorld WorldInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new World();
                }
                return _instance;
            }
        }
        private World()
        {
            TournamentsList = new TournamentsListClass();
            TeamList = new TeamDictionary();
        }
    }
}
