using CsvHelper.Configuration;
using FACDataAPI.Data.Import.Entities;

namespace FACDataAPI.Import.CSV.Maps
{
    public sealed class CpaMap: ClassMap<Cpa>
    {
        public CpaMap()
        {
            Map( m => m.DbKey ).Index( 0 );
            Map( m => m.AuditYear ).Index( 1 );
            Map( m => m.Firmname ).Index( 2 );
            Map( m => m.Ein ).Index( 3 );
            Map( m => m.Street1 ).Index( 4 );
            Map( m => m.City ).Index( 5 );
            Map( m => m.State ).Index( 6 );
            Map( m => m.Zip ).Index( 7 );
            Map( m => m.Contact ).Index( 8 );
            Map( m => m.Title ).Index( 9 );
            Map( m => m.Phone ).Index( 10 );
            Map( m => m.Fax ).Index( 11 );
            Map( m => m.Email ).Index( 12 );
            
        }
    }
}