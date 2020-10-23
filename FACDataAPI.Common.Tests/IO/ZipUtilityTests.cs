using System;
using System.IO;
using System.Threading.Tasks;
using FACDataAPI.Common.Http;
using FACDataAPI.Common.IO;
using NUnit.Framework;

namespace FACDataAPI.Common.Tests.IO
{
    [TestFixture]
    public class ZipUtilityTests
    {

        private string TargetDirectory { get; set; } = 
            Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "Data");

        private string ZipFileName { get; set; } = "IncompleteAudits14.zip";

        private Uri ZipFileUrl { get; set; } =
            new Uri("https://www2.census.gov/pub/outgoing/govs/singleaudit/IncompleteAudits14.zip");

        private string UnzippedFilename { get; set; } = "IncompleteAudits14.txt";

            
        [SetUp]
        public void SetUp()
        {
           CleanEnvironment();    
        }

        [TearDown]
        public void TearDown()
        {
            CleanEnvironment();
        }

        private void CleanEnvironment()
        {
            if (File.Exists(Path.Combine(TargetDirectory, ZipFileName)))
            {
                File.Delete(Path.Combine(TargetDirectory, ZipFileName));
            }
            
            if (File.Exists(Path.Combine(TargetDirectory, UnzippedFilename)))
            {
                File.Delete(Path.Combine(TargetDirectory, UnzippedFilename));
            }
            
        }

        [Test]
        public async Task TestUnzip()
        {
            //Download a "real life" test file
            IFileDownloadUtilities du = new FileDownloadUtilities();
            await du.DownloadFile(ZipFileUrl, TargetDirectory);
            
            Assert.IsTrue(File.Exists(Path.Combine(TargetDirectory, ZipFileName)));
            
            IZipUtility zu = new ZipUtility();

            zu.UnZipFile(Path.Combine(TargetDirectory, ZipFileName), TargetDirectory);
            
            Assert.IsTrue(File.Exists(Path.Combine(TargetDirectory, UnzippedFilename)));
        }
    }
}