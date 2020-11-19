namespace FACDataAPI.Data.Import.Entities
{
    public class Ein: IImportEntity
    {
        public string AuditYear { get; set; }
        public string DbKey { get; set; }
        public string EinValue { get; set; }
        public string EinSeqNum { get; set; }
    }
}