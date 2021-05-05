namespace KartRace.Matchs.Domain.Entity
{
    [System.Serializable]
    public class MatchData
    {
        public int numberOfRaces;
        public int racesWon;
        public float bestTime;

        public void AddNumberOfRaces()
        {
            numberOfRaces++;
        }

        public int GetNumberOfRaces()
        {
            return numberOfRaces;
        }

        public void AddRacesWon()
        {
            racesWon++;
        }

        public int GetRacesWon()
        {
            return racesWon;
        }

        public void UpdateBestTime( float currentFinalTime )
        {
            if( bestTime >= currentFinalTime )
            {
                return;
            }
            else
            {
                bestTime = currentFinalTime;
            }
        }

        public float GetBestTime()
        {
            return bestTime;
        }

    }



}
    
