using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace KartRace.Matchs.Domain.UseCase
{
    public class MatchDataSaverBinaryFiles : Entity.IMatchDataSaver
    {
        private BinaryFormatter formatter;
        private string filePath;
        private string filePathToRead;

        public MatchDataSaverBinaryFiles()
        {
            formatter = new BinaryFormatter();
            filePath = "";
        }

        public void SaveMatchData( Entity.MatchData matchData )
        {
            filePath = GetFilePath( "matchData" );
            FileStream stream = OpenFile();
            formatter.Serialize( stream, matchData );
            stream.Close();
        }

        public Entity.MatchData LoadMatchData()
        {
            filePath = GetFilePath( "matchData" );
            FileStream stream;

            if( !File.Exists( filePath ) )                                                          //Android: change this for filepathToRead
            {
                stream = OpenFile();
                Entity.MatchData matchDataTemp = new Entity.MatchData();
                formatter.Serialize( stream, matchDataTemp );
                stream.Close();
            }
            stream = OpenFile();
            Entity.MatchData matchData = formatter.Deserialize( stream ) as Entity.MatchData;
            stream.Close();
            return matchData;
        }

        //public void SaveMatchData( Entity.MatchData matchData )
        //{
        //    filePath = GetFilePath( "matchData" );
        //    FileStream stream;

        //    if( !File.Exists( filePath ) )
        //    {
        //        stream = OpenFile();
        //        Entity.MatchData matchDataTemp = new Entity.MatchData();
        //        formatter.Serialize( stream, matchDataTemp );
        //        stream.Close();
        //    }

        //    stream = OpenFile();
        //    formatter.Serialize( stream, matchData );
        //    stream.Close();
        //}

        //public Entity.MatchData LoadMatchData()
        //{
        //    filePath = GetFilePath( "matchData" );
        //    FileStream stream;

        //    if( !File.Exists( filePath ) )
        //    {
        //        stream = OpenFile();
        //        Entity.MatchData matchDataTemp = new Entity.MatchData();
        //        formatter.Serialize( stream, matchDataTemp );
        //        stream.Close();
        //    }

        //    if( !File.Exists( filePath ) )                                                               //Android: change this for filepathToRead
        //    {
        //        UnityEngine.Debug.LogWarning( "Save file not found " + filePath );
        //        return null;
        //    }

        //    stream = OpenFile();
        //    Entity.MatchData matchData = formatter.Deserialize( stream ) as Entity.MatchData;
        //    stream.Close();
        //    return matchData;
        //}

        //The static class is encapsulated to avoid coupling. If we use the "File" class and its methods more, we should create an adapter.
        private FileStream OpenFile()
        {
            return File.Open( filePath, FileMode.OpenOrCreate );
            //return new FileStream( filePath, FileMode.Open );
        }

        private string GetFilePath( string fileName )
        {
#if UNITY_EDITOR
            filePath = $"{UnityEngine.Application.persistentDataPath}/{fileName}.data";
#elif UNITY_ANDROID
            //filePath = $"jar:file://{UnityEngine.Application.dataPath}!/assets/{fileName}.data";
            //filePathToRead = "jar:file://" + Application.dataPath + "!/assets/matchdata.data";
#endif
            return filePath;
        }

    }

    //public class MatchDataSaverBinaryFile : Data.IMatchDataSaver
    //{
    //    private BinaryFormatter formatter;
    //    private string filePath;
    //    private string filePathToRead;

    //    public MatchDataSaverBinaryFile( BinaryFormatter _formatter, string _filePath, string _filePathToRead )
    //    {
    //        formatter = _formatter;
    //        filePath = _filePath;
    //        filePathToRead = _filePathToRead;
    //    }

    //    public void SaveMatchData( Entity.MatchData matchData )
    //    {
    //        var stream = OpenFile();
    //        formatter.Serialize( stream, matchData );
    //        stream.Close();
    //    }

    //    public Entity.MatchData LoadMatchData()
    //    {
    //        if( !File.Exists( filePath ) )                                                               //Android: change this for filepathToRead
    //        {
    //            UnityEngine.Debug.LogWarning( "Save file not found " + filePath );
    //            return null;
    //        }
    //        var stream = OpenFile();
    //        Entity.MatchData matchData = formatter.Deserialize( stream ) as Entity.MatchData;
    //        stream.Close();
    //        return matchData;
    //    }

    //    //The static class is encapsulated to avoid coupling. If we use the "File" class and its methods more, we should create an adapter.
    //    private FileStream OpenFile()
    //    {
    //        return File.Open( filePath, FileMode.OpenOrCreate );
    //        //return new FileStream( filePath, FileMode.Open );
    //    }

    //}
}
