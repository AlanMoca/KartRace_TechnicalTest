using KartRace.Matchs.Domain.Entity;

namespace KartRace.Matchs.Domain.Data
{
    public interface IMatchDataSaver
    {
        public void SaveMatchData( MatchData matchData );
        public MatchData LoadMatchData();
    }
}
