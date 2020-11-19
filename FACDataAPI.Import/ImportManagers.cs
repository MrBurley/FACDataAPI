using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using FACDataAPI.Common.Configuration;
using FACDataAPI.Common.Http;
using FACDataAPI.Common.IO;
using FACDataAPI.Data.Import.Entities;
using FACDataAPI.Data.Import.Repositories;

namespace FACDataAPI.Import
{
    public interface IImportManager
    {
        Task<IList<ImportResult>> PerformImport();
        Task CleanEnvironment();
    }
    
    
    public class CsvImportManager: IImportManager
    {
        private IImporter<Cfda> CfdaImporter { get; set; }
        private IImporter<General> GeneralImporter { get; set; }
        private IImporter<Agency> AgencyImporter { get; set; }
        private IImporter<CapText> CapTextImporter { get; set; }

        private IImporter<Cpa> CpaImporter { get; set; }
        private IImporter<Dun> DunImporter { get; set; }
        private IImporter<Ein> EinImporter { get; set; }
        private IImporter<Finding> FindingImporter { get; set; }
        private IFileDownloadUtilities FileDownloadUtilities { get; set; }
        private IZipUtility ZipUtility { get; set; }
        private CsvImportSettings CsvImportSettings { get; set; }

        public CsvImportManager
        (
            IFileDownloadUtilities fileDownloadUtilities,
            IZipUtility zipUtility,
            IImporter<Cfda> cfdaImporter,
            CsvImportSettings importSettings,
            IImporter<General> generalImporter,
            IImporter<Agency> agencyImporter,
            IImporter<CapText> captextImporter,
            IImporter<Cpa> cpaImporter,
            IImporter<Dun> dunImporter,
            IImporter<Ein> einImporter,
            IImporter<Finding> findingImporter
        )
        {
            FileDownloadUtilities = fileDownloadUtilities;
            ZipUtility = zipUtility;
            CfdaImporter = cfdaImporter;
            CsvImportSettings = importSettings;
            GeneralImporter = generalImporter;
            AgencyImporter = agencyImporter;
            CapTextImporter = captextImporter;
            CpaImporter = cpaImporter;
            DunImporter = dunImporter;
            EinImporter = einImporter;
            FindingImporter = findingImporter;
        }

        public async Task<IList<ImportResult>> PerformImport()
        {
            
            IList<ImportResult> results = new List<ImportResult>();

            //clean the files
            await CleanEnvironment();
            
            //Download the zipfile
            FileDownloadResult downloadResult =
                await FileDownloadUtilities.DownloadFile(new Uri(Path.Combine(CsvImportSettings.FtpSource, CsvImportSettings.FacZipFilename)),
                    CsvImportSettings.LocalImportDirectory);

            if (downloadResult.Success)
            {
                ZipUtility.UnZipFile(downloadResult.LocalFilePath, downloadResult.TargetDirectory);
                
                results.Add(await FindingImporter.Import());
                results.Add(await EinImporter.Import());
                results.Add(await DunImporter.Import());
                results.Add(await CpaImporter.Import());
                results.Add(await CapTextImporter.Import());
                results.Add(await AgencyImporter.Import());
                results.Add(await GeneralImporter.Import());
                results.Add(await CfdaImporter.Import());
                
                
            }

            return results;

        }

        public async Task CleanEnvironment()
        {
            await Task.Run(() =>
            {
            
            IList<string> importFilenames = new List<string>();
            
            importFilenames.Add(Path.Combine(CsvImportSettings.LocalImportDirectory, CsvImportSettings.FacZipFilename));
            importFilenames.Add(Path.Combine(CsvImportSettings.LocalImportDirectory, CsvImportSettings.RevisionImportFilename));
            importFilenames.Add(Path.Combine(CsvImportSettings.LocalImportDirectory, CsvImportSettings.CapTextImportFilename));
            importFilenames.Add(Path.Combine(CsvImportSettings.LocalImportDirectory, CsvImportSettings.FindingsTextImportFilename));
            importFilenames.Add(Path.Combine(CsvImportSettings.LocalImportDirectory, CsvImportSettings.NotesImportFilename));
            importFilenames.Add(Path.Combine(CsvImportSettings.LocalImportDirectory, CsvImportSettings.CpaImportFilename));
            importFilenames.Add(Path.Combine(CsvImportSettings.LocalImportDirectory, CsvImportSettings.PassthroughImportFilename));
            importFilenames.Add(Path.Combine(CsvImportSettings.LocalImportDirectory, CsvImportSettings.FindingsImportFilename));
            importFilenames.Add(Path.Combine(CsvImportSettings.LocalImportDirectory, CsvImportSettings.DunsImportFilename));
            importFilenames.Add(Path.Combine(CsvImportSettings.LocalImportDirectory, CsvImportSettings.EinsImportFilename));
            importFilenames.Add(Path.Combine(CsvImportSettings.LocalImportDirectory, CsvImportSettings.AgencyImportFilename));
            importFilenames.Add(Path.Combine(CsvImportSettings.LocalImportDirectory, CsvImportSettings.CfdaImportFilename));
            importFilenames.Add(Path.Combine(CsvImportSettings.LocalImportDirectory, CsvImportSettings.GeneralImportFilename));
            importFilenames.Add(Path.Combine(CsvImportSettings.LocalImportDirectory, CsvImportSettings.FormattedCapTextImportFilename));
            importFilenames.Add(Path.Combine(CsvImportSettings.LocalImportDirectory, CsvImportSettings.FormattedFindingsTextImportFilename));
            
                foreach (var filename in importFilenames)
                {
                    if (File.Exists(filename))
                    {
                        File.Delete(filename);
                    }
                }

            });
            
            
        }
    }
}