using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TornamentManager
{
   public class ParticipantsDictionary : IParticipantsDictionary
    {
        private IList<IParticipantClass> _participantList;

        public event IParticipantsDictionary.IParticipantEvent ParticipantAdded;
        public event IParticipantsDictionary.VoidEvent ParticipantRemoved;
        public event IParticipantsDictionary.VoidEvent ParticipantListChanged;

        public ParticipantsDictionary()
        {
            _participantList = new List<IParticipantClass>();

        }

        public void AddParticipant(IParticipantClass participant)
        {
            _participantList.Add(participant);
            ParticipantListChanged?.Invoke();
            ParticipantAdded?.Invoke(participant);
        }

        public IParticipantClass GetParticipantByID(int ID)
        {
            foreach (var e in _participantList)
            {
                if (e.ID==ID)
                {
                    return e;
                }

            }
            return null;

        }

        public void RemoveParticipantByID(int ID)
        {
            foreach (var e in _participantList)
            {
                if (e.ID==ID)
                {
                    _participantList.Remove(e);
                    ParticipantRemoved?.Invoke();
                    ParticipantListChanged?.Invoke();
                    break;
                }
            }
        }

        public void TriggerListChangedEvent()
        {
            ParticipantListChanged?.Invoke();
        }

        //IList<ITeamClass> IParticipantsDictionary.TeamList => _teamList;

        void IParticipantsDictionary.LoadFromFile(StreamReader streamReader)
        {
            throw new NotImplementedException();
        }

        void IParticipantsDictionary.SaveToFile(StreamWriter streamWriter)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IParticipantClass> GetEnumerator()
        {
            return _participantList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _participantList.GetEnumerator();
        }
    }
}
