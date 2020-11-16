using CsvHelper.Configuration;
using FACDataAPI.Data.Import.Entities;

namespace FACDataAPI.Import.CSV.Maps
{
    public sealed class CapTextMap: ClassMap<CapText>
    {
        public CapTextMap()
        {
            Map( m => m.SeqNumber ).Index( 0 );
            Map( m => m.DbKey).Index( 1);
            Map( m => m.AuditYear ).Index( 2 );
            Map( m => m.FindingReferenceNumbers ).Index( 3);
            Map( m => m.Text ).Index( 4 );
            Map( m => m.ChartsTables ).Index( 5 );
        }
    }
}