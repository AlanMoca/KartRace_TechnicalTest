public interface IDataSaver
{
    public void SetInt( string key, int value );
    public int GetInt( string key, int defaultValue = default );
    public void SetFloat( string key, float value );
    public float GetFloat( string key, float defaultValue = default );
    public void SetString( string key, string value );
    public string GetString( string key, string defaultValue = default );
}