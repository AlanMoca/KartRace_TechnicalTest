using UnityEngine;
using UnityEngine.UI;

public class EndGameUI : MonoBehaviour
{
    [Header( "UI Elements" )]
    [SerializeField] private GameObject endGameCanvas;
    [SerializeField] private GameObject gameResultText;
    [SerializeField] private Text bestTimeText;
    [SerializeField] private Text currentTimeText;
    [SerializeField] private Button tryAgainButton;
    [SerializeField] private Button mainMenuButton;

    private GameMenuMediator mediator;
    //[SerializeField] private CanvasGroup canvasGroup;

    public void Configure( GameMenuMediator menuMediator )
    {
        mediator = menuMediator;
    }

    private void Awake()
    {
        tryAgainButton.onClick.AddListener( () => mediator.TryAgain() );
        mainMenuButton.onClick.AddListener( () => mediator.MainMenu() );
    }

    public void Show( bool won, float lastBestTime, float currentFinalTime )
    {
        endGameCanvas.SetActive( true );

        if( won )
        {
            gameResultText.GetComponent<Text>().text = "You Win!";
        }
        else
        {
            gameResultText.GetComponent<Text>().text = "You Lost!";
        }

        bestTimeText.text = $"Best Time: {lastBestTime.ToString( "F" )}";
        currentTimeText.text = $"current Time: {currentFinalTime.ToString( "F" )}";
        //CanvasGroup.DoFade(1,0.5f);
    }

    //public void Show2(bool won, float currentTime)
    //{

    //    var dataSaver = ServiceLocator.Instance.GetService<KartRace.Matchs.IMatchDataSaver>();
    //    var matchData = dataSaver.LoadMatchData();

    //    var lastBestTime = matchData.bestTime;
    //    var racesWon = matchData.racesWon;

    //    endGameCanvas.SetActive( true );

    //    if( won )
    //    {
    //        racesWon++;
    //        matchData.racesWon = racesWon;

    //        if( lastBestTime >= currentTime )
    //        {
    //            matchData.bestTime = lastBestTime;
    //        }
    //        else
    //        {
    //            matchData.bestTime = currentTime;
    //        }

    //        dataSaver.SaveMatchData( matchData );
    //        gameResultText.GetComponent<Text>().text = "You Win!";
    //    }
    //    else
    //    {
    //        gameResultText.GetComponent<Text>().text = "You Lost!";
    //    }

    //    bestTimeText.text = $"Best Time: {lastBestTime.ToString( "F" )}";
    //    currentTimeText.text = $"current Time: {currentTime.ToString( "F" )}";
    //    //CanvasGroup.DoFade(1,0.5f);
    //}

    //public void Show1( bool won, float currentTime )
    //{
    //    endGameCanvas.SetActive( true );

    //    if( won )
    //    {
    //        gameResultText.GetComponent<Text>().text = "You Win!";
    //    }
    //    else
    //    {
    //        gameResultText.GetComponent<Text>().text = "You Lost!";
    //    }

    //    var dataSaver = ServiceLocator.Instance.GetService<IDataSaver>();
    //    var lastBestTime = dataSaver.GetFloat( "BestTime" );

    //    bestTimeText.text = $"Best Time: {lastBestTime.ToString( "F" )}";
    //    currentTimeText.text = $"current Time: {currentTime.ToString( "F" )}";
    //    //CanvasGroup.DoFade(1,0.5f);
    //}

    public void Hide()
    {
        endGameCanvas.SetActive( false );
        //CanvasGroup.DoFade(0,0.5f);
    }
}
