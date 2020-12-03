namespace FACDataAPI.Data.Import.Entities
{
    public class Passthrough:IImportEntity
    {
	    public string DbKey { get; set; }
	    public string AuditYear{ get; set; } 
	    public string ElecAuditsId { get; set; }
	    public string PassthroughName{ get; set; }
	    public string PassthroughId { get; set; }
    }
}