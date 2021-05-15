using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TornamentManager
{
    public class TournamentCup: TournamentBase

    {
        public TournamentCup(string name, ETournamentModes tournamentMode, int numberOfParticipants)
            : base(name, tournamentMode, numberOfParticipants)
        {

        }
            
    }
}
