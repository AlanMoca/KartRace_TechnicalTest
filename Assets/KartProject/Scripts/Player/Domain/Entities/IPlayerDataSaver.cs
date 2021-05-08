namespace KartRace.Players.Domain.Entity
{
    public interface IPlayerDataSaver
    {
        public void SavePlayerData( PlayerData playerData );
        public PlayerData LoadPlayerData();
    }
}