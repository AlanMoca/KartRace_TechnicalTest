using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KartRace.Players//.Entity
{
    public class Player : MonoBehaviour
    {
        public PlayerData PlayerData { get; private set; }

        private void OnEnable()
        {
            //PlayerData = PlayerPersistence.LoadData();
            var playerDataSaver = ServiceLocator.Instance.GetService<IPlayerDataSaver>();
            PlayerData = playerDataSaver.LoadPlayerData();
        }

        private void OnDisable()
        {
            //Guardarle los nuevos valores y pasarselo
            //PlayerPersistence.SaveData( PlayerData );
        }

        private void Update()
        {
            //UpdateCashUI();
        }

    }
}

//Consumidor


