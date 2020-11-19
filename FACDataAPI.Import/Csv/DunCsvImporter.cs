using System.Threading.Tasks;
using FACDataAPI.Common.Configuration;
using FACDataAPI.Data.Import.Entities;
using FACDataAPI.Data.Import.Repositories;
using FACDataAPI.Import.CSV.Maps;

namespace FACDataAPI.Import.Csv
{
    public class DunCsvImporter:BaseCsvImporter, IImporter<Dun>
    {
        private CsvImportSettings CsvImportSettings { get; set; }
        private IBulkImportRepository<Dun> DataRepository { get; set; }

        public DunCsvImporter
        (
            CsvImportSettings csvImportSettings,
            IBulkImportRepository<Dun> dataRepository
        )
        {
            CsvImportSettings = csvImportSettings;
            DataRepository = dataRepository;
        }
        
        public async Task<ImportResult> Import()
        {
            return await ImportCsv<Dun>(DataRepository, new DunMap(), CsvImportSettings,
                ImportResultType.Duns, CsvImportSettings.DunsImportFilename);
        }

    }
}