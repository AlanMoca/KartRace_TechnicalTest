using UnityEngine;

public class CheckPointEndRace : MonoBehaviour
{
    [SerializeField] private SimpleTimerUpdate inGameTimer;
    public event System.Action OnEndRace;

    private void OnTriggerEnter( Collider other )
    {
        OnEndRace?.Invoke();
        Debug.Log( "Carrera Terminada" );
    }
}