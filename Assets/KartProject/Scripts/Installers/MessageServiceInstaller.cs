using UnityEngine;

namespace KartRace.Installers.CloudService
{
    public class MessageServiceInstaller : MonoBehaviour
    {
        [SerializeField] private Views.Domain.UseCase.MessageService messageService;

        private void Awake()
        {
            IGameMessageRegisterService();
        }

        public void IGameMessageRegisterService()
        {
            Application.ServiceLocator.Instance.RegisterService< Views.Domain.Entity.IMessage >( messageService );
        }
    }
}