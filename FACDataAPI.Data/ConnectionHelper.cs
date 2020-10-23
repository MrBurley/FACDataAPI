using FACDataAPI.Common.Configuration;
using Npgsql;
namespace FACDataAPI.Data
{
    public class ConnectionHelper
    {
        public NpgsqlConnection CreateConnection(DatabaseSettings settings)
        {
            NpgsqlConnection cn = new NpgsqlConnection(settings.ToConnectionString());
            cn.Open();
            return cn;
        }
    }
}