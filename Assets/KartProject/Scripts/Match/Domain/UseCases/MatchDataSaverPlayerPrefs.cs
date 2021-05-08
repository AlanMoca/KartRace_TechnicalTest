using KartRace.Application;

namespace KartRace.Matchs.Domain.UseCase
{
    public class MatchDataSaverPlayerPrefs : Entity.IMatchDataSaver
    {
        public void SaveMatchData( Entity.MatchData playerData )
        {
            var dataSaver = Application.ServiceLocator.Instance.GetService<IDataSaverPlayerPref>();

            dataSaver.SetInt( "NumberOfRaces", playerData.numberOfRaces );
            dataSaver.SetInt( "RacesWon", playerData.racesWon );
            dataSaver.SetFloat( "BestTime", playerData.bestTime );
        }

        public Entity.MatchData LoadMatchData()
        {
            var dataSrver = Application.ServiceLocator.Instance.GetService<IDataSaverPlayerPref>();

            var _numberOfRaces = dataSrver.GetInt( "NumberOfRaces" );
            var _racesWon = dataSrver.GetInt( "RacesWon" );
            var _bestTime = dataSrver.GetFloat( "BestTime" );

            Entity.MatchData matchData = new Entity.MatchData() {
                numberOfRaces = _numberOfRaces,
                racesWon = _racesWon,
                bestTime = _bestTime
            };

            return matchData;
        }

        public void SaveBestTime( float newBestTime )
        {
            var dataSaver = Application.ServiceLocator.Instance.GetService<IDataSaverPlayerPref>();
            dataSaver.SetFloat( "BestTime", newBestTime );
        }

    }
}
    
