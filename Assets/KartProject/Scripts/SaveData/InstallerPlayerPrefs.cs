using UnityEngine;

public class InstallerPlayerPrefs : MonoBehaviour
{
    private void Awake()
    {
        var playerPrefsAdapter = new PlayerPrefAdapter();
        ServiceLocator.Instance.RegisterService<IDataSaver>( playerPrefsAdapter );
    }
}
