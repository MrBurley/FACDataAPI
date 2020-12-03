using CsvHelper.Configuration;
using FACDataAPI.Data.Import.Entities;

namespace FACDataAPI.Import.CSV.Maps
{
    public sealed class PassthroughMap: ClassMap<Passthrough>
    {
        public PassthroughMap()
        {
            Map( m => m.DbKey ).Index( 0 );
            Map( m => m.AuditYear ).Index( 1 );
            Map( m => m.ElecAuditsId ).Index( 2 );
            Map( m => m.PassthroughName ).Index( 3 );
            Map( m => m.PassthroughId ).Index( 4 );
            
        }
    }
}