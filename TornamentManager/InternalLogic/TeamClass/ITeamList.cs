using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TornamentManager
{
   public interface ITeamList:IEnumerable<ITeamClass>
    {
        public void AddTeam(ITeamClass team);
        public void RemoveTeam(ITeamClass team);
        public bool IsteamInvated(ITeamClass team);
    }
}
