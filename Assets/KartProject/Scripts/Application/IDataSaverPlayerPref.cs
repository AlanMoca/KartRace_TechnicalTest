namespace KartRace.Application
{
    public interface IDataSaverPlayerPref
    {
        public void SetInt( string key, int value );
        public int GetInt( string key, int defaultValue = default );
        public void SetFloat( string key, float value );
        public float GetFloat( string key, float defaultValue = default );
        public void SetString( string key, string value );
        public string GetString( string key, string defaultValue = default );
    }
}

//NOTA: Con el adapter desacoplamos la clase estática playerPref y luego tendremos que desacoplar JSON con otro adapter
//El punto de esta abstracción es para el servicelocator para usar este servicio facilmente donde queramos, sin tener que instanciar.

