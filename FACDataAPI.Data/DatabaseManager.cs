using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using FACDataAPI.Common.Configuration;
using Npgsql;
using PostgreSQLCopyHelper;

namespace FACDataAPI.Data
{

    public interface IDatabaseManager
    {
        Task<IDbConnection> OpenAsAsync();
        IDbConnection Open();
        Task TruncateTable(string table, string schema);
        Task<long> TableRowCount(string table, string schema);
        Task<ulong> DoBulkImport<T>(PostgreSQLCopyHelper<T> copyHelper, IEnumerable<T> entities) where T: class;

    }
    
    public class DatabaseManager: IDatabaseManager
    {

        public DatabaseSettings DatabaseSettings { get; set; }

        public DatabaseManager(DatabaseSettings settings)
        {
            DatabaseSettings = settings;
        }
        
        public async Task<IDbConnection> OpenAsAsync()
        {
            NpgsqlConnection cn = new NpgsqlConnection(this.DatabaseSettings.ToConnectionString());
            await cn.OpenAsync();
            return cn;
        }

        public IDbConnection Open()
        {
            NpgsqlConnection cn = new NpgsqlConnection(this.DatabaseSettings.ToConnectionString());
            cn.Open();
            return cn;
        }

        public async Task TruncateTable(string table, string schema)
        {
            using IDbConnection cn = await OpenAsAsync();
            await cn.ExecuteAsync($"TRUNCATE {schema}.{table}");
        }

        public async Task<long> TableRowCount(string table, string schema)
        {
            using IDbConnection cn = await OpenAsAsync();
            return await cn.ExecuteScalarAsync<long>($"select count (*) from {schema}.{table}");
        }

        public async Task<ulong> DoBulkImport<T>(PostgreSQLCopyHelper<T> copyHelper, IEnumerable<T> entities) where T : class
        {
           
            using IDbConnection cn = await OpenAsAsync();
            // Returns count of rows written
            return await copyHelper.SaveAllAsync((NpgsqlConnection)cn, entities, CancellationToken.None);
            
        }
    }
}