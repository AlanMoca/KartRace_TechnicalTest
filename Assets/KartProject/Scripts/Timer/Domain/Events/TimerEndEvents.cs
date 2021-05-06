using UnityEngine;
using UnityEngine.Events;

namespace KartRace.Timers.Domain.Event
{
    public class TimerEndEvents : MonoBehaviour
    {
        [Header( "Class Instances" )]
        [SerializeField] protected UseCase.SimpleTimerUpdate systemTime;

        [Header( "Timer End Events" )]
        [SerializeField] protected UnityEvent OnTimerEndEvent;

        protected virtual void OnEnable()
        {
            systemTime.OnTimerEnd += OnTimerEndEvent.Invoke;
        }

        protected virtual void OnDisable()
        {
            systemTime.OnTimerEnd -= OnTimerEndEvent.Invoke;
        }

    }
}
