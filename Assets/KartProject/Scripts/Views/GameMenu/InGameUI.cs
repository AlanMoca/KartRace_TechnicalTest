using UnityEngine;
using UnityEngine.UI;

namespace KartRace.Views.GameMenu
{
    public class InGameUI : MonoBehaviour
    {
        [Header( "Class Instances" )]
        [SerializeField] private SimpleTimerUpdate systemTime;

        [Header( "UI Elements" )]
        [SerializeField] private GameObject startGameCanvas;
        [SerializeField] private GameObject startTimerObject;

        private GameMenuMediator mediator;
        private Text gameTimerText;

        public void Configure( GameMenuMediator menuMediator )
        {
            mediator = menuMediator;
        }

        private void Awake()
        {
            gameTimerText = startTimerObject.GetComponent<Text>();
        }

        private void Update()
        {
            UpdateUI();
        }

        public void Show()
        {
            startGameCanvas.SetActive( true );
        }

        public void Hide()
        {
            startGameCanvas.SetActive( false );
        }

        private void UpdateUI()
        {
            var currentTimeToShow = systemTime.GetCurrentTime();
            gameTimerText.text = currentTimeToShow.ToString( "F" );
        }
    }
}
    
