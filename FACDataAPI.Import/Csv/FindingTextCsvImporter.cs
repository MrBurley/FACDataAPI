using FACDataAPI.Data.Import.Entities;
using System.Threading.Tasks;
using FACDataAPI.Common.Configuration;
using FACDataAPI.Data.Import.Repositories;
using FACDataAPI.Import.CSV.Maps;

namespace FACDataAPI.Import.Csv
{
    public class FindingTextCsvImporter:BaseCsvImporter, IImporter<FindingText>
    {
        private CsvImportSettings CsvImportSettings { get; set; }
        private IBulkImportRepository<FindingText> DataRepository { get; set; }

        public FindingTextCsvImporter
        (
            CsvImportSettings csvImportSettings,
            IBulkImportRepository<FindingText> dataRepository
        )
        {
            CsvImportSettings = csvImportSettings;
            DataRepository = dataRepository;
        }
        
        public async Task<ImportResult> Import()
        {
            return await ImportCsv<FindingText>(DataRepository, new FindingTextMap(), CsvImportSettings,
                ImportResultType.FindingsText, CsvImportSettings.FindingsTextImportFilename);
        }

    }
}