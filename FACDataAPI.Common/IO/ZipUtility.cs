using System.IO;
using System.IO.Compression;

namespace FACDataAPI.Common.IO
{

    public interface IZipUtility
    {
        void UnZipFile(string sourceZipFile, string targetdir);
    }
    
    public class ZipUtility: IZipUtility
    {
        public void UnZipFile(string sourceZipFile, string targetdir)
        {
            if (File.Exists(sourceZipFile))
            {
                if (!Directory.Exists(targetdir))
                {
                    Directory.CreateDirectory(targetdir);
                }

                ZipFile.ExtractToDirectory(sourceZipFile, targetdir);
            }
        }
    }
}