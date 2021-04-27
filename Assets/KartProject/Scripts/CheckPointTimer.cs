using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointTimer : MonoBehaviour
{

    public SystemTime systemTime;
    public AudioSource collectSound;

    private void OnTriggerEnter( Collider other )
    {
        Debug.Log( "Entre" );
        //collectSound.Play();
        systemTime.AddTime();
        Destroy( gameObject );
    }


}