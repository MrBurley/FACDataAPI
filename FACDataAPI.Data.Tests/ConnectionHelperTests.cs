using System;
using System.Data;
using System.IO;
using FACDataAPI.Common.Configuration;
using Npgsql;
using NUnit.Framework;

namespace FACDataAPI.Data.Tests
{
    public class ConnectionHelperTests
    {
        
        [Test]
        public void TestCreateConnection()
        {
            DatabaseSettings settings = new DatabaseSettings();

            settings.Database = "facdata";
            settings.Host = "localhost";
            settings.Passfile = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                ".pgpass");
            settings.Port = 5432;
            settings.Username = "facdatauser";
            settings.SearchPath = "import, general";

            using NpgsqlConnection cn = new ConnectionHelper().CreateConnection(settings);
            Assert.IsNotNull(cn);
            Assert.IsTrue(cn.State == ConnectionState.Open);
        }
    }
}