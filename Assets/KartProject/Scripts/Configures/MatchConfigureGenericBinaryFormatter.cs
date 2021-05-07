using UnityEngine;
using KartRace.Matchs.Domain.Data;
using KartRace.Matchs.InterfaceAdapters.Controller;
using KartRace.Matchs.Domain.Entity;

namespace KartRace.Configures
{
        public class MatchConfigureGenericBinaryFormatter : MonoBehaviour
    {
        [Header( "MatchDetail Instance" )]
        [SerializeField] private MatchControllerGenericBinaryFormatter matchController;

        //When it is configuration, the star is used so that it gives time to the installers to create the instances
        private void Start()
        {
            var matchDataSaver = GetMatchDataSaverTypeService();
            var matchData = GetMatchData( matchDataSaver );

            matchController.Configure( matchDataSaver, matchData );
        }

        private Application.Entity.IDataSaver GetMatchDataSaverTypeService()
        {
            Application.Entity.IDataSaver matchDataSaver = Application.ServiceLocator.Instance.GetService<Application.Entity.IDataSaver>();
            return matchDataSaver;
        }

        private MatchData GetMatchData( Application.Entity.IDataSaver matchDataSaver )
        {
            MatchData matchData = matchDataSaver.LoadData<MatchData>( "matchData" );
            return matchData;
        }

    }
}