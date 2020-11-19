using CsvHelper.Configuration;
using FACDataAPI.Data.Import.Entities;

namespace FACDataAPI.Import.CSV.Maps
{
    public sealed class EinMap: ClassMap<Ein>
    {
        public EinMap()
        {
            Map( m => m.AuditYear ).Index( 0 );
            Map( m => m.DbKey ).Index( 1 );
            Map( m => m.EinValue ).Index( 2 );
            Map( m => m.EinSeqNum ).Index( 3 );
        }
    }
}