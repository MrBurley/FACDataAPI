using FACDataAPI.Data.Import.Entities;
using System.Threading.Tasks;
using FACDataAPI.Common.Configuration;
using FACDataAPI.Data.Import.Repositories;
using FACDataAPI.Import.CSV.Maps;

namespace FACDataAPI.Import.Csv
{
    public class FormattedCapTextImporter: BaseCsvImporter, IImporter<FormattedCapText>
    {
        private CsvImportSettings CsvImportSettings { get; set; }
        private IBulkImportRepository<FormattedCapText> DataRepository { get; set; }

        public FormattedCapTextImporter
        (
            CsvImportSettings csvImportSettings,
            IBulkImportRepository<FormattedCapText> dataRepository
        )
        {
            CsvImportSettings = csvImportSettings;
            DataRepository = dataRepository;
        }
        
        public async Task<ImportResult> Import()
        {
            return await ImportCsv<FormattedCapText>(DataRepository, new FormattedCapTextMap(), CsvImportSettings,
                ImportResultType.FormattedCapText, CsvImportSettings.FormattedCapTextImportFilename);
        }

    }
}