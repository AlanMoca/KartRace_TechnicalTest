using UnityEngine;

namespace KartRace.InterfaceAdapters
{
    public class PlayerPrefAdapter : Application.IDataSaverPlayerPref
    {
        public void SetInt( string key, int value )
        {
            PlayerPrefs.SetInt( key, value );
            PlayerPrefs.Save();
        }

        public int GetInt( string key, int defaultValue = default )
        {
            return PlayerPrefs.GetInt( key, defaultValue );
        }

        public void SetFloat( string key, float value )
        {
            PlayerPrefs.SetFloat( key, value );
            PlayerPrefs.Save();
        }

        public float GetFloat( string key, float defaultValue = default )
        {
            return PlayerPrefs.GetFloat( key, defaultValue );
        }

        public void SetString( string key, string value )
        {
            PlayerPrefs.SetString( key, value );
            PlayerPrefs.Save();
        }

        public string GetString( string key, string defaultValue = default )
        {
            return PlayerPrefs.GetString( key, defaultValue );
        }
    }
}
