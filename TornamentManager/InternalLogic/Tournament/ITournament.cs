using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TornamentManager
{
    interface ITournament
    {
        string Name { get; set; }
        string Description { get; set; }
        ETournamentModes TornamentMode { get; set; }
        string Place { get; set; }
        DateTime StartDateTime { get; set; }
        DateTime LastRegistrationDateTime { get; set; }

        ETournamentLevel TournamentLevel { get; set; }

        int NumberOfParticipants { get; set; }



        



    }
}
