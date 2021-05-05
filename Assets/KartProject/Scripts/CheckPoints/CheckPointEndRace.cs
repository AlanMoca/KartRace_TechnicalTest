using UnityEngine;

public class CheckPointEndRace : MonoBehaviour
{
    [SerializeField] private SimpleTimerUpdate inGameTimer;
    public event System.Action OnEndRace;

    private void OnTriggerEnter( Collider other )
    {
        //inGameTimer.StopTimer();
        //var currentFinalTime = inGameTimer.GetCurrentTime();

        //var dataSaver = KartRace.Players.ServiceLocator.Instance.GetService<IDataSaver>();
        //var bestTime = dataSaver.GetFloat( "BestTime" );
        //var racesWon = dataSaver.GetInt( "RacesWon" );

        ////var newRacesWon = racesWon + 1;
        //racesWon++;
        //dataSaver.SetInt( "RacesWon", racesWon );

        //if( bestTime >= currentFinalTime )
        //{
        //    dataSaver.SetFloat( "BestTime", bestTime );
        //}
        //else
        //{
        //    dataSaver.SetFloat( "BestTime", currentFinalTime );
        //}


        OnEndRace?.Invoke();
        Debug.Log( "Carrera Terminada" );
    }

    //private void OnEnable()
    //{
    //    OnEndRace += DataSave;
    //}

    //public void DataSave()
    //{
    //    var currentFinalTime = inGameTimer.GetCurrentTime();

    //    var dataSaver = ServiceLocator.Instance.GetService<IDataSaver>();
    //    var bestTime = dataSaver.GetFloat( "BestTime" );
    //    var racesWon = dataSaver.GetInt( "RacesWon" );

    //    //var newRacesWon = racesWon + 1;
    //    racesWon++;
    //    dataSaver.SetInt( "RacesWon", racesWon );

    //    if( bestTime >= currentFinalTime )
    //    {
    //        dataSaver.SetFloat( "BestTime", bestTime );
    //    }
    //    else
    //    {
    //        dataSaver.SetFloat( "BestTime", currentFinalTime );
    //    }
    //}
}