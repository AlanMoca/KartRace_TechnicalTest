using UnityEngine;
using UnityEngine.UI;

namespace KartRace.Views.GameMenu
{
    public class StartGameUI : MonoBehaviour
    {
        [Header( "Class Instances" )]
        [SerializeField] private Timers.Domain.UseCase.SimpleTimerUpdate systemTime;

        [Header( "UI Elements" )]
        [SerializeField] private GameObject startGameCanvas;
        [SerializeField] private GameObject startTimerObject;

        private GameMenuMediator mediator;
        private Text startTimerText;

        public void Configure( GameMenuMediator menuMediator )
        {
            mediator = menuMediator;
        }

        private void Awake()
        {
            startTimerText = startTimerObject.GetComponent<Text>();
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
            startTimerText.text = currentTimeToShow.ToString( "F0" );
        }

    }
}
    
