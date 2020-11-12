using CsvHelper.Configuration;
using FACDataAPI.Data.Import.Entities;

namespace FACDataAPI.Import.CSV.Maps
{
    public sealed class GeneralMap: ClassMap<General>
    {
        public GeneralMap()
        {
            Map( m => m.AuditYear ).Index( 0 );
            Map( m => m.DbKey ).Index( 1 );
            Map( m => m.TypeofEntity ).Index( 2 );
            Map( m => m.FyEndDate ).Index( 3 );
            Map( m => m.AuditType).Index( 4 );
            Map( m => m.PeriodCovered).Index( 5 );
            Map( m => m.NumberMonths).Index( 6 );
            Map( m => m.Ein).Index( 7 );
            Map( m => m.MultipleEins).Index( 8 );
            Map( m => m.EinSubcode).Index( 9 );
            Map( m => m.Duns).Index( 10 );
            Map( m => m.MultipleDuns).Index( 11 );
            Map( m => m.AuditeeName).Index( 12 );
            Map( m => m.Street1).Index( 13 );
            Map( m => m.Street2).Index( 14 );
            Map( m => m.City).Index( 15 );
            Map( m => m.State).Index( 16 );
            Map( m => m.Zipcode).Index( 17 );
            Map( m => m.AuditeeContact).Index( 18 );
            Map( m => m.AuditeeTitle).Index( 19 );
            Map( m => m.AuditeePhone).Index( 20 );
            Map( m => m.AuditeeFax).Index( 21 );
            Map( m => m.AuditeeEmail).Index( 22 );
            Map( m => m.AuditeeDateSigned).Index( 23 );
            Map( m => m.AuditeeNameTitle).Index( 24 );
            Map( m => m.CpaFirmname).Index( 25 );
            Map( m => m.CpaStreet1).Index( 26 );
            Map( m => m.CpaStreet2).Index( 27 );
            Map( m => m.CpaCity).Index( 28 );
            Map( m => m.CpaState).Index( 29 );
            Map( m => m.CpaZipcode).Index( 30 );
            Map( m => m.CpaContact).Index( 31 );
            Map( m => m.CpaTitle).Index( 32 );
            Map( m => m.CpaPhone).Index( 33 );
            Map( m => m.CpaFax).Index( 34 );
            Map( m => m.CpaEmail).Index( 35 );
            Map( m => m.CpaDateSigned).Index( 36 );
            Map( m => m.CogOver).Index( 37 );
            Map( m => m.CogAgency).Index( 38 );
            Map( m => m.OversightAgency).Index( 39 );
            Map( m => m.TypeReportFS).Index( 40 );
            Map( m => m.SpFramework).Index( 41 );
            Map( m => m.SpFrameworkRequired).Index( 42 );
            Map( m => m.TypeReportSpFramework).Index( 43 );
            Map( m => m.GoingConcern).Index( 44 );
            Map( m => m.ReportableCondition).Index( 45 );
            Map( m => m.MaterialWeakness).Index( 46 );
            Map( m => m.MaterialNonCompliance).Index( 47 );
            Map( m => m.TypereportMP).Index( 48 );
            Map( m => m.DupReports).Index( 49 );
            Map( m => m.DollarThreshold).Index( 50 );
            Map( m => m.Lowrisk).Index( 51 );
            Map( m => m.ReportableConditionMP).Index( 52 );
            Map( m => m.MaterialWeaknessMP).Index( 53 );
            Map( m => m.Qcosts).Index( 54 );
            Map( m => m.CyFindings).Index( 55 );
            Map( m => m.PySchedule).Index( 56 );
            Map( m => m.TotFedExpend).Index( 57 );
            Map( m => m.DateFirewall).Index( 58 );
            Map( m => m.PreviousDateFirewall).Index( 59 );
            Map( m => m.ReportRequired).Index( 60 );
            Map( m => m.MultipleCpas).Index( 61 );
            Map( m => m.AuditorEin).Index( 62 );
            Map( m => m.FacAcceptedDate).Index( 63 );
            Map( m => m.CpaForeign).Index( 64 );
            Map( m => m.CpaCountry).Index( 65 );
            
        }
    }
}