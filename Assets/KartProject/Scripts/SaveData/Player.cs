using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private IDataSaver dataSaver;

    private int numberOfRaces;
    private int racesWon;
    private float bestTime;

    public PlayerData PlayerData { get; private set; }

    private void OnEnable()
    {
        //PlayerData = PlayerPersistence.LoadData();

        dataSaver = ServiceLocator.Instance.GetService<IDataSaver>();

        numberOfRaces = dataSaver.GetInt( "NumberOfRaces" );
    }

    private void Start()
    {
        numberOfRaces++;
    }

    private void OnDisable()
    {
        //PlayerPersistence.SaveData( this );
        //numberOfRaces++;
        dataSaver.SetInt( "NumberOfRaces", numberOfRaces );
    }

}
