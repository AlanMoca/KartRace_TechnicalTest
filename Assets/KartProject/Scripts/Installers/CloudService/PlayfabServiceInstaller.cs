using UnityEngine;

namespace KartRace.Installers.CloudService
{
    public class PlayfabServiceInstaller : MonoBehaviour, ICloudServiceInstaller
    {
        private void Awake()
        {
            ICloudServiceRegisterService();
        }

        public void ICloudServiceRegisterService()
        {
            KartRace.CloudService.Domain.Entity.ILogin login = new KartRace.CloudService.Domain.UseCase.PlayfabLogin();

            KartRace.CloudService.Domain.Entity.ILeaderboard leaderboard = new KartRace.CloudService.Domain.UseCase.PlayfabLeaderboard();

            var matchDataSaverBinaryFile = new KartRace.CloudService.Domain.UseCase.PlayfabServiceFacade( login, leaderboard );
            Application.ServiceLocator.Instance.RegisterService<KartRace.CloudService.Domain.Entity.ICloudService>( matchDataSaverBinaryFile );
        }
    }
}
