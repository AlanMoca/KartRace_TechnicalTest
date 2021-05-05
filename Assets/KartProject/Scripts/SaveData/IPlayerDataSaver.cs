using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KartRace.Players//.InterfaceAdapters or Aplication/uses cases
{
    public interface IPlayerDataSaver
    {
        public void SavePlayerData( PlayerData playerData );
        public PlayerData LoadPlayerData();
    }
}

//Hay que ver como implementar esto con un serviceLocator