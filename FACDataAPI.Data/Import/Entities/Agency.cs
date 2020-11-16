namespace FACDataAPI.Data.Import.Entities
{
    public class Agency: IImportEntity
    {
	    public string AuditYear { get; set; }
	    public string DbKey { get; set; }
	    public string Ein { get; set; }
	    public string AgencyNumber { get; set; }

	   
    }
}