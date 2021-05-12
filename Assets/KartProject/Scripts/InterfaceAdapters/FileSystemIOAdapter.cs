using System.IO;

namespace KartRace.InterfaceAdapters
{
    public class FileSystemIOAdapter : Application.IFile
    {
        public void Copy( string sourceFileName, string destFileName )
        {
            File.Copy( sourceFileName, destFileName );
        }

        public void Copy( string sourceFileName, string destFileName, bool overwrite )
        {
            File.Copy( sourceFileName, destFileName, overwrite );
        }

        public FileStream Create( string path )
        {
            return File.Create( path );
        }

        public bool Exists( string path )
        {
            return File.Exists( path );
        }

        public FileStream Open( string path, FileMode mode )
        {
            return File.Open( path, mode );
        }

        public string ReadAllText( string path )
        {
            return File.ReadAllText( path );
        }

        public void WriteAllText( string path, string contents )
        {
            File.WriteAllText( path, contents );
        }
    }
}