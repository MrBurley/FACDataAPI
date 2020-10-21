using System;
using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;
using FACDataAPI.Common.Http;


namespace FACDataAPI.Common.Tests.Http
{
    [TestFixture]
    public class FileDownloadUtilitiesTests
    {
        [Test]
        public async Task TestDownloadFileSuccess()
        {
            string downloadDir = Path.GetTempPath();
            //string downloadFile = Path.GetTempFileName();
            //string targetPath = Path.Combine(downloadDir, downloadFile);
            
            Uri source = new Uri("https://file-examples-com.github.io/uploads/2017/10/file-sample_150kB.pdf");
            
            IFileDownloadUtilities fileDownloadUtilities = new FileDownloadUtilities();

            FileDownloadResult result = await fileDownloadUtilities.DownloadFile(source, downloadDir);

            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Source);
            Assert.IsTrue(!String.IsNullOrEmpty(result.TargetDirectory));
            Assert.IsTrue(!String.IsNullOrEmpty(result.LocalFilePath));
            Assert.IsTrue(!String.IsNullOrEmpty(result.Filename));
            Assert.IsTrue(!String.IsNullOrEmpty(result.MimeType));
            Assert.Greater(result.FileSize, 0);
            Assert.IsNotNull(result.DownloadTime);
            Assert.IsNull(result.ErrorDetail);
            
            //Clean up the file
            File.Delete(result.LocalFilePath);
            
            Assert.IsFalse(File.Exists(result.LocalFilePath));
        }
    }
}