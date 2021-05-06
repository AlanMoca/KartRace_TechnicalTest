using UnityEngine;
using UnityEngine.Events;

namespace KartRace.Application.Event
{
    public class StartEvent : MonoBehaviour
    {

        public UnityEvent OnStarted;

        private void Start()
        {
            OnStarted.Invoke();
        }
    }
}

