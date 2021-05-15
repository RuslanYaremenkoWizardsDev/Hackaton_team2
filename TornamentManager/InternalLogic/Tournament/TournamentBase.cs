using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TornamentManager
{
    public class TournamentBase : ITournament
    {
        
        string ITournament.Name { get; set ; }
        string ITournament.Description { get ; set ; }
        ETournamentModes ITournament.TornamentMode { get ; set ; }
        string ITournament.Place { get ; set}
        DateTime ITournament.StartDateTime { get; set ; }
        DateTime ITournament.LastRegistrationDateTime { get ; set; }
        ETournamentLevel ITournament.TournamentLevel { get ; set ; }
        int ITournament.NumberOfParticipants { get ; set ; }
        ETournamentScenarios ITournament.Scenario { get ; set ; }

        IList<ITeamClass> ITournament.Players { get; }
    }
}
