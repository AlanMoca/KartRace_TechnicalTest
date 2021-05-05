using KartRace.Players.Domain.Entity;

namespace KartRace.Players.Domain.Data
{
    public interface IPlayerDataSaver
    {
        public void SavePlayerData( PlayerData playerData );
        public PlayerData LoadPlayerData();
    }
}