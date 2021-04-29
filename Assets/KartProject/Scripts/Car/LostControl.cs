using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostControl : MonoBehaviour
{
    [SerializeField] private KartRace.Cars.CarController carController;
    [SerializeField] private float timeLostControl;

    private void OnCollisionEnter( Collision collision )
    {
        if( collision.gameObject.CompareTag( "Player" ) )
        {
            StartCoroutine( TemporalLostControl() );
        }

    }

    private IEnumerator TemporalLostControl()
    {
        carController.enabled = false;
        yield return new WaitForSecondsRealtime( timeLostControl );
        carController.enabled = true;
    }

}

/*
 * NOTE: This script was developed like this because the road prefab was in conjunction with the barricade, thus causing constant collision.
 * I decide to use the rocks just to demostrate their behavior. In the future, it is expected to be able to change the coroutine for an async and
 * decouple the road prefabs to include this logic within CarController.cs and then aply a strategy pattern so that each of its behaviors are 
 * abstracted into differents modules for better decoupling and compliance with the SOLID principies; in this way, the base behavior of the
 * loss of control can be changed without affecting the behavior of the car.
 */

