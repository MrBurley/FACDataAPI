using System.Collections.Generic;
using System.Threading.Tasks;
using FACDataAPI.Data.Import.Entities;
using PostgreSQLCopyHelper;

namespace FACDataAPI.Data.Import.Repositories
{
    public class EinRepository: IBulkImportRepository<Ein>
    {
        private IDatabaseManager DatabaseManager { get; set; }

        
        public EinRepository(IDatabaseManager ctx)
        {
            DatabaseManager = ctx;
        }
        
        public async Task Clean()
        {
            await DatabaseManager.TruncateTable("eins", "import");
        }

        public async Task<ulong> BulkImport(IList<Ein> models)
        {
            var copyHelper = new PostgreSQLCopyHelper<Ein>("import", "eins")
                .MapText("audityear", x => x.AuditYear)
                .MapText("dbkey", x => x.DbKey)
                .MapText("ein", x => x.EinValue)
                .MapText("einseqnum", x => x.EinSeqNum);
            
            
            
            return await DatabaseManager.DoBulkImport(copyHelper, models);    
        }

        public async Task<long> CurrentRecords()
        {
            return await DatabaseManager.TableRowCount("eins", "import");
        }
    }
}