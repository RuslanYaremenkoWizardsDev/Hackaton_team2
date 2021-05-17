using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TornamentManager
{
    public class TeamDictionary : ITeamDictionary
    {
        private IList<ITeamClass> _teamList;

        public event ITeamDictionary.ITeamEvent TeamAdded;
        public event ITeamDictionary.VoidEvent TTeamRemoved;
        public event ITeamDictionary.VoidEvent TeamListChanged;

        public void AddTeam(ITeamClass team)
        {
            _teamList.Add(team);
            TeamListChanged?.Invoke();
            TeamAdded?.Invoke(team);
        }

        public IEnumerator<ITeamClass> GetEnumerator()
        {
            return _teamList.GetEnumerator();
        }

        public ITeamClass GetTeamByID(int ID)
        {
            foreach (var e in _teamList)
            {
                if (e.ID == ID)
                {
                    return e;
                }
            }
            return null;
        }

        public void RemoveByID(int ID)
        {
            foreach (var e in _teamList)
            {
                if (e.ID == ID)
                {
                    _teamList.Remove(e);
                    TTeamRemoved?.Invoke();
                    TeamListChanged?.Invoke();
                    break;
                }
            }
        }

        public void TriggerListChangeEvent()
        {
            TeamListChanged?.Invoke();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _teamList.GetEnumerator();
        }

        void ITeamDictionary.LoadFromFile(StreamReader streamReader)
        {
            throw new NotImplementedException();
        }

        void ITeamDictionary.SaveToFile(StreamWriter streamWriter)
        {
            throw new NotImplementedException();
        }

        public TeamDictionary()
        {
            _teamList = new List<ITeamClass>();

        }
    }
}
