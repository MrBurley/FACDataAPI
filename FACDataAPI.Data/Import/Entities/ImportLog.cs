using System;

namespace FACDataAPI.Data.Import.Entities
{
    public class ImportLog
    {
        public long Id { get; set; }
        public string Area { get; set; }
        public long RecordsImported { get; set; }
        public bool Success { get; set; }
        public bool DataErrors { get; set; }
        public string BadData { get; set; }
        public DateTime? ImportStarted { get; set; }
        public DateTime? ImportEnded { get; set; }
        public TimeSpan? ExecutionTime { get; set; }

        
    }
}