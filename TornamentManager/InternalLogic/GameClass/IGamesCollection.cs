using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TornamentManager
{
    public interface IGamesCollection: IEnumerable<IGameClass>
    {
        void AddGame(IGameClass game);

        void RemoveGameByID(int ID);

        IGameClass GetGameByID(int ID);


    }
}
