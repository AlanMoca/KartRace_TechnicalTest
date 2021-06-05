using KartRace.Application;
using KartRace.Matchs.Domain.Entity;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;

namespace KartRace.Matchs.Domain.UseCase
{
    public class MatchDataSaverPlayfab : IMatchDataSaver
    {
        private MatchData matchData;

        public MatchDataSaverPlayfab()
        {
            matchData = new MatchData();
        }

        public MatchData LoadMatchData()
        {
            var dataParser = ServiceLocator.Instance.GetService<IParser>();

            PlayFabClientAPI.GetUserData(
                new GetUserDataRequest(), OnMatchDataRecieved, OnError );

            return matchData;
        }

        public void SaveMatchData( MatchData matchData )
        {
            var dataParser = ServiceLocator.Instance.GetService<IParser>();
            var request = new UpdateUserDataRequest {
                Data = new Dictionary<string, string> {
                    {"matchData", dataParser.Serialize<MatchData>(matchData) }
                }
            };
            PlayFabClientAPI.UpdateUserData( request, OnDataSend, OnError );
        }

        private void OnMatchDataRecieved( GetUserDataResult result )
        {
            var dataParser = ServiceLocator.Instance.GetService<IParser>();

            if( result.Data != null && result.Data.ContainsKey( "matchData" ) )
            {
                matchData = dataParser.Deserialize<MatchData>( result.Data["matchData"].Value );
                UnityEngine.Debug.Log( "Data Received" );
            }
        }

        private void OnDataSend( UpdateUserDataResult result )
        {
            UnityEngine.Debug.Log( "Data Sended" );
        }

        private void OnError( PlayFabError error )
        {
            var messageService = ServiceLocator.Instance.GetService<Views.Domain.Entity.IMessage>();
            messageService.MessageToShow( error.ErrorMessage );
            UnityEngine.Debug.Log( error.GenerateErrorReport() );
        }
    }
}