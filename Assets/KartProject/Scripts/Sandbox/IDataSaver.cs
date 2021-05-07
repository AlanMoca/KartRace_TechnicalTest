using KartRace.Matchs.Domain.Entity;

namespace KartRace.Application.Entity
{
    public interface IDataSaver
    {
        public void SaveData<T>( T matchData, string fileName ) where T : class;
        public T LoadData<T>( string fileName ) where T : class;
    }
}

