using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TornamentManager
{
    public class TournamentsListClass : ITournamentsList
    {
        private IList<ITournament> _tournaments;
        public TournamentsListClass()
        {
            _tournaments = new List<ITournament>();
        }

        public event ITournamentsList.ITournamentEvent TournamentAdded;
        public event ITournamentsList.VoidEvent TournamentRemoved;
        public event ITournamentsList.VoidEvent TournamentListChanged;

        void ITournamentsList.AddTournament(ITournament tournament)
        {
            if (tournament!=null)
            {
                _tournaments.Add(tournament);
                TournamentAdded?.Invoke(tournament);
                TournamentListChanged?.Invoke();
            }
            
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
                    TournamentRemoved?.Invoke();
                    TournamentListChanged?.Invoke();
                    break;
                }
            }
        }
    }
}
