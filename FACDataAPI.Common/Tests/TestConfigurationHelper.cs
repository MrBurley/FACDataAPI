using System;
using System.IO;
using FACDataAPI.Common.Configuration;
using Microsoft.Extensions.Configuration;

namespace FACDataAPI.Common.Tests
{
    public class TestConfigurationHelper
    {
        public static IConfigurationRoot GetIConfigurationRoot(string outputPath)
        {            
            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }

        public static CsvImportSettings GetCsvImportSettings(string outputPath)
        {
            var settings = new CsvImportSettings();

            var iConfig = GetIConfigurationRoot(outputPath);
            
            iConfig
                .GetSection("CsvImportSettings")
                .Bind(settings);
            
            //Custom map the local directory
            settings.LocalImportDirectory = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                settings.LocalImportDirectory);

            return settings;
        }
        
        public static DatabaseSettings GetDatabaseSettings(string outputPath)
        {
            var settings = new DatabaseSettings();

            var iConfig = GetIConfigurationRoot(outputPath);
            
            iConfig
                .GetSection("DatabaseSettings")
                .Bind(settings);
            
            //Custom map the Passfile to the current users home directory
            settings.Passfile = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                ".pgpass");
            
            return settings;
        }
        
        
    }
}