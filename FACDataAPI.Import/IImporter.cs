using System.Threading.Tasks;
using FACDataAPI.Data.Import.Entities;

namespace FACDataAPI.Import
{
    public interface IImporter<T> where T: IImportEntity
    {
        Task<ImportResult> Import();
    }
    
    
}