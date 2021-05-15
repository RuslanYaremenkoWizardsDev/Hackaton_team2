using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TornamentManager
{
    class TeamClass : ITeamClass

    {
        private string _name;
        string ITeamClass.Name 
        { 
            get => _name;
            set
            {
                _name = value;
            }

        }

        public TeamClass(string name)
        {
            _name = name;
        }
        }
    }
}
