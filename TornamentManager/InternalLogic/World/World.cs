using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

        public void Button_Remove_Click(object sender, RoutedEventArgs e)
        {
            TournamentsList.RemoveTournamentByID(1);
        }
    }
}
