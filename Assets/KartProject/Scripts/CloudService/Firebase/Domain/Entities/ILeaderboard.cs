namespace KartRace.CloudService.Domain.Entity
{
    public interface ILeaderboard
    {
        void SendDataToLeaderboard( int score );
    }
}
    