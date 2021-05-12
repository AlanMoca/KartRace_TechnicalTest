using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace KartRace.SaveSystems.Domain.UseCase
{
    public class DataSaverGenericBinaryFiles : Entity.IDataSaver
    {
        private BinaryFormatter formatter;
        private string filePath;
        private string filePathToRead;

        public DataSaverGenericBinaryFiles()
        {
            formatter = new BinaryFormatter();
            filePath = "";
        }

        public void SaveData<T>( T objectData, string fileName ) where T : class
        {
            filePath = GetFilePath( fileName );
            FileStream stream = OpenFile( fileName );
            formatter.Serialize( stream, objectData );
            stream.Close();
        }

        public T LoadData<T>( string fileName ) where T : class
        {
            filePath = GetFilePath( fileName );
            FileStream stream;

            if( !File.Exists( filePath ) )
            {
                stream = OpenFile( fileName );
                T objectDataTemp = Activator.CreateInstance<T>();
                formatter.Serialize( stream, objectDataTemp );
                stream.Close();
            }

            stream = OpenFile( fileName );
            T objectData = formatter.Deserialize( stream ) as T;
            stream.Close();
            return objectData;
        }

        //The static class is encapsulated to avoid coupling. If we use the "File" class and its methods more, we should create an adapter.
        private FileStream OpenFile( string fileName )
        {
            filePath = GetFilePath( fileName );
            return File.Open( filePath, FileMode.OpenOrCreate );
            //return new FileStream( filePath, FileMode.Open );
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
            //filePath = $"jar:file://{UnityEngine.Application.dataPath}!/assets/{fileName}.data";              //Check. Folder "saves" will affect saved in android?
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

    }
}