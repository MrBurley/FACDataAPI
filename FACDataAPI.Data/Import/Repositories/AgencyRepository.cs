using System.Collections.Generic;
using System.Threading.Tasks;
using FACDataAPI.Data.Import.Entities;
using PostgreSQLCopyHelper;


namespace FACDataAPI.Data.Import.Repositories
{
    public class AgencyRepository: IBulkImportRepository<Agency>
    {

        private IDatabaseManager DatabaseManager { get; set; }

        
        public AgencyRepository(IDatabaseManager ctx)
        {
            DatabaseManager = ctx;
        }
        
        public async Task Clean()
        {
            await DatabaseManager.TruncateTable("agencies", "import");
        }

        public async Task<ulong> BulkImport(IList<Agency> models)
        {
            var copyHelper = new PostgreSQLCopyHelper<Agency>("import", "agencies")
                .MapText("audityear", x => x.AuditYear)
                .MapText("dbkey", x => x.DbKey)
                .MapText("ein", x => x.Ein)
                .MapText("agency", x => x.AgencyNumber);
            
            return await DatabaseManager.DoBulkImport(copyHelper, models);    
        }

        public async Task<long> CurrentRecords()
        {
            return await DatabaseManager.TableRowCount("agencies", "import");
        }
    }
}