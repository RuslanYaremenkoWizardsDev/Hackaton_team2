using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TornamentManager
{
    interface ITeamDictionary
    {
        void LoadFromFile(StreamReader streamReader);

        void SaveToFile(StreamWriter streamWriter);

        IList<ITeamClass> TeamList { get; }

    }
}
