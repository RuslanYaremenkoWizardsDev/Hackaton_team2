using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TornamentManager
{
    public interface IGameClass
    {
        public ITeamClass Team1 { get; set; }
        public ITeamClass Team2 { get; set; }

        public ITournament Tournament { get; }

        public EGameState GameState { get; set; }

        




    }
}
