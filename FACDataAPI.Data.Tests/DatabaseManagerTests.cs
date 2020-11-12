using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using FACDataAPI.Common.Configuration;
using Npgsql;
using NUnit.Framework;
using FACDataAPI.Common.Tests;

namespace FACDataAPI.Data.Tests
{
    public class DatabaseManagerTests
    {
        
        [Test]
        public async Task TestOpenAsAsync()
        {
            DatabaseSettings settings = TestConfigurationHelper.GetDatabaseSettings(TestContext.CurrentContext.TestDirectory);

            using IDbConnection cn = await new DatabaseManager(settings).OpenAsAsync();
            Assert.IsNotNull(cn);
            Assert.IsTrue(cn.State == ConnectionState.Open);
        }
        
        [Test]
        public void TestOpen()
        {
            DatabaseSettings settings = TestConfigurationHelper.GetDatabaseSettings(TestContext.CurrentContext.TestDirectory);;
            using IDbConnection cn = new DatabaseManager(settings).Open();
            Assert.IsNotNull(cn);
            Assert.IsTrue(cn.State == ConnectionState.Open);
        }
    }
}