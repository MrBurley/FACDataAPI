using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using FACDataAPI.Common.Configuration;
using FACDataAPI.Data.Import.Entities;
using FACDataAPI.Data.Import.Repositories;
using FACDataAPI.Import.CSV.Maps;

namespace FACDataAPI.Import.Csv
{
    /// <summary>
    /// Base class for Csv specific imports
    /// </summary>
    public class BaseCsvImporter
    {
        /// <summary>
        /// Convenience method for Csv import operations
        /// </summary>
        /// <param name="importRepository">Database repository for entity</param>
        /// <param name="map">CSV Class Map for entity</param>
        /// <param name="importSettings">CSV Import Settings</param>
        /// <param name="resultType">Import Result Type</param>
        /// <param name="importFilename">Target Csv File</param>
        /// <typeparam name="TE">Entity Type</typeparam>
        /// <returns>ImportResult</returns>
        protected async Task<ImportResult> ImportCsv<TE>(IBulkImportRepository<TE> importRepository,
            ClassMap<TE> map, CsvImportSettings importSettings, ImportResultType resultType,
            string importFilename
        )
        {
            ImportResult result = new ImportResult();
            bool isRecordBad = false;
            IList<TE> recordBuffer = new List<TE>();

            result.ImportArea = resultType;
            result.ProcessStarted = DateTime.Now;


            //Clean the import repository
            await importRepository.Clean();

            //Buffer Flush function
            Func<Task> flushBuffer = async() =>
            {
                await importRepository.BulkImport(recordBuffer);
                recordBuffer.Clear();
            };
            
            //Read the csv file
            using (TextReader reader = File.OpenText(
                Path.Combine(importSettings.LocalImportDirectory,
                    importFilename)))
            {
                CsvConfiguration conf = new CsvConfiguration(CultureInfo.CurrentCulture);

                conf.Delimiter = importSettings.Delimiter;
                conf.BufferSize = importSettings.ReadBufferSize;
                conf.MissingFieldFound = null;
                conf.HasHeaderRecord = true;
                conf.AllowComments = true;
                conf.IgnoreQuotes = true;
                conf.RegisterClassMap(map);
                conf.BadDataFound = context =>
                {
                    isRecordBad = true;
                    result.BadData.Add(new Tuple<string, int>(context.RawRecord, (result.RecordsImported + 1)));
                };
                
                //Instantiate our Csv reader
                CsvReader csv = new CsvReader(reader, conf);

                //Iterate over the records and perform import
                while (await csv.ReadAsync())
                {

                    //Parse the record
                    var record = csv.GetRecord<TE>();

                    //Check to see if it isn't bad
                    if (!isRecordBad)
                    {
                        isRecordBad = false;
                        recordBuffer.Add(record);
                        result.RecordsImported++;
                        
                        //Flush the buffer to the database if threshold is reached
                        if (recordBuffer.Count == importSettings.ReadBufferSize)
                        {
                            await flushBuffer();
                        }

                    }

                }
                
                //Flush any remaining records
                await flushBuffer();

                //Set the result to true
                result.Success = true;
                result.ProcessEnded = DateTime.Now;


                return result;
            }

        }
    }
}