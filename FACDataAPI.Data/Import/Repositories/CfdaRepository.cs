using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using FACDataAPI.Data.Import.Entities;
using Npgsql;
using PostgreSQLCopyHelper;

namespace FACDataAPI.Data.Import.Repositories
{
    
    public class CfdaRepository: IBulkImportRepository<Cfda>
    {
        private IDatabaseManager DatabaseManager { get; set; }

        public CfdaRepository(IDatabaseManager ctx)
        {
            DatabaseManager = ctx;
        }

        public async Task Clean()
        {
            await DatabaseManager.TruncateTable("cfdas", "import");
        }

        public async Task<ulong> BulkImport(IList<Cfda> models)
        {
            var copyHelper = new PostgreSQLCopyHelper<Cfda>("import", "cfdas")
                .MapText("audityear", x => x.Audityear)
                .MapText("dbkey", x => x.Dbkey)
                .MapText("ein", x => x.Ein)
                .MapText("cfda", x => x.CFDAValue)
                .MapText("awardidentification", x => x.AwardIdentification)
                .MapText("rd", x => x.Rd)
                .MapText("federalprogramname", x => x.FederalProgramName)
                .MapText("amount", x => x.Amount)
                .MapText("clustername", x => x.Clustername)
                .MapText("stateclustername", x => x.StateClustername)
                .MapText("programtotal", x => x.ProgramTotal)
                .MapText("clustertotal", x => x.Clustername)
                .MapText("direct", x => x.Direct)
                .MapText("passthroughaward", x => x.PassthroughAward)
                .MapText("passthroughamount", x => x.PassthroughAmount)
                .MapText("majorprogram", x => x.MajorProgram)
                .MapText("typereport_mp", x => x.TypeReportMP)
                .MapText("typerequirement", x => x.TypeRequirement)
                .MapText("qcosts2", x => x.QCosts2)
                .MapText("findings", x => x.Findings)
                .MapText("findingrefnums", x => x.FindingRefNums)
                .MapText("arra", x => x.ARRA)
                .MapText("loans", x => x.Loans)
                .MapText("loanbalance", x => x.LoanBalance)
                .MapText("findingscount", x => x.FindingsCount)
                .MapText("elecauditsid", x => x.ElecauditsId)
                .MapText("otherclustername", x => x.OtherClustername)
                .MapText("cfdaprogramname", x => x.CFDAProgramname);

            return await DatabaseManager.DoBulkImport(copyHelper, models);
        }

        public async Task<long> CurrentRecords()
        {
            return await DatabaseManager.TableRowCount("cfdas", "import");
        }
    }
}