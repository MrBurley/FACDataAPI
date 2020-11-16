using CsvHelper.Configuration;
using FACDataAPI.Data.Import.Entities;

namespace FACDataAPI.Import.CSV.Maps
{
    public sealed class AgencyMap: ClassMap<Agency>
    {
        public AgencyMap()
        {
            Map( m => m.AuditYear ).Index( 0 );
            Map( m => m.DbKey ).Index( 1 );
            Map( m => m.Ein ).Index( 2 );
            Map( m => m.AgencyNumber ).Index( 3 );
        }
        
        
    }
}