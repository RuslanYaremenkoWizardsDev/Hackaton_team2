using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TornamentManager
{
    public class TournamentsListClass : ITournamentsList
    {
        private IList<ITournament> _tournaments = new List<ITournament>();

        void ITournamentsList.AddTournament(ITournament tournament)
        {
            _tournaments.Add(tournament);
        }

        IEnumerator<ITournament> IEnumerable<ITournament>.GetEnumerator()
        {
            return _tournaments.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _tournaments.GetEnumerator();
        }

        ITournament ITournamentsList.GetTournamentByID(int ID)
        {
            foreach (var item in _tournaments)
            {
                if (item.ID == ID)
                {
                    return item;
                }
            }
            return null;
        }

        void ITournamentsList.RemoveTournamentByID(int ID)
        {
            foreach (var item in _tournaments)
            {
                if (item.ID == ID)
                {
                    _tournaments.Remove(item);
                }
            }
        }
    }
}
