using System.Collections.Generic;

namespace TornamentManager
{
   public interface ITournamentsList:IEnumerable<ITournament>
    {
        delegate void ITournamentEvent(ITournament tournament);
        delegate void VoidEvent();

        event ITournamentEvent TournamentAdded;
        event VoidEvent TournamentRemoved;
        event VoidEvent TournamentListChanged;

        void AddTournament(ITournament tournament);
        void RemoveTournamentByID(int ID);
        ITournament GetTournamentByID(int ID);
        void TriggerListChangedEvent();
    }
}
