using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TornamentManager
{
    public interface IParticipantClass
    {
        string Name { get; set; }
        int ID { get; }
    }
}
