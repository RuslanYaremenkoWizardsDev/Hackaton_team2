using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TornamentManager
{
    class TeamDictionary : ITeamDictionary
    {
        private IList<ITeamClass> _teamList;
        IList<ITeamClass> ITeamDictionary.TeamList => _teamList;

        void ITeamDictionary.LoadFromFile(StreamReader streamReader)
        {
            throw new NotImplementedException();
        }

        void ITeamDictionary.SaveToFile(StreamWriter streamWriter)
        {
            throw new NotImplementedException();
        }
    }
}
