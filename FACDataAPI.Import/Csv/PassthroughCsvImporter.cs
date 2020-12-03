using System.Threading.Tasks;
using FACDataAPI.Common.Configuration;
using FACDataAPI.Data.Import.Entities;
using FACDataAPI.Data.Import.Repositories;
using FACDataAPI.Import.CSV.Maps;

namespace FACDataAPI.Import.Csv
{
    public class PassthroughCsvImporter: BaseCsvImporter, IImporter<Passthrough>
    {
        private CsvImportSettings CsvImportSettings { get; set; }
        private IBulkImportRepository<Passthrough> DataRepository { get; set; }

        public PassthroughCsvImporter
        (
            CsvImportSettings csvImportSettings,
            IBulkImportRepository<Passthrough> dataRepository
        )
        {
            CsvImportSettings = csvImportSettings;
            DataRepository = dataRepository;
        }
        
        public async Task<ImportResult> Import()
        {
            return await ImportCsv<Passthrough>(DataRepository, new PassthroughMap(), CsvImportSettings,
                ImportResultType.Passthrough, CsvImportSettings.PassthroughImportFilename);
        }

    }
}