using System.Threading.Tasks;
using FACDataAPI.Common.Configuration;
using FACDataAPI.Data.Import.Entities;
using FACDataAPI.Data.Import.Repositories;
using FACDataAPI.Import.CSV.Maps;

namespace FACDataAPI.Import.Csv
{
    public class GeneralCsvImporter:BaseCsvImporter, IImporter<General>
    {
        private CsvImportSettings CsvImportSettings { get; set; }
        private IBulkImportRepository<General> DataRepository { get; set; }

        
        public GeneralCsvImporter
            (
            CsvImportSettings csvImportSettings,
            IBulkImportRepository<General> dataRepository
            )
        {
            CsvImportSettings = csvImportSettings;
            DataRepository = dataRepository;
        }
        
        public async Task<ImportResult> Import()
        {
            return await ImportCsv<General>(DataRepository, new GeneralMap(), CsvImportSettings,
                ImportResultType.General, CsvImportSettings.GeneralImportFilename);
        }
    }
}