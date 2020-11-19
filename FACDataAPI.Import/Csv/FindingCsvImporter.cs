using System.Threading.Tasks;
using FACDataAPI.Common.Configuration;
using FACDataAPI.Data.Import.Entities;
using FACDataAPI.Data.Import.Repositories;
using FACDataAPI.Import.CSV.Maps;


namespace FACDataAPI.Import.Csv
{
    public class FindingCsvImporter:BaseCsvImporter, IImporter<Finding>
    {
        private CsvImportSettings CsvImportSettings { get; set; }
        private IBulkImportRepository<Finding> DataRepository { get; set; }

        public FindingCsvImporter
        (
            CsvImportSettings csvImportSettings,
            IBulkImportRepository<Finding> dataRepository
        )
        {
            CsvImportSettings = csvImportSettings;
            DataRepository = dataRepository;
        }
        
        public async Task<ImportResult> Import()
        {
            return await ImportCsv<Finding>(DataRepository, new FindingMap(), CsvImportSettings,
                ImportResultType.Findings, CsvImportSettings.FindingsImportFilename);
        }

    }
}