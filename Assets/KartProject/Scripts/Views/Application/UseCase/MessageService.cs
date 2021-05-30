using UnityEngine;
using UnityEngine.UI;

namespace KartRace.Views.Domain.UseCase
{
    public class MessageService : MonoBehaviour, Entity.IMessage
    {
        [SerializeField] private GameObject gameMessageBox;
        [SerializeField] private Text messageText;
        [SerializeField] private Button closeButton;

        private void Start()
        {
            closeButton.onClick.AddListener( () => CloseButton() );
        }

        public void MessageToShow( string message )
        {
            gameMessageBox.SetActive( true );
            messageText.text = message;
        }

        private void CloseButton()
        {
            gameMessageBox.SetActive( false );
            messageText.text = "";
        }
    }
}

