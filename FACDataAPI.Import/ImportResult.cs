using System;
using System.Collections.Generic;
using System.Linq;
using FACDataAPI.Data.Import.Entities;

namespace FACDataAPI.Import
{

    public enum ImportResultType
    {
        Cfda = 0,
        General = 1
    }
    
    public class ImportResult
    {
        public ImportResultType ImportArea { get; set; }
        public int RecordsImported { get; set; }
        public bool Success { get; set; }
        public DateTime? ProcessStarted { get; set; }
        public DateTime? ProcessEnded { get; set; }
        public IList<Tuple<string, int>> BadData { get; set; } = new List<Tuple<string, int>>();

        public TimeSpan? ExecutionTime
        {
            get
            {

                TimeSpan? retval = null;
                
                if (ProcessStarted.HasValue && ProcessEnded.HasValue)
                {
                    retval = ProcessEnded.Value.Subtract(ProcessStarted.Value);
                }

                return retval;
            }
        }

        public ImportLog ToImportLog()
        {
            ImportLog log = new ImportLog();

            log.Area = nameof(this.ImportArea);
            log.Success = this.Success;
            log.DataErrors = (this.BadData.Count > 0);
            log.ExecutionTime = this.ExecutionTime;
            log.ImportEnded = this.ProcessStarted;
            log.ImportStarted = this.ProcessStarted;
            log.RecordsImported = this.RecordsImported;

            if (BadData.Count > 0)
            {
                IList<string> data = BadData.Select(x => x.Item1).ToList<string>();
                log.BadData = string.Join(Environment.NewLine, data);
            }
            
            return log;
        }
    }
}