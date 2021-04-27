using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SystemTime : MonoBehaviour
{
    [SerializeField] float currentTime = 60f;
    [SerializeField] Text timeText;

    private float timeToEnd = 0;

    public UnityEvent OnTimerEnd = new UnityEvent();

    public void AddTime()
    {
        currentTime += 4f;
    }

    public float newTime()
    {
        float finishTime = currentTime;
        return finishTime;
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;
        timeText.text = "Score: " + currentTime.ToString("F");
        if( currentTime <= timeToEnd )
        {
            OnTimerEnd?.Invoke();
            //SpawnTimer = 60;
        }
    }
}
