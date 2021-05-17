using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TornamentManager
{
    class ParticipantClass : IParticipantClass
    {
        private static int _lastID = 0;
        private string _name;
        string IParticipantClass.Name
        {
            get => _name;
            set
            {
                _name = value;
            }

        }

        public int ID { get; private set; }

        public ParticipantClass(string name)
        {
            _name = name;
            _lastID++;
            ID = _lastID;
        }
    }
}

