using Dapper;

namespace FACDataAPI.Data.Import.Entities
{
    public class Cpa: IImportEntity
    {
	    public string DbKey { get; set; }
	    public string AuditYear { get; set; }
	    public string Firmname { get; set; }
	    public string Ein { get; set; }
	    public string Street1 { get; set; }
	    public string City { get; set; }
	    public string State { get; set; }
	    public string Zip { get; set; }
	    public string Contact { get; set; }
	    public string Title { get; set; }
	    public string Phone { get; set; }
	    public string Fax { get; set; }
	    public string Email { get; set; }

	    
    }
}