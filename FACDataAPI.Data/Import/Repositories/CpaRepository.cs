using System.Collections.Generic;
using System.Threading.Tasks;
using FACDataAPI.Data.Import.Entities;
using PostgreSQLCopyHelper;

namespace FACDataAPI.Data.Import.Repositories
{
    public class CpaRepository: IBulkImportRepository<Cpa>
    {
        private IDatabaseManager DatabaseManager { get; set; }

        
        public CpaRepository(IDatabaseManager ctx)
        {
            DatabaseManager = ctx;
        }
        
        public async Task Clean()
        {
            await DatabaseManager.TruncateTable("cpas", "import");
        }

        public async Task<ulong> BulkImport(IList<Cpa> models)
        {
            var copyHelper = new PostgreSQLCopyHelper<Cpa>("import", "cpas")
                .MapText("dbkey", x => x.DbKey)
                .MapText("audityear", x => x.AuditYear)
                .MapText("cpafirmname", x => x.Firmname)
                .MapText("cpaein", x => x.Ein)
                .MapText("cpastreet1", x => x.Street1)
                .MapText("cpacity", x => x.City)
                .MapText("cpastate", x => x.State)
                .MapText("cpazipcode", x => x.Zip)
                .MapText("cpacontact", x => x.Contact)
                .MapText("cpatitle", x => x.Title)
                .MapText("cpaphone", x => x.Phone)
                .MapText("cpafax", x => x.Fax)
                .MapText("cpaemail", x => x.Email);
            
            
            return await DatabaseManager.DoBulkImport(copyHelper, models);    
        }

        public async Task<long> CurrentRecords()
        {
            return await DatabaseManager.TableRowCount("cpas", "import");
        }
    }
}