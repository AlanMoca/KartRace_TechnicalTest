using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KartRace.Matchs//.InterfaceAdapters or Aplication/uses cases
{
    public interface IMatchDataSaver
    {
        public void SaveMatchData( MatchData matchData );
        public MatchData LoadMatchData();
    }
}
