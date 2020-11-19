namespace FACDataAPI.Data.Import.Entities
{
    public class Dun: IImportEntity
    {
	    public string AuditYear { get; set; }
	    public string DbKey { get; set; }
	    public string DunValue { get; set; }
	    public string DunSeqNum { get; set; }
	    
    }
}