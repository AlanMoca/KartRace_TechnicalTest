namespace KartRace.Application
{
    public interface IDataSaverPlayerPref
    {
        void SetInt( string key, int value );
        int GetInt( string key, int defaultValue = default );
        void SetFloat( string key, float value );
        float GetFloat( string key, float defaultValue = default );
        void SetString( string key, string value );
        string GetString( string key, string defaultValue = default );
    }
}

//NOTA: Con el adapter desacoplamos la clase estática playerPref y luego tendremos que desacoplar JSON con otro adapter
//El punto de esta abstracción es para el servicelocator para usar este servicio facilmente donde queramos, sin tener que instanciar.

