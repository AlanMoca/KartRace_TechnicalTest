using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using KartRace.Application;

namespace KartRace.SaveSystems.Domain.UseCase
{
    public class DataSaverGenericJsonUtilize : Entity.IDataSaver
    {
        private BinaryFormatter formatter;
        private string filePath;
        private string filePathToRead;

        public DataSaverGenericJsonUtilize()
        {
            formatter = new BinaryFormatter();
            filePath = "";
        }

        public void SaveData<T>( T objectData, string fileName ) where T : class
        {
            var dataParser = ServiceLocator.Instance.GetService<IParser>();
            var fileSystem = ServiceLocator.Instance.GetService<IFile>();

            filePath = GetFilePath( fileName );
            var dataInJson = dataParser.Serialize<T>( objectData );
            fileSystem.WriteAllText( filePath, dataInJson );
        }

        public T LoadData<T>( string fileName ) where T : class
        {
            var dataParser = ServiceLocator.Instance.GetService<IParser>();
            var fileSystem = ServiceLocator.Instance.GetService<IFile>();

            filePath = GetFilePath( fileName );

            if( fileSystem.Exists( filePath ) )                                                 //Android: change this for filepathToRead
            {
                var jsonString = fileSystem.ReadAllText( filePath );
                var matchData = dataParser.Deserialize<T>( jsonString );

                return matchData;
            }

            return ValidatingMatchDataFile<T>( filePath );
        }

        private string GetFilePath( string fileName )
        {
            if( !string.IsNullOrEmpty( filePath ) )                                             //Se cumplen reglas de "clausula de guarda" y "tell don´t ask".
            {
                return filePath;
            }

            var directoryPath = $"{UnityEngine.Application.persistentDataPath}/saves";
            ValidateDirectory( directoryPath );

#if UNITY_EDITOR
            filePath = $"{directoryPath}/{fileName}.json";
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
            var dataParser = ServiceLocator.Instance.GetService<IParser>();
            var fileSystem = ServiceLocator.Instance.GetService<IFile>();

            var stream = fileSystem.Create( filePath );
            stream.Close();                                                                 //It closes because it cannot share the smae FileStream. You cannot open/creat it at the same time as writing or reading.
            T objectDataTemp = Activator.CreateInstance<T>();
            var dataInJson = dataParser.Serialize<T>( objectDataTemp );
            fileSystem.WriteAllText( filePath, dataInJson );

            return objectDataTemp;
        }

    }
}
