using CsvHelper.Configuration;
using FACDataAPI.Data.Import.Entities;

namespace FACDataAPI.Import.CSV.Maps
{
    public sealed class DunMap: ClassMap<Dun>
    {
        public DunMap()
        {
            Map( m => m.AuditYear ).Index( 0 );
            Map( m => m.DbKey ).Index( 1 );
            Map( m => m.DunValue ).Index( 2 );
            Map( m => m.DunSeqNum ).Index( 3 );
        }
    }
}