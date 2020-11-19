using System.Threading.Tasks;
using FACDataAPI.Common.Configuration;
using FACDataAPI.Data.Import.Entities;
using FACDataAPI.Data.Import.Repositories;
using FACDataAPI.Import.CSV.Maps;

namespace FACDataAPI.Import.Csv
{
    public class CpaCsvImporter:BaseCsvImporter, IImporter<Cpa>
    {
        private CsvImportSettings CsvImportSettings { get; set; }
        private IBulkImportRepository<Cpa> DataRepository { get; set; }

        public CpaCsvImporter
        (
            CsvImportSettings csvImportSettings,
            IBulkImportRepository<Cpa> dataRepository
        )
        {
            CsvImportSettings = csvImportSettings;
            DataRepository = dataRepository;
        }
        
        public async Task<ImportResult> Import()
        {
            return await ImportCsv<Cpa>(DataRepository, new CpaMap(), CsvImportSettings,
                ImportResultType.Cpas, CsvImportSettings.CpaImportFilename);
        }

    }
}