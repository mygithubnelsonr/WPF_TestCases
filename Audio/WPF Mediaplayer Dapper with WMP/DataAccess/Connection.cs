using System.Configuration;

namespace WPFMediaplayerDapperWMP.DataAccess
{
    public static class ConnectionTools
    {
        public static string GetConnectionString(string name = "MyJukebox")
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public enum DataSourceEnum
        {
            Songs,
            Playlist,
            Query
        }

        public static DataSourceEnum Datasource { get; set; }
    }
}
