using UnityEngine;
using UnityEngine.Events;

public class StartEvent : MonoBehaviour {

    public UnityEvent OnStarted;

    private void Start()
    {
        OnStarted.Invoke();
    }
}
