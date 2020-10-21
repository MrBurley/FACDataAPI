using System;
using System.IO;
using System.Threading.Tasks;
using System.Net;
using MimeMapping;

namespace FACDataAPI.Common.Http
{

    public class FileDownloadResult
    {
        public Uri Source { get; set; }
        public string TargetDirectory { get; set; }
        public string LocalFilePath { get; set; }
        public string Filename { get; set; }
        public string MimeType { get; set; }
        public long FileSize { get; set; }
        public TimeSpan DownloadTime { get; set; }
        public bool Success { get; set; }
        public Exception ErrorDetail { get; set; }

        
    }

    public interface IFileDownloadUtilities
    {
        Task<FileDownloadResult> DownloadFile(Uri source, string targetDirectory);
    }
    
    public class FileDownloadUtilities: IFileDownloadUtilities
    {
        public async Task<FileDownloadResult> DownloadFile(Uri source, string targetDirectory)
        {
            
            FileDownloadResult result = new FileDownloadResult();
            DateTime startStamp = DateTime.Now;
            
            try
            {
                if (!String.IsNullOrEmpty(targetDirectory))
                {
                    result.Source = source;
                    result.Filename = Path.GetFileName(source.LocalPath);
                    result.TargetDirectory = targetDirectory;
                    result.LocalFilePath = Path.Combine(result.TargetDirectory, result.Filename);

                    await new WebClient().DownloadFileTaskAsync(source, result.LocalFilePath);

                    if (File.Exists(result.LocalFilePath))
                    {
                        result.Success = true;
                        result.DownloadTime = DateTime.Now.Subtract(startStamp);
                        result.FileSize = new FileInfo(result.LocalFilePath).Length;
                        result.MimeType = MimeUtility.GetMimeMapping(result.LocalFilePath);
                    }
                }
                
            }
            catch (Exception e)
            {
                result.Success = false;
                result.ErrorDetail = e;
            }

            return result;
        }
    }
}