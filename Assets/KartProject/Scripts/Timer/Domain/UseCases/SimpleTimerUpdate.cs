using UnityEngine;

namespace KartRace.Timers.Domain.UseCase
{
    public class SimpleTimerUpdate : MonoBehaviour
    {
        [Header( "Timer Elements" )]

        [SerializeField] private float initialTime;
        [SerializeField] private float timeToAddFromCurrentTime;
        [SerializeField] private float timeToRemoveFromCurrentTime;
        [SerializeField] private bool countOnStart = false;

        private float currentTime;
        private float timeToEnd = 0;
        private bool timeStopped = true;

        public event System.Action OnTimerEnd;

        private void Start()
        {
            if( countOnStart )
            {
                StarTimer();
            }
        }

        private void Update()
        {
            if( timeStopped )
                return;

            currentTime -= Time.deltaTime;
            if( currentTime <= timeToEnd )
            {
                OnTimerEnd?.Invoke();
                //SpawnTimer = 60;
            }
        }

        public void StarTimer()
        {
            currentTime = initialTime;
            timeStopped = false;
        }

        public void StopTimer()
        {
            timeStopped = true;
        }

        public float GetCurrentTime()
        {
            return currentTime;
        }

        public void AddTimeToTimer()
        {
            currentTime += timeToAddFromCurrentTime;
        }

        public void RemoveTimeToTimer()
        {
            currentTime += timeToRemoveFromCurrentTime;
        }

    }
}

