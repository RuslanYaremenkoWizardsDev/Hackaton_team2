using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TornamentManager
{
    public interface IWorld
    {
        public static IWorld WorldInstance { get; }
        public ITournamentsList TournamentsList { get; }
        

        public TeamDictionary TeamDictionary { get; }
    }
}
