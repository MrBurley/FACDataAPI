using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using FACDataAPI.Common.Configuration;
using FACDataAPI.Data.Import.Repositories;
using CsvHelper;
using CsvHelper.Configuration;
using FACDataAPI.Data.Import.Entities;
using FACDataAPI.Import.Csv;
using FACDataAPI.Import.CSV.Maps;

namespace FACDataAPI.Import.CSV
{
    public class CfdaCsvImporter: BaseCsvImporter, IImporter<Cfda>
    {
        private CsvImportSettings CsvImportSettings { get; set; }
        private IBulkImportRepository<Cfda> DataRepository { get; set; }

        public CfdaCsvImporter
        (
            CsvImportSettings csvImportSettings,
            IBulkImportRepository<Cfda> dataRepository
        )
        {
            CsvImportSettings = csvImportSettings;
            DataRepository = dataRepository;
        }

        public async Task<ImportResult> Import()
        {
            return await ImportCsv<Cfda>(DataRepository, new CfdaMap(), CsvImportSettings,
                ImportResultType.Cfda, CsvImportSettings.CfdaImportFilename);
        }
    }
}