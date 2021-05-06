using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KartRace.CheckPoints.Domain.UseCase
{
    public class CheckPointTimer : MonoBehaviour
    {
        [SerializeField] private Timers.Domain.UseCase.SimpleTimerUpdate inGameTimer;
        public event System.Action OnGrabPoint;

        private void OnTriggerEnter( Collider other )
        {

            inGameTimer.AddTimeToTimer();
            OnGrabPoint?.Invoke();
            Destroy( gameObject );
        }

    }
}
