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
        private IList<ITournament> _tournaments;
        private TeamDictionary _teamDictionary;
        private World()
        {

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

        IList<ITournament> IWorld.Tournaments
        {
            get => _tournaments;
        }

        TeamDictionary IWorld.TeamDictionary
        {
            get => _teamDictionary;
        }
    }

}
