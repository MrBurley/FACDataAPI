namespace FACDataAPI.Data.Import.Entities
{
    public class General: IImportEntity
    { 
        public string AuditYear { get; set; }
        public string DbKey { get; set; }
        public string TypeofEntity { get; set; }
        public string FyEndDate { get; set; }
        public string AuditType { get; set; }
        public string PeriodCovered { get; set; }
        public string NumberMonths { get; set; }
        public string Ein { get; set; }
        public string MultipleEins { get; set; }
        public string EinSubcode { get; set; }
        public string Duns { get; set; }
        public string MultipleDuns { get; set; }
        public string AuditeeName { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string AuditeeContact { get; set; }
        public string AuditeeTitle { get; set; }
        public string AuditeePhone { get; set; }
        public string AuditeeFax { get; set; }
        public string AuditeeEmail { get; set; }
        public string AuditeeDateSigned { get; set; }
        public string AuditeeNameTitle { get; set; }
        public string CpaFirmname { get; set; }
        public string CpaStreet1 { get; set; }
        public string CpaStreet2 { get; set; }
        public string CpaCity { get; set; }
        public string CpaState { get; set; }
        public string CpaZipcode { get; set; }
        public string CpaContact { get; set; }
        public string CpaTitle { get; set; }
        public string CpaPhone { get; set; }
        public string CpaFax { get; set; }
        public string CpaEmail { get; set; }
        public string CpaDateSigned { get; set; }
        public string CogOver { get; set; }
        public string CogAgency { get; set; }
        public string OversightAgency { get; set; }
        public string TypeReportFS { get; set; }
        public string GoingConcern { get; set; }
        public string ReportableCondition { get; set; }
        public string MaterialWeakness { get; set; }
        public string MaterialNonCompliance { get; set; }
        public string TypereportMP { get; set; }
        public string DupReports { get; set; }
        public string DollarThreshold { get; set; }
        public string Lowrisk { get; set; }
        public string ReportableConditionMP { get; set; }
        public string MaterialWeaknessMP { get; set; }
        public string Qcosts { get; set; }
        public string CyFindings { get; set; }
        public string PySchedule { get; set; }
        public string TotFedExpend { get; set; }
        public string DateFirewall { get; set; }
        public string PreviousDateFirewall { get; set; }
        public string ReportRequired { get; set; }
        public string MultipleCpas { get; set; }
        public string AuditorEin { get; set; }
        public string FacAcceptedDate { get; set; }
        public string SpFramework { get; set; }
        public string SpFrameworkRequired { get; set; }
        public string TypeReportSpFramework { get; set; }
        public string CpaForeign{ get; set; }
        public string CpaCountry{ get; set; }
    }
}