using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointTimer : MonoBehaviour
{
    [SerializeField] private SimpleTimerUpdate inGameTimer;
    public event System.Action OnGrabPoint;

    private void OnTriggerEnter( Collider other )
    {

        inGameTimer.AddTimeToTimer();
        OnGrabPoint?.Invoke();
        Destroy( gameObject );

        //var car = other.gameObject.GetComponent<Car>();
        //if( car )
        //{
        //    Debug.Log( "Entre" );
        //    inGameTimer.AddTimeToTimer();
        //    OnGrabPoint?.Invoke();
        //    Destroy( gameObject );
        //}
            
    }

}