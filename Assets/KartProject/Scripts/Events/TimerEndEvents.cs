using UnityEngine;
using UnityEngine.Events;
using System;

public class TimerEndEvents : MonoBehaviour
{
    [Header( "Class Instances" )]
    [SerializeField] protected SimpleTimerUpdate systemTime;

    [Header( "Timer End Events" )]
    [SerializeField] protected UnityTimerEndEvents OnTimerEndEvent = new UnityTimerEndEvents();

    protected virtual void OnEnable()
    {
        systemTime.OnTimerEnd += OnTimerEndEvent.Invoke;
    }

    protected virtual void OnDisable()
    {
        systemTime.OnTimerEnd -= OnTimerEndEvent.Invoke;
    }

}

[Serializable]
public class UnityTimerEndEvents : UnityEvent
{
}
