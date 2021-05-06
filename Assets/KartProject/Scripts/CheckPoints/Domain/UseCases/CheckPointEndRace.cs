using UnityEngine;

namespace KartRace.CheckPoints.Domain.UseCase
{
    public class CheckPointEndRace : MonoBehaviour
    {
        [SerializeField] private Timers.Domain.UseCase.SimpleTimerUpdate inGameTimer;
        public event System.Action OnEndRace;

        private void OnTriggerEnter( Collider other )
        {
            OnEndRace?.Invoke();
            Debug.Log( "Carrera Terminada" );
        }
    }
}
    