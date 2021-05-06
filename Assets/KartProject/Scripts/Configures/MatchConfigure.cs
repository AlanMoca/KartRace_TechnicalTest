using UnityEngine;
using KartRace.Matchs.Domain.Data;
using KartRace.Matchs.InterfaceAdapters.Controller;
using KartRace.Matchs.Domain.Entity;

namespace KartRace.Configures
{
    public class MatchConfigure : MonoBehaviour
    {
        [Header( "MatchDetail Instance" )]
        [SerializeField] private MatchController matchController;

        //When it is configuration, the star is used so that it gives time to the installers to create the instances
        private void Start()
        {
            var matchDataSaver = GetMatchDataSaverTypeService();
            var matchData = GetMatchData( matchDataSaver );

            matchController.Configure( matchDataSaver, matchData );
        }

        private IMatchDataSaver GetMatchDataSaverTypeService()
        {
            IMatchDataSaver matchDataSaver = Application.ServiceLocator.Instance.GetService<IMatchDataSaver>();
            return matchDataSaver;
        }

        private MatchData GetMatchData( IMatchDataSaver matchDataSaver )
        {
            MatchData matchData = matchDataSaver.LoadMatchData();
            return matchData;
        }

    }
}