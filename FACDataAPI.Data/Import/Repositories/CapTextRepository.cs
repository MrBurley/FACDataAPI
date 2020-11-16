using System.Collections.Generic;
using System.Threading.Tasks;
using FACDataAPI.Data.Import.Entities;
using PostgreSQLCopyHelper;

namespace FACDataAPI.Data.Import.Repositories
{
    public class CapTextRepository: IBulkImportRepository<CapText>
    {
        private IDatabaseManager DatabaseManager { get; set; }

        
        public CapTextRepository(IDatabaseManager ctx)
        {
            DatabaseManager = ctx;
        }
        
        public async Task Clean()
        {
            await DatabaseManager.TruncateTable("captext", "import");
        }

        public async Task<ulong> BulkImport(IList<CapText> models)
        {
            var copyHelper = new PostgreSQLCopyHelper<CapText>("import", "captext")
                .MapText("seq_number", x => x.SeqNumber)
                .MapText("dbkey", x => x.DbKey)
                .MapText("audityear", x => x.AuditYear)
                .MapText("findingrefnums", x => x.FindingReferenceNumbers)
                .MapText("text", x => x.Text)
                .MapText("chartstables", x => x.ChartsTables);
            
                
            return await DatabaseManager.DoBulkImport(copyHelper, models);    
        }

        public async Task<long> CurrentRecords()
        {
            return await DatabaseManager.TableRowCount("captext", "import");
        }
    }
}