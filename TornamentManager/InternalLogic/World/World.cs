using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TornamentManager.AutorizationLogic;
using TornamentManager.Tornament;

namespace TornamentManager
{
    public class World : IWorld
    {
        static World _instance;
        public ParticipantsDictionary TeamList { get; private set; }
        public ITournamentsList TournamentsList { get; private set; }

        ParticipantsDictionary IWorld.TeamDictionary
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

        public IActiveUser ActiveUser { get ; set ; }

        private World()
        {
            TournamentsList = new TournamentsListClass();
            TeamList = new ParticipantsDictionary();
        }
    }
}
