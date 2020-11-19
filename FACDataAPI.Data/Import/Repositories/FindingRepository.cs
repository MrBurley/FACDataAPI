using System.Collections.Generic;
using System.Threading.Tasks;
using FACDataAPI.Data.Import.Entities;
using PostgreSQLCopyHelper;

namespace FACDataAPI.Data.Import.Repositories
{
    public class FindingRepository: IBulkImportRepository<Finding>
    {
        private IDatabaseManager DatabaseManager { get; set; }

        
        public FindingRepository(IDatabaseManager ctx)
        {
            DatabaseManager = ctx;
        }
        
        public async Task Clean()
        {
            await DatabaseManager.TruncateTable("findings", "import");
        }

        public async Task<ulong> BulkImport(IList<Finding> models)
        {
            var copyHelper = new PostgreSQLCopyHelper<Finding>("import", "findings")
                .MapText("dbkey", x => x.DbKey)
                .MapText("audityear", x => x.AuditYear)
                .MapText("elecauditsid", x => x.ElecAuditsId)
                .MapText("elecauditfindingsid", x => x.ElecAuditFindingsId)
                .MapText("findingsrefnums", x => x.FindingReferenceNumbers)
                .MapText("typerequirement", x => x.TypeRequirement)
                .MapText("modifiedopinion", x => x.ModifiedOpinion)
                .MapText("othernoncompliance", x => x.OtherNonCompliance)
                .MapText("materialweakness", x => x.MaterialWeakness)
                .MapText("significantdeficiency", x => x.SignificantDeficiency)
                .MapText("otherfindings", x => x.OtherFindings)
                .MapText("qcosts", x => x.QuestionedCosts)
                .MapText("repeatfinding", x => x.RepeatFinding)
                .MapText("priorfindingrefnums", x => x.PriorFindingReferenceNumbers);
            
            
            return await DatabaseManager.DoBulkImport(copyHelper, models);    
        }

        public async Task<long> CurrentRecords()
        {
            return await DatabaseManager.TableRowCount("findings", "import");
        }
    }
}