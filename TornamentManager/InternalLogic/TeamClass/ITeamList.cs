using System.Collections.Generic;

namespace TornamentManager
{
   public interface ITeamList:IEnumerable<ITeamClass>
    {
        public void AddTeam(ITeamClass team);
        public void RemoveTeam(ITeamClass team);
        public bool IsteamInvated(ITeamClass team);
    }
}
