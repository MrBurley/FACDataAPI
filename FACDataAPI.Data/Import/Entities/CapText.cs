namespace FACDataAPI.Data.Import.Entities
{
    public class CapText: IImportEntity
    {
        public string SeqNumber { get; set; }
        public string DbKey { get; set; }
        public string AuditYear { get; set; }
        public string FindingReferenceNumbers { get; set; }
        public string Text { get; set; }
        public string ChartsTables { get; set; }
        
        
    }
}