using FACDataAPI.Data.Import.Entities;
using System.Threading.Tasks;
using FACDataAPI.Common.Configuration;
using FACDataAPI.Data.Import.Repositories;
using FACDataAPI.Import.CSV.Maps;

namespace FACDataAPI.Import.Csv
{
    public class FormattedFindingTextCsvImporter: BaseCsvImporter, IImporter<FormattedFindingsText>
    {
        private CsvImportSettings CsvImportSettings { get; set; }
        private IBulkImportRepository<FormattedFindingsText> DataRepository { get; set; }

        public FormattedFindingTextCsvImporter
        (
            CsvImportSettings csvImportSettings,
            IBulkImportRepository<FormattedFindingsText> dataRepository
        )
        {
            CsvImportSettings = csvImportSettings;
            DataRepository = dataRepository;
        }
        
        public async Task<ImportResult> Import()
        {
            return await ImportCsv<FormattedFindingsText>(DataRepository, new FormattedFindingTextMap(), CsvImportSettings,
                ImportResultType.FormattedFindingsText, CsvImportSettings.FormattedFindingsTextImportFilename);
        }

    }
}