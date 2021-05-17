using System.Collections.Generic;
using System.IO;

namespace TornamentManager
{
    public interface ITeamDictionary : IEnumerable<ITeamClass>
    {
        public delegate void ITeamEvent(ITeamClass team);
        public delegate void VoidEvent();
        public event ITeamEvent TeamAdded;
        public event VoidEvent TTeamRemoved;
        public event VoidEvent TeamListChanged;

        void LoadFromFile(StreamReader streamReader);

        void SaveToFile(StreamWriter streamWriter);

        void AddTeam(ITeamClass team);

        void RemoveByID(int ID);

        ITeamClass GetTeamByID(int ID);

        void TriggerListChangeEvent();
    }
}
