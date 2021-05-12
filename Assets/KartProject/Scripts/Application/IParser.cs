namespace KartRace.Application
{
    public interface IParser
    {
        string Serialize<T>( T data );
        T Deserialize<T>( string data );
    }
}