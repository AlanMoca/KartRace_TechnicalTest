using UnityEngine;
using KartRace.Matchs.InterfaceAdapters.Controller;
using KartRace.Matchs.Domain.Entity;

namespace KartRace.Configures
{
    public class MatchConfigure : MonoBehaviour
    {
        [Header( "MatchDetail Instance" )]
        [SerializeField] private MatchController matchController;

        [Header( "Save System" )]
        [Tooltip( "Use a CloudService to Save System. This option have mayor priroty than others kinds of save systems." )]
        [SerializeField] private bool useCloudServiceSaveSystem;
        [Tooltip( "Use a Generic Save System for Binary Files or the one that was configured in the installers. This option must also be activated in the others scenes." )]
        [SerializeField] private bool useGenericSaveSystem;
        [Tooltip( "Use a Specific Save System for every data file wiht Binary Files or the one that was configured in the installers. This option must also be activated in the others scenes." )]
        [SerializeField] private bool useASpecifcSaveSystem;

        //When it is configuration, the star is used so that it gives time to the installers to create the instances
        private void Start()
        {
            if( useCloudServiceSaveSystem )
            {
                var cloudService = Application.ServiceLocator.Instance.GetService<CloudService.Domain.Entity.ICloudService>();
                var matchDataSaver = GetMatchDataSaverTypeService();

                if( !cloudService.IsLoggedIn() )
                {
                    matchController.Configure( matchDataSaver );
                    return;
                }

                var matchData = GetMatchDataFromInstallersSaveSystem( matchDataSaver );
                matchController.Configure( matchDataSaver, matchData, true );

                return;
            }
            if( useGenericSaveSystem )
            {
                var genericDataSaver = GetGenericDataSaverTypeService();
                var matchData = GetMatchDataFromGenericSaveSystem( genericDataSaver );

                matchController.Configure( genericDataSaver, matchData );

                return;
            }
            if( useASpecifcSaveSystem )
            {
                var matchDataSaver = GetMatchDataSaverTypeService();
                var matchData = GetMatchDataFromInstallersSaveSystem( matchDataSaver );

                matchController.Configure( matchDataSaver, matchData, false );

                return;
            }
        }

        private SaveSystems.Domain.Entity.IDataSaver GetGenericDataSaverTypeService()
        {
            KartRace.SaveSystems.Domain.Entity.IDataSaver dataSaver = Application.ServiceLocator.Instance.GetService<SaveSystems.Domain.Entity.IDataSaver>();
            return dataSaver;
        }

        private MatchData GetMatchDataFromGenericSaveSystem( KartRace.SaveSystems.Domain.Entity.IDataSaver matchDataSaver )
        {
            MatchData matchData = matchDataSaver.LoadData<MatchData>( "matchData" );
            return matchData;
        }

        private IMatchDataSaver GetMatchDataSaverTypeService()
        {
            IMatchDataSaver matchDataSaver = Application.ServiceLocator.Instance.GetService<IMatchDataSaver>();
            return matchDataSaver;
        }

        private MatchData GetMatchDataFromInstallersSaveSystem( IMatchDataSaver matchDataSaver )
        {
            MatchData matchData = matchDataSaver.LoadMatchData();
            return matchData;
        }
    }
}