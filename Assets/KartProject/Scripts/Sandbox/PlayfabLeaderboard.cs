using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayfabLeaderboard : ILeaderboard
{
    public void SendDataToLeaderboard( int score )
    {
        var request = new UpdatePlayerStatisticsRequest {
            Statistics = new List<StatisticUpdate> {
                new StatisticUpdate {
                    StatisticName = "LapTimeScore",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics( request, OnLeaderboardUpdate, OnError );
    }

    private void OnLeaderboardUpdate( UpdatePlayerStatisticsResult result )
    {
        Debug.Log( "Successfull leaderboard sent" );
    }

    private void OnError( PlayFabError error )
    {
        Debug.Log( "Error while leaderboard connection!" );
        Debug.Log( error.GenerateErrorReport() );
    }
}
