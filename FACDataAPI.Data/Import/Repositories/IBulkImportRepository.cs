using System.Collections.Generic;
using System.Threading.Tasks;
using FACDataAPI.Data.Import.Entities;

namespace FACDataAPI.Data.Import.Repositories
{
    public interface IBulkImportRepository<T>
    {
        Task Clean();
        Task<ulong> BulkImport(IList<T> models);
        Task<long> CurrentRecords();
    }
}