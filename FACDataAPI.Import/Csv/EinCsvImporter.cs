using System.Threading.Tasks;
using FACDataAPI.Common.Configuration;
using FACDataAPI.Data.Import.Entities;
using FACDataAPI.Data.Import.Repositories;
using FACDataAPI.Import.CSV.Maps;


namespace FACDataAPI.Import.Csv
{
    public class EinCsvImporter:BaseCsvImporter, IImporter<Ein>
    {
        private CsvImportSettings CsvImportSettings { get; set; }
        private IBulkImportRepository<Ein> DataRepository { get; set; }

        public EinCsvImporter
        (
            CsvImportSettings csvImportSettings,
            IBulkImportRepository<Ein> dataRepository
        )
        {
            CsvImportSettings = csvImportSettings;
            DataRepository = dataRepository;
        }
        
        public async Task<ImportResult> Import()
        {
            return await ImportCsv<Ein>(DataRepository, new EinMap(), CsvImportSettings,
                ImportResultType.Eins, CsvImportSettings.EinsImportFilename);
        }

    }
}