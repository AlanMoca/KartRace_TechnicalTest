using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public PlayerData PlayerData { get; private set; }

    public int numberOfRaces;
    public int racesWon;
    public float bestTime;

    private void OnEnable()
    {
        PlayerData = PlayerPersistence.LoadData();

        numberOfRaces = PlayerData.numberOfRaces;
        racesWon = PlayerData.racesWon;
        bestTime = PlayerData.bestTime;
    }

    private void Start()
    {
        numberOfRaces++;
    }

    private void OnDisable()
    {
        PlayerPersistence.SaveData( this );
    }

    private void Update()
    {
        
    }

    private void UpdateUIElements()
    {

    }

}

public static class PlayerPersistence
{
    public static void SaveData( Car player )
    {
        PlayerPrefs.SetInt( "numberOfRaces", player.PlayerData.numberOfRaces );
        PlayerPrefs.SetInt( "racesWon", player.PlayerData.racesWon );
        PlayerPrefs.SetFloat( "bestTime", player.PlayerData.bestTime );
    }

    public static PlayerData LoadData()
    {
        int _numberOfRaces = PlayerPrefs.GetInt( "numberOfRaces");
        int _racesWon = PlayerPrefs.GetInt( "racesWon" );
        float _bestTime = PlayerPrefs.GetFloat( "bestTime" );

        PlayerData playerData = new PlayerData() {
            numberOfRaces = _numberOfRaces,
            racesWon = _racesWon,
            bestTime = _bestTime
        };

        return playerData;

    }

}
