using System.Collections;
using System.Collections.Generic;

namespace TornamentManager
{
    public class GamesCollection : IGamesCollection
    {
        private IList<IGameClass> _gamesList;

        public GamesCollection()
        {
            _gamesList = new List<IGameClass>();
        }
        public void AddGame(IGameClass game)
        {
            _gamesList.Add(game);
        }

        public IEnumerator<IGameClass> GetEnumerator()
        {
            return _gamesList.GetEnumerator();
        }

        public IGameClass GetGameByID(int ID)
        {
            foreach (var e in _gamesList)
            {
                if (e.ID==ID)
                {
                    return e;
                }
            }
            return null;
        }

        public void RemoveGameByID(int ID)
        {
           foreach (var e in _gamesList)
            {
                if (e.ID==ID)
                {
                    _gamesList.Remove(e);
                    break;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _gamesList.GetEnumerator();
        }
    }
}
