namespace KartRace.Matchs.Domain.Entity
{
    public interface IMatchDataSaver
    {
        public void SaveMatchData( MatchData matchData );
        public MatchData LoadMatchData();
    }
}
