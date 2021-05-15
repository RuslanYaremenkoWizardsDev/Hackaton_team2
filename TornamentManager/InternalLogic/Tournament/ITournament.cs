﻿using System;
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
        ETournamentModes TournamentMode { get; set; }
        string Place { get; set; }
        DateTime StartDateTime { get; set; }
        DateTime LastRegistrationDateTime { get; set; }

        ETournamentLevel TournamentLevel { get; set; }

        int NumberOfParticipants { get; set; }

        ETournamentScenarios Scenario { get; set; }

        IList<ITeamClass> Players { get; }

        IList<IGameClass> Games { get; }

    }
}