using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TornamentManager
{
    public class TeamList : ITeamList

    {
        private IList<ITeamClass> _teamList;
        public void AddTeam(ITeamClass team)
        {
            _teamList.Add(team);
        }

        public IEnumerator<ITeamClass> GetEnumerator()
        {
            return _teamList.GetEnumerator();
        }

        public bool IsteamInvated(ITeamClass team)
        {
           return _teamList.Contains(team);
        }

        public void RemoveTeam(ITeamClass team)
        {
            _teamList.Remove(team);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _teamList.GetEnumerator();
        }
    }
}
