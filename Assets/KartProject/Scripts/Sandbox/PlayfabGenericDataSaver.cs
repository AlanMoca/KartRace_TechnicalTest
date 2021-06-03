using System;
using KartRace.Application;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;

namespace KartRace.SaveSystems.Domain.UseCase
{
    public class PlayfabGenericDataSaver : Entity.IDataSaver
    {
        public void SaveData<T>( T objectData, string fileNameOnServer ) where T : class
        {
            var dataParser = ServiceLocator.Instance.GetService<IParser>();
            var fileSystem = ServiceLocator.Instance.GetService<IFile>();

            var request = new UpdateUserDataRequest {
                Data = new Dictionary<string, string> {
                    {fileNameOnServer, dataParser.Serialize<T>(objectData) }
                }
            };
            PlayFabClientAPI.UpdateUserData( request, OnDataSend, OnError );
        }

        public T LoadData<T>( string fileNameOnServer ) where T : class
        {
            var lala = ServiceLocator.Instance.GetService<CloudService.Domain.Entity.ICloudService>();
            lala.Login( "test@test.com", "123456" );

            var dataParser = ServiceLocator.Instance.GetService<IParser>();
            var dataReceived = Activator.CreateInstance<T>();

            PlayFabClientAPI.GetUserData( 
                new GetUserDataRequest(),
                (GetUserDataResult result) => {
                    UnityEngine.Debug.Log( "Data Received" );
                    if( result.Data != null && result.Data.ContainsKey( fileNameOnServer ) )
                    {
                        dataReceived = dataParser.Deserialize<T>( result.Data[fileNameOnServer].Value );
                    }
                },
                OnError );

            return dataReceived;
        }

        private void OnDataSend( UpdateUserDataResult result )
        {
            //OnLoginSuccessEvent?.Invoke();
            var messageService = Application.ServiceLocator.Instance.GetService<Views.Domain.Entity.IMessage>();
            messageService.MessageToShow( $"Logged in!" );
        }

        private void OnError( PlayFabError error )
        {
            var messageService = ServiceLocator.Instance.GetService<Views.Domain.Entity.IMessage>();
            messageService.MessageToShow( error.ErrorMessage );
            UnityEngine.Debug.Log( error.GenerateErrorReport() );
        }
    }
}
