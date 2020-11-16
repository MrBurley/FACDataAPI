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
            services.AddTransient<IImporter<Cfda>, CfdaCsvImporter>();
            services.AddTransient<IImporter<General>, GeneralCsvImporter>();
            services.AddTransient<IImporter<Agency>, AgencyCsvImporter>();
            services.AddTransient<IImporter<CapText>, CapTextCsvImporter>();
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


                //Agency
                ImportResult capTextResult = 
                    results.FirstOrDefault
                        (x => x.ImportArea == ImportResultType.CapText);
                
                Assert.IsNotNull(capTextResult);
                Assert.True(capTextResult.Success);
                Assert.True(capTextResult.RecordsImported > 0);
                Assert.True(await ServiceProvider.GetService<IBulkImportRepository<CapText>>().CurrentRecords() ==
                            capTextResult.RecordsImported);

                
                await importManager.CleanEnvironment();
            }
            else
            {
                Assert.Fail();
            }
        }
        
    }
}