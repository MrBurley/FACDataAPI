namespace FACDataAPI.Data.Import.Entities
{
    public class Finding: IImportEntity
    {
	    public string DbKey { get; set; }
	    public string AuditYear { get; set; }
	    public string ElecAuditsId { get; set; }
	    public string ElecAuditFindingsId{ get; set; }
	    public string FindingReferenceNumbers { get; set; }
	    public string TypeRequirement { get; set; }
	    public string ModifiedOpinion { get; set; }
	    public string OtherNonCompliance { get; set; }
	    public string MaterialWeakness { get; set; }
	    public string SignificantDeficiency{ get; set; }
	    public string OtherFindings{ get; set; }
	    public string QuestionedCosts { get; set; }
	    public string RepeatFinding { get; set; }
	    public string PriorFindingReferenceNumbers{ get; set; }
	    
    }
}