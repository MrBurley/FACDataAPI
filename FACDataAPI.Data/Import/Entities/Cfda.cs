namespace FACDataAPI.Data.Import.Entities
{
    public class Cfda : IImportEntity
    {
        public string Audityear { get; set; }
        public string Dbkey { get; set; }
        public string Ein { get; set; }
        public string CFDAValue { get; set; }
        public string AwardIdentification { get; set; }
        public string Rd { get; set; }
        public string FederalProgramName { get; set; }
        public string Amount { get; set; }
        public string Clustername { get; set; }
        public string StateClustername { get; set; }
        public string ProgramTotal { get; set; }
        public string ClusterTotal { get; set; }
        public string Direct { get; set; }
        public string PassthroughAward { get; set; }
        public string PassthroughAmount { get; set; }
        public string MajorProgram { get; set; }
        public string TypeReportMP { get; set; }
        public string TypeRequirement { get; set; }
        public string QCosts2 { get; set; }
        public string Findings { get; set; }
        public string FindingRefNums { get; set; }
        public string ARRA { get; set; }
        public string Loans { get; set; }
        public string LoanBalance { get; set; }
        public string FindingsCount { get; set; }
        public string ElecauditsId { get; set; }
        public string OtherClustername { get; set; }
        public string CFDAProgramname{ get; set; }
    }
}