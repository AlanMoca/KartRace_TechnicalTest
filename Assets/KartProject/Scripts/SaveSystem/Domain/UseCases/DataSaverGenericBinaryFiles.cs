using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using KartRace.Application;

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
            var fileSystem = ServiceLocator.Instance.GetService<IFile>();

            filePath = GetFilePath( fileName );
            FileStream stream = fileSystem.Open( filePath, FileMode.OpenOrCreate );
            formatter.Serialize( stream, objectData );
            stream.Close();
        }

        public T LoadData<T>( string fileName ) where T : class
        {
            filePath = GetFilePath( fileName );
            var fileSystem = ServiceLocator.Instance.GetService<IFile>();

            if( File.Exists( filePath ) )
            {
                var stream = fileSystem.Open( filePath, FileMode.OpenOrCreate );
                T objectData = formatter.Deserialize( stream ) as T;
                stream.Close();
                return objectData;
            }

            return ValidatingMatchDataFile<T>( filePath );
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

        private T ValidatingMatchDataFile<T>( string filePath )
        {
            var fileSystem = ServiceLocator.Instance.GetService<IFile>();

            var stream = fileSystem.Open( filePath, FileMode.OpenOrCreate );                    //new FileStream( filePath, FileMode.Open );
            T objectDataTemp = Activator.CreateInstance<T>();
            formatter.Serialize( stream, objectDataTemp );
            stream.Close();
            return objectDataTemp;
        }

    }
}