using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace KartRace.Matchs.Domain.UseCase
{
    public class MatchDataSaverBinaryFile : Data.IMatchDataSaver
    {
        private BinaryFormatter formatter;
        private string filePath;
        private string filePathToRead;

        public MatchDataSaverBinaryFile( BinaryFormatter _formatter, string _filePath, string _filePathToRead )
        {
            formatter = _formatter;
            filePath = _filePath;
            filePathToRead = _filePathToRead;
        }

        public void SaveMatchData( Entity.MatchData matchData )
        {
            var stream = OpenFile();
            formatter.Serialize( stream, matchData );
            stream.Close();
        }

        public Entity.MatchData LoadMatchData()
        {
            if( !File.Exists( filePath ) )                                                               //Android: change this for filepathToRead
            {
                UnityEngine.Debug.LogWarning( "Save file not found " + filePath );
                return null;
            }
            var stream = OpenFile();
            Entity.MatchData matchData = formatter.Deserialize( stream ) as Entity.MatchData;
            stream.Close();
            return matchData;
        }

        //The static class is encapsulated to avoid coupling. If we use the "File" class and its methods more, we should create an adapter.
        private FileStream OpenFile()
        {
            return File.Open( filePath, FileMode.OpenOrCreate );
            //return new FileStream( filePath, FileMode.Open );
        }

    }
}