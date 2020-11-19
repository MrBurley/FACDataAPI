using CsvHelper.Configuration;
using FACDataAPI.Data.Import.Entities;

namespace FACDataAPI.Import.CSV.Maps
{
    public sealed class FindingMap: ClassMap<Finding>
    {
        public FindingMap()
        {
            Map( m => m.DbKey ).Index( 0 );
            Map( m => m.AuditYear ).Index( 1 );
            Map( m => m.ElecAuditsId ).Index( 2 );
            Map( m => m.ElecAuditFindingsId ).Index( 3 );
            Map( m => m.FindingReferenceNumbers ).Index( 4 );
            Map( m => m.TypeRequirement ).Index( 5 );
            Map( m => m.ModifiedOpinion ).Index( 6 );
            Map( m => m.OtherNonCompliance ).Index( 7 );
            Map( m => m.MaterialWeakness ).Index( 8 );
            Map( m => m.SignificantDeficiency ).Index( 9 );
            Map( m => m.OtherFindings ).Index( 10 );
            Map( m => m.QuestionedCosts ).Index( 11 );
            Map( m => m.RepeatFinding ).Index( 12 );
            Map( m => m.PriorFindingReferenceNumbers ).Index( 13 );
            
        }
    }
}