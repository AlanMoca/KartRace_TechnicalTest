using UnityEngine;

namespace KartRace.InterfaceAdapters
{
    public class UnityJsonUtilizeAdapter : Application.IParser
    {
        public string Serialize<T>( T data )
        {
            return JsonUtility.ToJson( data );
        }

        public T Deserialize<T>( string data )
        {
            return JsonUtility.FromJson<T>( data );
            
        }
    }
}