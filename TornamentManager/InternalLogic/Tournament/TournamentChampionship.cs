﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TornamentManager.InternalLogic.Tournament
{
    class TournamentChampionship : TournamentBase
    {
        public TournamentChampionship(string name, ETournamentModes tournamentMode, int numberOfParticipants)
            : base(name, tournamentMode, numberOfParticipants)
        {

        }
    }
}