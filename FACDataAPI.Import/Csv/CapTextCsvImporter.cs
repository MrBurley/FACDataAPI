using System.Threading.Tasks;
using FACDataAPI.Common.Configuration;
using FACDataAPI.Data.Import.Entities;
using FACDataAPI.Data.Import.Repositories;
using FACDataAPI.Import.CSV.Maps;

namespace FACDataAPI.Import.Csv
{
    public class CapTextCsvImporter:BaseCsvImporter, IImporter<CapText>
    {
        private CsvImportSettings CsvImportSettings { get; set; }
        private IBulkImportRepository<CapText> DataRepository { get; set; }

        public CapTextCsvImporter
        (
            CsvImportSettings csvImportSettings,
            IBulkImportRepository<CapText> dataRepository
        )
        {
            CsvImportSettings = csvImportSettings;
            DataRepository = dataRepository;
        }
        
        public async Task<ImportResult> Import()
        {
            return await ImportCsv<CapText>(DataRepository, new CapTextMap(), CsvImportSettings,
                ImportResultType.CapText, CsvImportSettings.CapTextImportFilename);
        }

    }
}