using KartRace.Application;

namespace KartRace.Players.Domain.UseCase
{
    public class PlayerDataSaverPlayerPrefs : Entity.IPlayerDataSaver
    {
        public void SavePlayerData( Entity.PlayerData playerData )
        {
            var dataSaver = ServiceLocator.Instance.GetService<IDataSaverPlayerPref>();
        }

        public Entity.PlayerData LoadPlayerData()
        {
            var dataSrver = ServiceLocator.Instance.GetService<IDataSaverPlayerPref>();

            var _numberOfRaces = dataSrver.GetInt( "NumberOfRaces" );
            var _racesWon = dataSrver.GetInt( "RacesWon" );
            var _bestTime = dataSrver.GetFloat( "BestTime" );

            Entity.PlayerData playerData = new Entity.PlayerData() {
            };

            return playerData;
        }

    }
}