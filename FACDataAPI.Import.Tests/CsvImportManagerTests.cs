using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using FACDataAPI.Common.Configuration;
using FACDataAPI.Common.Http;
using FACDataAPI.Common.IO;
using FACDataAPI.Data;
using FACDataAPI.Data.Import.Repositories;
using FACDataAPI.Import.CSV;
using Microsoft.Extensions.DependencyInjection;
using FACDataAPI.Common.Tests;
using FACDataAPI.Data.Import.Entities;
using FACDataAPI.Import.Csv;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace FACDataAPI.Import.Tests
{
    public class CsvImportManagerTests
    {
        private ServiceProvider ServiceProvider { get; set; }

        private CsvImportSettings CsvImportSettings { get; set; }
        private DatabaseSettings DatabaseSettings { get; set; }

        [SetUp]
        public void Initialize()
        {
            CsvImportSettings = TestConfigurationHelper.GetCsvImportSettings(TestContext.CurrentContext.TestDirectory);
            DatabaseSettings = TestConfigurationHelper.GetDatabaseSettings(TestContext.CurrentContext.TestDirectory);
            
            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<DatabaseSettings>(s => DatabaseSettings);
            services.AddSingleton<CsvImportSettings>(s => CsvImportSettings);
            services.AddTransient<IDatabaseManager, DatabaseManager>();
            services.AddTransient<IFileDownloadUtilities, FileDownloadUtilities>();
            services.AddTransient<IZipUtility, ZipUtility>();
            services.AddTransient<IBulkImportRepository<Cfda>, CfdaRepository>();
            services.AddTransient<IBulkImportRepository<General>, GeneralRepository>();
            services.AddTransient<IBulkImportRepository<Agency>, AgencyRepository>();
            services.AddTransient<IBulkImportRepository<CapText>, CapTextRepository>();
            services.AddTransient<IBulkImportRepository<Cpa>, CpaRepository>();
            services.AddTransient<IBulkImportRepository<Dun>, DunRepository>();
            services.AddTransient<IBulkImportRepository<Ein>, EinRepository>();
            services.AddTransient<IBulkImportRepository<Finding>, FindingRepository>();
            services.AddTransient<IBulkImportRepository<Passthrough>, PassthroughRepository>();
            services.AddTransient<IBulkImportRepository<FindingText>, FindingTextRepository>();
            services.AddTransient<IBulkImportRepository<FormattedCapText>, FormattedCapTextRepository>();
            services.AddTransient<IBulkImportRepository<FormattedFindingsText>, FormattedFindingTextRepository>();
            services.AddTransient<IImporter<Cfda>, CfdaCsvImporter>();
            services.AddTransient<IImporter<General>, GeneralCsvImporter>();
            services.AddTransient<IImporter<Agency>, AgencyCsvImporter>();
            services.AddTransient<IImporter<CapText>, CapTextCsvImporter>();
            services.AddTransient<IImporter<Cpa>, CpaCsvImporter>();
            services.AddTransient<IImporter<Dun>, DunCsvImporter>();
            services.AddTransient<IImporter<Ein>, EinCsvImporter>();
            services.AddTransient<IImporter<Finding>, FindingCsvImporter>();
            services.AddTransient<IImporter<FindingText>, FindingTextCsvImporter>();
            services.AddTransient<IImporter<FormattedCapText>, FormattedCapTextImporter>();
            services.AddTransient<IImporter<FormattedFindingsText>, FormattedFindingTextCsvImporter>();
            services.AddTransient<IImporter<Passthrough>, PassthroughCsvImporter>();
            services.AddTransient<IImportManager, CsvImportManager>();
         

            ServiceProvider = services.BuildServiceProvider();
            
            
        }

        
        [Test]
        public async Task TestPerformImport()
        {

            IImportManager importManager = ServiceProvider.GetService<IImportManager>();
            CsvImportSettings csvImportSettings = ServiceProvider.GetService<CsvImportSettings>();
            
            if (importManager != null && csvImportSettings != null)
            {
                await importManager.CleanEnvironment();
                IList<ImportResult> results = await importManager.PerformImport();

                Assert.True(File.Exists(Path.Combine(csvImportSettings.LocalImportDirectory, csvImportSettings.FacZipFilename)));
                Assert.True(File.Exists(Path.Combine(csvImportSettings.LocalImportDirectory, csvImportSettings.AgencyImportFilename)));
                Assert.True(File.Exists(Path.Combine(csvImportSettings.LocalImportDirectory, csvImportSettings.CfdaImportFilename)));
                Assert.True(File.Exists(Path.Combine(csvImportSettings.LocalImportDirectory, csvImportSettings.CpaImportFilename)));
                Assert.True(File.Exists(Path.Combine(csvImportSettings.LocalImportDirectory, csvImportSettings.DunsImportFilename)));
                Assert.True(File.Exists(Path.Combine(csvImportSettings.LocalImportDirectory, csvImportSettings.EinsImportFilename)));
                Assert.True(File.Exists(Path.Combine(csvImportSettings.LocalImportDirectory, csvImportSettings.FindingsImportFilename)));
                Assert.True(File.Exists(Path.Combine(csvImportSettings.LocalImportDirectory, csvImportSettings.GeneralImportFilename)));
                Assert.True(File.Exists(Path.Combine(csvImportSettings.LocalImportDirectory, csvImportSettings.NotesImportFilename)));
                Assert.True(File.Exists(Path.Combine(csvImportSettings.LocalImportDirectory, csvImportSettings.PassthroughImportFilename)));
                Assert.True(File.Exists(Path.Combine(csvImportSettings.LocalImportDirectory, csvImportSettings.RevisionImportFilename)));
                Assert.True(File.Exists(Path.Combine(csvImportSettings.LocalImportDirectory, csvImportSettings.CapTextImportFilename)));
                Assert.True(File.Exists(Path.Combine(csvImportSettings.LocalImportDirectory, csvImportSettings.FindingsTextImportFilename)));

                //CFDA's
                
                ImportResult cfdaResult = results.FirstOrDefault(x => x.ImportArea == ImportResultType.Cfda);
                
                Assert.IsNotNull(cfdaResult);
                Assert.True(cfdaResult.Success);
                Assert.True(cfdaResult.RecordsImported > 0);
                Assert.True(await ServiceProvider.GetService<IBulkImportRepository<Cfda>>().CurrentRecords() ==
                            cfdaResult.RecordsImported);
                
                
                //General
                ImportResult generalResult = results.FirstOrDefault(x => x.ImportArea == ImportResultType.General);
                
                Assert.IsNotNull(generalResult);
                Assert.True(generalResult.Success);
                Assert.True(generalResult.RecordsImported > 0);
                Assert.True(await ServiceProvider.GetService<IBulkImportRepository<General>>().CurrentRecords() ==
                            generalResult.RecordsImported);
                
                //Agency
                ImportResult agencyResult = 
                    results.FirstOrDefault
                        (x => x.ImportArea == ImportResultType.Agency);
                
                Assert.IsNotNull(agencyResult);
                Assert.True(agencyResult.Success);
                Assert.True(agencyResult.RecordsImported > 0);
                Assert.True(await ServiceProvider.GetService<IBulkImportRepository<Agency>>().CurrentRecords() ==
                            agencyResult.RecordsImported);


                //CapText
                ImportResult capTextResult = 
                    results.FirstOrDefault
                        (x => x.ImportArea == ImportResultType.CapText);
                
                Assert.IsNotNull(capTextResult);
                Assert.True(capTextResult.Success);
                Assert.True(capTextResult.RecordsImported > 0);
                Assert.True(await ServiceProvider.GetService<IBulkImportRepository<CapText>>().CurrentRecords() ==
                            capTextResult.RecordsImported);

                //Cpa
                ImportResult cpaResult = 
                    results.FirstOrDefault
                        (x => x.ImportArea == ImportResultType.Cpas);
                
                Assert.IsNotNull(cpaResult);
                Assert.True(cpaResult.Success);
                Assert.True(cpaResult.RecordsImported > 0);
                Assert.True(await ServiceProvider.GetService<IBulkImportRepository<Cpa>>().CurrentRecords() ==
                            cpaResult.RecordsImported);
                
                //Duns
                ImportResult dunResult = 
                    results.FirstOrDefault
                        (x => x.ImportArea == ImportResultType.Duns);
                
                Assert.IsNotNull(dunResult);
                Assert.True(dunResult.Success);
                Assert.True(dunResult.RecordsImported > 0);
                Assert.True(await ServiceProvider.GetService<IBulkImportRepository<Dun>>().CurrentRecords() ==
                            dunResult.RecordsImported);
                
                //Ein
                ImportResult einResult = 
                    results.FirstOrDefault
                        (x => x.ImportArea == ImportResultType.Eins);
                
                Assert.IsNotNull(einResult);
                Assert.True(einResult.Success);
                Assert.True(einResult.RecordsImported > 0);
                Assert.True(await ServiceProvider.GetService<IBulkImportRepository<Ein>>().CurrentRecords() ==
                            einResult.RecordsImported);
                
                //Findings
                ImportResult findingResult = 
                    results.FirstOrDefault
                        (x => x.ImportArea == ImportResultType.Findings);
                
                Assert.IsNotNull(findingResult);
                Assert.True(findingResult.Success);
                Assert.True(findingResult.RecordsImported > 0);
                Assert.True(await ServiceProvider.GetService<IBulkImportRepository<Finding>>().CurrentRecords() ==
                            findingResult.RecordsImported);
                
                //Findings Text
                ImportResult findingTextResult = 
                    results.FirstOrDefault
                        (x => x.ImportArea == ImportResultType.FindingsText);
                
                Assert.IsNotNull(findingTextResult);
                Assert.True(findingTextResult.Success);
                Assert.True(findingTextResult.RecordsImported > 0);
                Assert.True(await ServiceProvider.GetService<IBulkImportRepository<FindingText>>().CurrentRecords() ==
                            findingTextResult.RecordsImported);
                
                //Formatted Cap Text
                ImportResult formattedCapTextResult = 
                    results.FirstOrDefault
                        (x => x.ImportArea == ImportResultType.FormattedCapText);
                
                Assert.IsNotNull(formattedCapTextResult);
                Assert.True(formattedCapTextResult.Success);
                Assert.True(formattedCapTextResult.RecordsImported > 0);
                Assert.True(await ServiceProvider.GetService<IBulkImportRepository<FormattedCapText>>().CurrentRecords() ==
                            formattedCapTextResult.RecordsImported);

                //Formatted Findings Text
                ImportResult formattedFindingTextResult = 
                    results.FirstOrDefault
                        (x => x.ImportArea == ImportResultType.FormattedFindingsText);
                
                Assert.IsNotNull(formattedFindingTextResult);
                Assert.True(formattedFindingTextResult.Success);
                Assert.True(formattedFindingTextResult.RecordsImported > 0);
                Assert.True(await ServiceProvider.GetService<IBulkImportRepository<FormattedFindingsText>>().CurrentRecords() ==
                            formattedFindingTextResult.RecordsImported);
          
                //Passthough
                ImportResult passthroughResult = 
                    results.FirstOrDefault
                        (x => x.ImportArea == ImportResultType.Passthrough);
                
                Assert.IsNotNull(passthroughResult);
                Assert.True(passthroughResult.Success);
                Assert.True(passthroughResult.RecordsImported > 0);
                Assert.True(await ServiceProvider.GetService<IBulkImportRepository<Passthrough>>().CurrentRecords() ==
                            passthroughResult.RecordsImported);

                
                
            }
            else
            {
                Assert.Fail();
            }
        }
        
    }
}