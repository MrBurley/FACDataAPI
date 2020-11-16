using System.Threading.Tasks;
using FACDataAPI.Common.Configuration;
using FACDataAPI.Data.Import.Entities;
using FACDataAPI.Data.Import.Repositories;
using FACDataAPI.Import.CSV.Maps;

namespace FACDataAPI.Import.Csv
{
    public class AgencyCsvImporter:BaseCsvImporter, IImporter<Agency>
    {
        private CsvImportSettings CsvImportSettings { get; set; }
        private IBulkImportRepository<Agency> DataRepository { get; set; }

        public AgencyCsvImporter
            (
                CsvImportSettings csvImportSettings,
                IBulkImportRepository<Agency> dataRepository
            )
        {
            CsvImportSettings = csvImportSettings;
            DataRepository = dataRepository;
        }
        
        public async Task<ImportResult> Import()
        {
            return await ImportCsv<Agency>(DataRepository, new AgencyMap(), CsvImportSettings,
                ImportResultType.Agency, CsvImportSettings.AgencyImportFilename);
        }

    }
}