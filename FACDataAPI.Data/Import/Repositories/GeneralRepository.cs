using System.Collections.Generic;
using System.Threading.Tasks;
using FACDataAPI.Data.Import.Entities;
using PostgreSQLCopyHelper;

namespace FACDataAPI.Data.Import.Repositories
{
    public class GeneralRepository: IBulkImportRepository<General>
    {
        
        private IDatabaseManager DatabaseManager { get; set; }

        public GeneralRepository(IDatabaseManager ctx)
        {
            DatabaseManager = ctx;
        }

        
        public async Task Clean()
        {
            await DatabaseManager.TruncateTable("general", "import");
        }

        public async Task<ulong> BulkImport(IList<General> models)
        {
            var copyHelper = new PostgreSQLCopyHelper<General>("import", "general")
                .MapText("audityear", x => x.AuditYear)
                .MapText("dbkey", x => x.DbKey)
                .MapText("typeofentity", x => x.TypeofEntity)
                .MapText("fyenddate", x => x.FyEndDate)
                .MapText("audittype", x => x.AuditType)
                .MapText("periodcovered", x => x.PeriodCovered)
                .MapText("numbermonths", x => x.NumberMonths)
                .MapText("ein", x => x.Ein)
                .MapText("multipleeins", x => x.MultipleEins)
                .MapText("einsubcode", x => x.EinSubcode)
                .MapText("duns", x => x.Duns)
                .MapText("multipleduns", x => x.MultipleDuns)
                .MapText("auditeename", x => x.AuditeeName)
                .MapText("street1", x => x.Street1)
                .MapText("street2", x => x.Street2)
                .MapText("city", x => x.City)
                .MapText("state", x => x.State)
                .MapText("zipcode", x => x.Zipcode)
                .MapText("auditeecontact", x => x.AuditeeContact)
                .MapText("auditeetitle", x => x.AuditeeTitle)
                .MapText("auditeephone", x => x.AuditeePhone)
                .MapText("auditeefax", x => x.AuditeeFax)
                .MapText("auditeeemail", x => x.AuditeeEmail)
                .MapText("auditeedatesigned", x => x.AuditeeDateSigned)
                .MapText("auditeenametitle", x => x.AuditeeNameTitle)
                .MapText("cpafirmname", x => x.CpaFirmname)
                .MapText("cpastreet1", x => x.CpaStreet1)
                .MapText("cpastreet2", x => x.CpaStreet2)
                .MapText("cpacity", x => x.CpaCity)
                .MapText("cpastate", x => x.CpaState)
                .MapText("cpazipcode", x => x.CpaZipcode)
                .MapText("cpacontact", x => x.CpaContact)
                .MapText("cpatitle", x => x.CpaTitle)
                .MapText("cpaphone", x => x.CpaPhone)
                .MapText("cpafax", x => x.CpaFax)
                .MapText("cpaemail", x => x.CpaEmail)
                .MapText("cpadatesigned", x => x.CpaDateSigned)
                .MapText("cog_over", x => x.CogOver)
                .MapText("cogagency", x => x.CogAgency)
                .MapText("oversightagency", x => x.OversightAgency)
                .MapText("typereport_fs", x => x.TypeReportFS)
                .MapText("sp_framework", x => x.SpFramework)
                .MapText("sp_framework_required", x => x.SpFrameworkRequired)
                .MapText("typereport_sp_framework", x => x.TypeReportSpFramework)
                .MapText("goingconcern", x => x.GoingConcern)
                .MapText("reportablecondition", x => x.ReportableCondition)
                .MapText("materialweakness", x => x.MaterialWeakness)
                .MapText("materialnoncompliance", x => x.MaterialNonCompliance)
                .MapText("typereport_mp", x => x.TypereportMP)
                .MapText("dup_reports", x => x.DupReports)
                .MapText("dollarthreshold", x => x.DollarThreshold)
                .MapText("lowrisk", x => x.Lowrisk)
                .MapText("reportablecondition_mp", x => x.ReportableConditionMP)
                .MapText("materialweakness_mp", x => x.MaterialWeaknessMP)
                .MapText("qcosts", x => x.Qcosts)
                .MapText("cyfindings", x => x.CyFindings)
                .MapText("pyschedule", x => x.PySchedule)
                .MapText("totfedexpend", x => x.TotFedExpend)
                .MapText("datefirewall", x => x.DateFirewall)
                .MapText("previousdatefirewall", x => x.PreviousDateFirewall)
                .MapText("reportrequired", x => x.ReportRequired)
                .MapText("multiple_cpas", x => x.MultipleCpas)
                .MapText("auditor_ein", x => x.AuditorEin)
                .MapText("facaccepteddate", x => x.FacAcceptedDate)
                .MapText("cpaforeign", x => x.CpaForeign)
                .MapText("cpacountry", x => x.CpaCountry);
            
            return await DatabaseManager.DoBulkImport(copyHelper, models);
        }

        public async Task<long> CurrentRecords()
        {
            return await DatabaseManager.TableRowCount("general", "import");
        }
    }
}