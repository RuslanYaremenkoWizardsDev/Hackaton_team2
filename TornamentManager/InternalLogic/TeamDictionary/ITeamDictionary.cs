using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TornamentManager
{
    public interface ITeamDictionary:IEnumerable<ITeamClass>
    {
        void LoadFromFile(StreamReader streamReader);

        void SaveToFile(StreamWriter streamWriter);
        void AddTeam(ITeamClass team);
        void RemoveByID(int ID);
        ITeamClass GetTeamByID(int ID);
        void TriggerListChangeEvent();
        public delegate void ITeamEvent(ITeamClass team);
        public delegate void VoidEvent();
        public event ITeamEvent TeamAdded;
        public event VoidEvent TTeamRemoved;
        public event VoidEvent TeamListChanged;
    }
}
