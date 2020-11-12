using System.Collections.Generic;
using System.Threading.Tasks;
using FACDataAPI.Common.Configuration;
using FACDataAPI.Common.Tests;
using FACDataAPI.Data.Import.Entities;
using FACDataAPI.Data.Import.Repositories;
using NUnit.Framework;

namespace FACDataAPI.Data.Tests.Repositories
{
    [TestFixture]
    public class CfdaRepositoryTests
    {
        [Test]
        public async Task TestDataImportWorkflow()
        {
            DatabaseSettings settings = TestConfigurationHelper.GetDatabaseSettings(TestContext.CurrentContext.TestDirectory);;
            IDatabaseManager databaseManager = new DatabaseManager(settings);
            
            IBulkImportRepository<Cfda> cfdaRepository = new CfdaRepository(databaseManager);

            await cfdaRepository.Clean();
            
            Assert.IsTrue(await cfdaRepository.CurrentRecords() == 0);
            
            IList<Cfda> records = new List<Cfda>();
            
            records.Add(new Cfda(){Audityear = "1997"});
            records.Add(new Cfda(){Audityear = "1998"});
            records.Add(new Cfda(){Audityear = "1999"});
            records.Add(new Cfda(){Audityear = "2000"});
            records.Add(new Cfda(){Audityear = "2001"});
            records.Add(new Cfda(){Audityear = "2002"});
            records.Add(new Cfda(){Audityear = "2003"});
            records.Add(new Cfda(){Audityear = "2004"});
            records.Add(new Cfda(){Audityear = "2005"});
            records.Add(new Cfda(){Audityear = "2006"});
            records.Add(new Cfda(){Audityear = "2007"});
            records.Add(new Cfda(){Audityear = "2008"});
            records.Add(new Cfda(){Audityear = "2009"});
            records.Add(new Cfda(){Audityear = "2010"});
            records.Add(new Cfda(){Audityear = "2011"});
            records.Add(new Cfda(){Audityear = "2012"});
            records.Add(new Cfda(){Audityear = "2013"});
            records.Add(new Cfda(){Audityear = "2014"});
            records.Add(new Cfda(){Audityear = "2015"});
            records.Add(new Cfda(){Audityear = "2016"});
            records.Add(new Cfda(){Audityear = "2017"});
            records.Add(new Cfda(){Audityear = "2018"});
            records.Add(new Cfda(){Audityear = "2019"});
            records.Add(new Cfda(){Audityear = "2020"});

            Assert.Greater(await cfdaRepository.BulkImport(records), 0);

            Assert.Greater(await cfdaRepository.CurrentRecords(), 0);
            
            await cfdaRepository.Clean();

            Assert.IsTrue(await cfdaRepository.CurrentRecords() == 0);
            
        }
    }
}