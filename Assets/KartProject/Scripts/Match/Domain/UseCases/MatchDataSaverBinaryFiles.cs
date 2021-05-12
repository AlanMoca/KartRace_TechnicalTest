using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using KartRace.Application;
using KartRace.Matchs.Domain.Entity;

namespace KartRace.Matchs.Domain.UseCase
{
    public class MatchDataSaverBinaryFiles : IMatchDataSaver
    {
        private BinaryFormatter formatter;
        private string filePath;
        private string filePathToRead;

        public MatchDataSaverBinaryFiles()
        {
            formatter = new BinaryFormatter();
            filePath = "";
        }

        public void SaveMatchData( MatchData matchData )
        {
            var fileSystem = ServiceLocator.Instance.GetService<IFile>();

            filePath = GetFilePath( "matchdata" );
            FileStream stream = fileSystem.Open( filePath, FileMode.OpenOrCreate );
            formatter.Serialize( stream, matchData );
            stream.Close();
        }

        public MatchData LoadMatchData()
        {
            filePath = GetFilePath( "matchdata" );
            var fileSystem = ServiceLocator.Instance.GetService<IFile>();

            if( File.Exists( filePath ) )                                                          //Android: change this for filepathToRead
            {
                var stream = fileSystem.Open( filePath, FileMode.OpenOrCreate );
                Entity.MatchData matchData = formatter.Deserialize( stream ) as Entity.MatchData;
                stream.Close();
                return matchData;
            }

            return ValidatingMatchDataFile( filePath );
        }

        private string GetFilePath( string fileName )
        {
            if( !string.IsNullOrEmpty( filePath ) )                                              //Se cumplen reglas de "clausula de guarda" y "tell don´t ask".
            {
                return filePath;
            }

            var directoryPath = $"{UnityEngine.Application.persistentDataPath}/saves";
            ValidateDirectory( directoryPath );

#if UNITY_EDITOR
            filePath = $"{directoryPath}/{fileName}.data";
#elif UNITY_ANDROID
            //filePath = $"jar:file://{UnityEngine.Application.dataPath}!/assets/{fileName}.data";
            //filePathToRead = "jar:file://" + Application.dataPath + "!/assets/matchdata.data";
#endif
            return filePath;
        }

        private void ValidateDirectory( string directoryPath )
        {
            if( Directory.Exists( directoryPath ) )
            {
                return;
            }
            Directory.CreateDirectory( directoryPath );
        }

        private MatchData ValidatingMatchDataFile( string filePath )
        {
            var fileSystem = ServiceLocator.Instance.GetService<IFile>();

            var stream = fileSystem.Create( filePath );
            MatchData matchDataTemp = new MatchData();
            formatter.Serialize( stream, matchDataTemp );
            stream.Close();
            return matchDataTemp;
        }
    }
}
