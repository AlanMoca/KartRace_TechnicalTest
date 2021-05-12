using System.IO;

namespace KartRace.Application
{
    
    public interface IFile
    {
        public void Copy( string sourceFileName, string destFileName );
        public void Copy( string sourceFileName, string destFileName, bool overwrite );
        public FileStream Create( string path );
        public bool Exists( string path );
        public FileStream Open( string path, FileMode mode );
        public string ReadAllText( string path );
        public void WriteAllText( string path, string contents );
    }
}