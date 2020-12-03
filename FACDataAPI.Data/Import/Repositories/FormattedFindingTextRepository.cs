using System.Collections.Generic;
using System.Threading.Tasks;
using FACDataAPI.Data.Import.Entities;
using PostgreSQLCopyHelper;

namespace FACDataAPI.Data.Import.Repositories
{
    public class FormattedFindingTextRepository: IBulkImportRepository<FormattedFindingsText>
    {
        private IDatabaseManager DatabaseManager { get; set; }

        
        public FormattedFindingTextRepository(IDatabaseManager ctx)
        {
            DatabaseManager = ctx;
        }
        
        public async Task Clean()
        {
            await DatabaseManager.TruncateTable("formattedfindingstext", "import");
        }

        public async Task<ulong> BulkImport(IList<FormattedFindingsText> models)
        {
            var copyHelper = new PostgreSQLCopyHelper<FormattedFindingsText>("import", "formattedfindingstext")
                .MapText("seq_number", x => x.SequenceNumber)
                .MapText("dbkey", x => x.DbKey)
                .MapText("audityear", x => x.AuditYear)
                .MapText("findingrefnums", x => x.FindingReferenceNumbers)
                .MapText("text", x => x.Text)
                .MapText("chartstables", x => x.ChartsTables);
            
            
            return await DatabaseManager.DoBulkImport(copyHelper, models);    
        }

        public async Task<long> CurrentRecords()
        {
            return await DatabaseManager.TableRowCount("formattedfindingstext", "import");
        }
    }
}