using System.Data;
using System.Threading.Tasks;
using FACDataAPI.Data.Import.Entities;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using Npgsql;

namespace FACDataAPI.Data.Import.Repositories
{
    
    public interface IImportLogRepository
    {
        public Task<long> Save(ImportLog log);
    }
    
    public class ImportLogRepository: IImportLogRepository
    {
        public IDatabaseManager DatabaseManager { get; set; }

        public ImportLogRepository
            (
                IDatabaseManager databaseManager
            )
        {
            DatabaseManager = databaseManager;
        }
        
        public async Task<long> Save(ImportLog log)
        {
            long retval = 0;
            
            using (IDbConnection cn = await DatabaseManager.OpenAsAsync())
            {
                retval = cn.Insert<ImportLog>(log);
            }

            return retval;
        }
    }
}