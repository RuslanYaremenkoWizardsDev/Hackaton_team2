namespace TornamentManager
{
    class GameClass : IGameClass
    {
        private static int _lastID = 0;

        public GameClass(ITournament tournament)
        {
            Tournament = tournament;
            _lastID++;
            ID = _lastID;
        }
        public ITeamClass Team1 { get ; set ; }
        public ITeamClass Team2 { get ; set ; }

        public ITournament Tournament { get; private set; }

        public EGameState GameState { get ; set ; }
        public EGameResult GameResult { get ; set ; }

        public int ID { get; private set; }
    }
}
