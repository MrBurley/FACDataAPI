using FACDataAPI.Data.Import.Entities;
using CsvHelper.Configuration;

namespace FACDataAPI.Import.CSV.Maps
{
    public sealed class CfdaMap : ClassMap<Cfda>
    {
        public CfdaMap()
        {
            Map( m => m.Audityear ).Index( 0 );
            Map( m => m.Dbkey).Index( 1 );
            Map( m => m.Ein).Index( 2 );
            Map( m => m.CFDAValue).Index( 3 );
            Map( m => m.AwardIdentification).Index( 4 );
            Map( m => m.Rd).Index( 5 );
            Map( m => m.FederalProgramName).Index( 6 );
            Map( m => m.Amount).Index( 7 );
            Map( m => m.Clustername).Index( 8 );
            Map( m => m.StateClustername).Index( 9 );
            Map( m => m.ProgramTotal).Index( 10 );
            Map( m => m.ClusterTotal).Index( 11 );
            Map( m => m.Direct).Index( 12 );
            Map( m => m.PassthroughAward).Index( 13 );
            Map( m => m.PassthroughAmount).Index( 14 );
            Map( m => m.MajorProgram).Index( 15 );
            Map( m => m.TypeReportMP).Index( 16 );
            Map( m => m.TypeRequirement).Index( 17 );
            Map( m => m.QCosts2).Index( 18 );
            Map( m => m.Findings).Index( 19 );
            Map( m => m.FindingRefNums).Index( 20 );
            Map( m => m.ARRA).Index( 21 );
            Map( m => m.Loans).Index( 22 );
            Map( m => m.LoanBalance).Index( 23 );
            Map( m => m.FindingsCount).Index( 24 );
            Map( m => m.ElecauditsId).Index( 25 );
            Map( m => m.OtherClustername).Index( 26 );
            Map( m => m.CFDAProgramname).Index( 27 );
            
           
        }
    }
}