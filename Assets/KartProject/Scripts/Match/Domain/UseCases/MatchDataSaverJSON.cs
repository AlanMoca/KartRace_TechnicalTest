using System.IO;
using KartRace.Application;
using KartRace.Matchs.Domain.Entity;

namespace KartRace.Matchs.Domain.UseCase
{
    public class MatchDataSaverJSON : IMatchDataSaver
    {
        private string filePath;
        private string filePathToRead;

        public MatchDataSaverJSON()
        {
            filePath = "";
        }

        public void SaveMatchData( MatchData matchData )
        {
            filePath = GetFilePath( "matchdata" );

            var dataParser = ServiceLocator.Instance.GetService<IParser>();
            var fileSystem = ServiceLocator.Instance.GetService<IFile>();

            var dataInJson = dataParser.Serialize<MatchData>( matchData );
            fileSystem.WriteAllText( filePath, dataInJson );
        }

        public MatchData LoadMatchData()
        {
            filePath = GetFilePath( "matchdata" );

            var dataParser = ServiceLocator.Instance.GetService<IParser>();
            var fileSystem = ServiceLocator.Instance.GetService<IFile>();

            if( fileSystem.Exists( filePath ) )                                                //Android: change this for filepathToRead
            {
                var jsonString = fileSystem.ReadAllText( filePath );
                var matchData = dataParser.Deserialize<MatchData>( jsonString );

                return matchData;
            }

            return ValidatingMatchDataFile( filePath );
        }

        private string GetFilePath( string fileName )
        {
            if( !string.IsNullOrEmpty( filePath ) )                                              //The rules of "clausula de guarda" & "tell don´t ask" are fulfilled.
            {
                return filePath;
            }

            var directoryPath = $"{UnityEngine.Application.persistentDataPath}/saves";
            ValidateDirectory( directoryPath );

#if UNITY_EDITOR
            filePath = $"{directoryPath}/{fileName}.json";
#elif UNITY_ANDROID
            //filePath = $"jar:file://{UnityEngine.Application.dataPath}!/assets/{fileName}.json";
            //filePathToRead = "jar:file://" + Application.dataPath + "!/assets/matchdata.json";
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
            var dataParser = ServiceLocator.Instance.GetService<IParser>();
            var fileSystem = ServiceLocator.Instance.GetService<IFile>();

            var stream = fileSystem.Create( filePath );
            stream.Close();                                                                 //It closes because it cannot share the smae FileStream. You cannot open/creat it at the same time as writing or reading.
            MatchData matchDataTemp = new MatchData();
            var dataInJson = dataParser.Serialize<MatchData>( matchDataTemp );
            fileSystem.WriteAllText( filePath, dataInJson );
            return matchDataTemp;
        }
    }
}