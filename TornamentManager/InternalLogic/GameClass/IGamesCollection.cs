using System.Collections.Generic;

namespace TornamentManager
{
    public interface IGamesCollection: IEnumerable<IGameClass>
    {
        void AddGame(IGameClass game);

        void RemoveGameByID(int ID);

        IGameClass GetGameByID(int ID);
    }
}
