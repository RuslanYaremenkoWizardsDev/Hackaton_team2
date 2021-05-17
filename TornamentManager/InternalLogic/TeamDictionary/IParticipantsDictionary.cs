using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TornamentManager
{
    public interface IParticipantsDictionary:IEnumerable<IParticipantClass>
    {
        void LoadFromFile(StreamReader streamReader);

        void SaveToFile(StreamWriter streamWriter);

        void AddParticipant(IParticipantClass participant);

        void RemoveParticipantByID(int ID);

        IParticipantClass GetParticipantByID(int ID);

        void TriggerListChangedEvent();

        public delegate void IParticipantEvent(IParticipantClass participant);
        public delegate void VoidEvent();

        public event IParticipantEvent ParticipantAdded;
        public event VoidEvent ParticipantRemoved;
       public  event VoidEvent ParticipantListChanged;





    }
}
