using System.Collections.Generic;
using System.Threading.Tasks;
using FACDataAPI.Data.Import.Entities;
using PostgreSQLCopyHelper;

namespace FACDataAPI.Data.Import.Repositories
{
    public class DunRepository: IBulkImportRepository<Dun>
    {
        private IDatabaseManager DatabaseManager { get; set; }

        
        public DunRepository(IDatabaseManager ctx)
        {
            DatabaseManager = ctx;
        }
        
        public async Task Clean()
        {
            await DatabaseManager.TruncateTable("duns", "import");
        }

        public async Task<ulong> BulkImport(IList<Dun> models)
        {
            var copyHelper = new PostgreSQLCopyHelper<Dun>("import", "duns")
                .MapText("audityear", x => x.AuditYear)
                .MapText("dbkey", x => x.DbKey)
                .MapText("duns", x => x.DunValue)
                .MapText("dunseqnum", x => x.DunSeqNum);
            
            return await DatabaseManager.DoBulkImport(copyHelper, models);    
        }

        public async Task<long> CurrentRecords()
        {
            return await DatabaseManager.TableRowCount("duns", "import");
        }
    }
}