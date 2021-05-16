using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TornamentManager
{
    public abstract class TournamentBase : ITournament
    {
        private string _name;
        private string _description;
        private int _numberOfParticipants;
        private ETournamentModes _tournamentMode;
        private static int lastID=0;
        public int ID {get; private set;}

        string ITournament.Name
        {
            get => _name;

            set
            {
                if (value.Length > 255)
                {
                    throw new ArgumentException("Tournament name is too long (255 characters max)");
                }
                else
                {
                    _name = value;
                }
            }
        }

        string ITournament.Description
        {
            get => _description;
            set
            {
                if (value.Length > 10000)
                {
                    throw new ArgumentException("Tournament description is too long (10000 characters max)");
                }
                else
                {
                    _description = value;
                }
            }
        }

        ETournamentModes ITournament.TournamentMode
        {
            get => _tournamentMode;

            set
            {
                _tournamentMode = value;
            }
        }

        string ITournament.Place { get; set; }
        DateTime ITournament.StartDateTime { get; set; }
        DateTime ITournament.LastRegistrationDateTime { get; set; }
        ETournamentLevel ITournament.TournamentLevel { get; set; }
        int ITournament.NumberOfParticipants { get; set; }
        ETournamentScenarios ITournament.Scenario { get; set; }
        IList<ITeamClass> ITournament.Players { get; }

        IList<IGameClass> ITournament.Games
        {
            get;
        }
        bool ITournament.Canceled { get ; set ; }

        public TournamentBase(string name, ETournamentModes tournamentMode, int numberOfParticipants)
        {
            lastID++;
            ID = lastID;
            _name = name;
            _tournamentMode = tournamentMode;

            if (tournamentMode == ETournamentModes.Championship)
            {
                if (numberOfParticipants > 10)
                {
                    throw new ArgumentException("For Championship max number of players is 10");
                }
                else
                {
                    _numberOfParticipants = numberOfParticipants;
                }
            }

            if (tournamentMode == ETournamentModes.Cup)
            {
                if (numberOfParticipants == 4 || numberOfParticipants == 8 || numberOfParticipants == 16 ||
                    numberOfParticipants == 32 || numberOfParticipants == 64 || numberOfParticipants == 128)
                {
                    _numberOfParticipants = numberOfParticipants;
                }
                else
                {
                    throw new ArgumentException("For Cup number of participants allowed only next options: 4, 8, 16, 32, 64");
                }
            }
        }
    }
}
