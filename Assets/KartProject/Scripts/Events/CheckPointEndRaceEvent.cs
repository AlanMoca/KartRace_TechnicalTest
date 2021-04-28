using UnityEngine;
using UnityEngine.Events;
using System;

public class CheckPointEndRaceEvent : MonoBehaviour
{
    [Header( "Class Instances" )]
    [SerializeField] protected CheckPointEndRace checkPointEndRace;

    [Header( "Timer End Events" )]
    [SerializeField] protected UnityCheckPointEndRaceEvents OnCheckPointEndRaceEvent = new UnityCheckPointEndRaceEvents();

    protected virtual void OnEnable()
    {
        checkPointEndRace.OnEndRace += OnCheckPointEndRaceEvent.Invoke;
    }

    protected virtual void OnDisable()
    {
        checkPointEndRace.OnEndRace -= OnCheckPointEndRaceEvent.Invoke;
    }

}

[Serializable]
public class UnityCheckPointEndRaceEvents : UnityEvent
{
}
