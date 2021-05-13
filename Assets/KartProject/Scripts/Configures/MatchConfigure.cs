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
        [Tooltip( "Use a Generic Save System for Binary Files or the one that was configured in the installers. This option must also be activated in the others scenes." )]
        [SerializeField] private bool useGenericSaveSystem;

        //When it is configuration, the star is used so that it gives time to the installers to create the instances
        private void Start()
        {
            if( useGenericSaveSystem )
            {
                var genericDataSaver = GetGenericDataSaverTypeService();
                var matchData = GetMatchDataFromGenericSaveSystem( genericDataSaver );
                //var playerData = GetPlayerDataFromGenericSaveSystem( genericDataSaver );      //Create method

                matchController.Configure( genericDataSaver, matchData );
            }
            else
            {
                var matchDataSaver = GetMatchDataSaverTypeService();
                var matchData = GetMatchDataFromInstallersSaveSystem( matchDataSaver );

                matchController.Configure( matchDataSaver, matchData );
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