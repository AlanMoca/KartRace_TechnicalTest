using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRace : MonoBehaviour
{
    public SystemTime systemTime;
    private void OnTriggerEnter( Collider other )
    {
        var car = other.gameObject.GetComponent<Car>();
        if( car )
        {
            car.racesWon++;
            if( car.bestTime >= systemTime.newTime() )
            {
                car.bestTime = systemTime.newTime();
            }
            PlayerPersistence.SaveData( car );
        }
        Debug.Log( "Carrera Terminada" );
    }
}
