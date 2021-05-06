using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using KartRace.Application;
using KartRace.InterfaceAdapters;

namespace KartRace.Installers
{
    public class BinaryFileInstaller : MonoBehaviour
    {
        private string filePath;
        private string filePathToRead;
        private Matchs.Domain.UseCase.MatchDataSaverBinaryFile matchDataSaverBinaryFile;

        private void Awake()
        {
            SetupMatchDataSaver();
            MatchDataSaverAsBinaryFileRegisterService();
        }

        public void SetupMatchDataSaver()
        {
            filePath = UnityEngine.Application.persistentDataPath + "/matchdata.data";

#if UNITY_EDITOR
            filePathToRead = UnityEngine.Application.persistentDataPath + "/matchdata.data";
#elif UNITY_ANDROID
            filePathToRead = "jar:file://" + Application.dataPath + "!/assets/matchdata.data";
#endif

            var formatter = new BinaryFormatter();

            if( !File.Exists( filePath ) )
            {
                var stream = new FileStream( filePath, FileMode.Create );
                Matchs.Domain.Entity.MatchData matchDataTest = new Matchs.Domain.Entity.MatchData();
                formatter.Serialize( stream, matchDataTest );
                stream.Close();
            }

            matchDataSaverBinaryFile = new Matchs.Domain.UseCase.MatchDataSaverBinaryFile( formatter, filePath, filePathToRead );

        }

        public void MatchDataSaverAsBinaryFileRegisterService()
        {
            ServiceLocator.Instance.RegisterService<Matchs.Domain.Data.IMatchDataSaver>( matchDataSaverBinaryFile );
        }

    }
}