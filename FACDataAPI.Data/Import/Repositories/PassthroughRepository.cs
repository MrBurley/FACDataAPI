using FACDataAPI.Data.Import.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using PostgreSQLCopyHelper;

namespace FACDataAPI.Data.Import.Repositories
{
    public class PassthroughRepository: IBulkImportRepository<Passthrough>
    {
        private IDatabaseManager DatabaseManager { get; set; }

        
        public PassthroughRepository(IDatabaseManager ctx)
        {
            DatabaseManager = ctx;
        }
        
        public async Task Clean()
        {
            await DatabaseManager.TruncateTable("passthrough", "import");
        }

        public async Task<ulong> BulkImport(IList<Passthrough> models)
        {
            var copyHelper = new PostgreSQLCopyHelper<Passthrough>("import", "passthrough")
                .MapText("dbkey", x => x.DbKey)
                .MapText("audityear", x => x.AuditYear)
                .MapText("elecauditsid", x => x.ElecAuditsId)
                .MapText("passthroughname", x => x.PassthroughName)
                .MapText("passthroughid", x => x.PassthroughId);

            return await DatabaseManager.DoBulkImport(copyHelper, models);    
        }

        public async Task<long> CurrentRecords()
        {
            return await DatabaseManager.TableRowCount("passthrough", "import");
        }
    }
}