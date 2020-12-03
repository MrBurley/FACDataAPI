using CsvHelper.Configuration;
using FACDataAPI.Data.Import.Entities;

namespace FACDataAPI.Import.CSV.Maps
{
    public sealed class FindingTextMap:ClassMap<FindingText>
    {
        public FindingTextMap()
        {
            Map( m => m.SequenceNumber ).Index( 0 );
            Map( m => m.DbKey ).Index( 1 );
            Map( m => m.AuditYear ).Index( 2 );
            Map( m => m.FindingReferenceNumbers ).Index( 3 );
            Map( m => m.Text ).Index( 4 );
            Map( m => m.ChartsTables ).Index( 5 );
            
        }
    }
}