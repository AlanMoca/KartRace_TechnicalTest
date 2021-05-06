using UnityEngine;
using UnityEngine.Events;
using System;

namespace KartRace.CheckPoints.Domain.Event
{
    public class CheckPointEndRaceEvent : MonoBehaviour
    {
        [Header( "Class Instances" )]
        [SerializeField] protected UseCase.CheckPointEndRace checkPointEndRace;

        [Header( "Timer End Events" )]
        [SerializeField] protected UnityEvent OnCheckPointEndRaceEvent;

        protected virtual void OnEnable()
        {
            checkPointEndRace.OnEndRace += OnCheckPointEndRaceEvent.Invoke;
        }

        protected virtual void OnDisable()
        {
            checkPointEndRace.OnEndRace -= OnCheckPointEndRaceEvent.Invoke;
        }

    }
}
    