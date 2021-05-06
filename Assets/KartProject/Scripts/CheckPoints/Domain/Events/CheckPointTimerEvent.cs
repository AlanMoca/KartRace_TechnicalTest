using UnityEngine;
using UnityEngine.Events;
using System;

namespace KartRace.CheckPoints.Domain.Event
{
    public class CheckPointTimerEvent : MonoBehaviour
    {
        [Header( "Class Instances" )]
        [SerializeField] protected UseCase.CheckPointTimer checkPointTimer;

        [Header( "Timer End Events" )]
        [SerializeField] protected UnityEvent OnCheckPointTimerEvent;

        protected virtual void OnEnable()
        {
            checkPointTimer.OnGrabPoint += OnCheckPointTimerEvent.Invoke;
        }

        protected virtual void OnDisable()
        {
            checkPointTimer.OnGrabPoint -= OnCheckPointTimerEvent.Invoke;
        }

    }
}
