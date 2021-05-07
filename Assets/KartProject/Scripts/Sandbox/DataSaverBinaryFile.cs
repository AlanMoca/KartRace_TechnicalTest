using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace KartRace.Application.UseCase
{
    public class DataSaverBinaryFile : Entity.IDataSaver
    {
        private BinaryFormatter formatter;
        private string filePath;
        private string filePathToRead;

        public DataSaverBinaryFile()
        {
            formatter = new BinaryFormatter();
            filePath = "";
        }

        public void SaveData<T>( T objectData, string fileName ) where T : class
        {
            filePath = GetFilePath( fileName );
            FileStream stream;

            if( !File.Exists( filePath ) )
            {
                stream = OpenFile( fileName );

                //T objectDataTemp = new (T)Activator.CreateInstance( typeof(T), new object[] );
                //T objectDataTemp = (T)Activator.CreateInstance( typeof( T ), new object[] { } );
                //T objectDataTemp = (T)Activator.CreateInstance( typeof( T ) );
                T objectDataTemp = Activator.CreateInstance<T>();
                formatter.Serialize( stream, objectDataTemp );
                stream.Close();
            }

            stream = OpenFile( fileName );
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

                //T objectDataTemp = new (T)Activator.CreateInstance( typeof(T), new object[] );
                //T objectDataTemp = (T)Activator.CreateInstance( typeof( T ), new object[] { } );
                //T objectDataTemp = (T)Activator.CreateInstance( typeof( T ) );
                T objectDataTemp = Activator.CreateInstance<T>();
                formatter.Serialize( stream, objectDataTemp );
                stream.Close();
            }

            if( !File.Exists( filePath ) )                                                               //Android: change this for filepathToRead
            {
                UnityEngine.Debug.LogWarning( "Save file not found " + filePath );
                return default(T);
            }
            stream = OpenFile( fileName );
            T objectData = formatter.Deserialize( stream ) as T;
            stream.Close();
            return objectData;
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

        //The static class is encapsulated to avoid coupling. If we use the "File" class and its methods more, we should create an adapter.
        private FileStream OpenFile( string fileName )
        {
            filePath = GetFilePath( fileName );
            return File.Open( filePath, FileMode.OpenOrCreate );
            //return new FileStream( filePath, FileMode.Open );
        }

        
    }
}