namespace FACDataAPI.Common.Configuration
{
    public class DatabaseSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Database { get; set; }
        public string Username { get; set; }
        public string Passfile { get; set; }
        public string SearchPath { get; set; }

        public string ToConnectionString()
        {
            return $"Host={Host};Port={Port};Database={Database};Username={Username}; Passfile={Passfile}; Search Path={SearchPath}";
        }
    }
}