namespace FACDataAPI.Common.Configuration
{
    public class CsvImportSettings
    {
        public string FtpSource { get; set; }
        public string LocalImportDirectory { get; set; }
        public int ReadBufferSize { get; set; }
        public string FacZipFilename { get; set; }
        public string RevisionImportFilename { get; set; }
        public string CapTextImportFilename { get; set; }
        public string FindingsTextImportFilename { get; set; }
        public string NotesImportFilename { get; set; }
        public string CpaImportFilename { get; set; }
        public string PassthroughImportFilename { get; set; }
        public string FindingsImportFilename { get; set; }
        public string DunsImportFilename { get; set; }
        public string EinsImportFilename { get; set; }
        public string AgencyImportFilename { get; set; }
        public string CfdaImportFilename { get; set; }
        public string GeneralImportFilename { get; set; }
        public string FormattedFindingsTextImportFilename { get; set; }
        public string FormattedCapTextImportFilename { get; set; }
        public int RecordBufferSize { get; set; }
        public string Delimiter { get; set; }
    }
}