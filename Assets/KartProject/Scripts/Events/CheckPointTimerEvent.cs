using UnityEngine;
using UnityEngine.Events;
using System;

public class CheckPointTimerEvent : MonoBehaviour
{
    [Header( "Class Instances" )]
    [SerializeField] protected CheckPointTimer checkPointTimer;

    [Header( "Timer End Events" )]
    [SerializeField] protected UnityCheckPointTimerEvents OnCheckPointTimerEvent = new UnityCheckPointTimerEvents();

    protected virtual void OnEnable()
    {
        checkPointTimer.OnGrabPoint += OnCheckPointTimerEvent.Invoke;
    }

    protected virtual void OnDisable()
    {
        checkPointTimer.OnGrabPoint -= OnCheckPointTimerEvent.Invoke;
    }

}

[Serializable]
public class UnityCheckPointTimerEvents : UnityEvent
{
}
