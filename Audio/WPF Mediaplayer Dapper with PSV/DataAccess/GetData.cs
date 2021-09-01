using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace WPFMediaplayerDapper.DataAccess
{
    public class GetData
    {
        public static List<vSong> GetTitles(int genreID, int catalogID, string album)
        {
            string connection = ConnectionTools.GetConnectionString("MyJukebox");

            using (IDbConnection conn = new SqlConnection(connection))
            {
                var p = new DynamicParameters();
                p.Add("@ID_Genre", genreID);
                p.Add("@ID_Catalog", catalogID);
                p.Add("@Album", album);

                string sql = "dbo.spMyJukebox_GetTitlesFromTsongs";
                var result = conn.Query<vSong>(sql, p, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public static List<Genre> GetGenres()
        {
            string connection = ConnectionTools.GetConnectionString("MyJukebox");
            using (var conn = new SqlConnection(connection))
            {
                string sql = "dbo.spMyJukebox_GenresGetall";
                var result = conn.Query<Genre>(sql).ToList();
                return result;
            }
        }

        public static List<Catalog> GetCatalogs(string genre)
        {
            if (String.IsNullOrEmpty(genre))
                return null;

            string connection = ConnectionTools.GetConnectionString("MyJukebox");
            using (var conn = new SqlConnection(connection))
            {
                var p = new DynamicParameters();
                p.Add("@Genre", genre);

                string sql = "dbo.spMyJukebox_CatalogsByGenre";
                var result = conn.Query<Catalog>(sql, p, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public static int GetCatalogID(string catalog)
        {
            if (String.IsNullOrEmpty(catalog))
                return -1;

            string connection = ConnectionTools.GetConnectionString("MyJukebox");
            using (var conn = new SqlConnection(connection))
            {
                var p = new DynamicParameters();
                p.Add("@Name", catalog);
                p.Add("@ID", -1, DbType.Int32, ParameterDirection.Output);

                string sql = "sbMyJukebox_GetCatalogIDByName";
                var result = conn.Query(sql, p, commandType: CommandType.StoredProcedure);

                int catalogId = p.Get<int>("@ID");
                return catalogId;
            }
        }

        public static List<Album> GetAlbums(int genreId, int catalogId)
        {
            if (genreId == -1 || catalogId == -1)
                return null;

            string connection = ConnectionTools.GetConnectionString("MyJukebox");
            using (var conn = new SqlConnection(connection))
            {
                var p = new DynamicParameters();
                p.Add("@ID_Genre", genreId);
                p.Add("@ID_Catalog", catalogId);

                string sql = "dbo.spMyJukebox_GetAlbums";
                var albums = conn.Query<Album>(sql, p, commandType: CommandType.StoredProcedure).ToList();
                return albums;
            }
        }

        public static List<Playlist> GetPlaylists()
        {
            List<Playlist> playLists = new List<Playlist>();

            string connection = ConnectionTools.GetConnectionString("MyJukebox");
            using (var conn = new SqlConnection(connection))
            {
                string sql = $"select * from vPlaylistSongs";
                playLists = conn.Query<Playlist>(sql).ToList();

                return playLists;
            }
        }

        public static string GetSongFieldValuesByID(int id)
        {
            string connection = ConnectionTools.GetConnectionString("MyJukebox");

            using (var conn = new SqlConnection(connection))
            {
                string sql = $"select * from vsongs where id = {id}";
                var songs = conn.Query(sql).ToList();
                var result = String.Join(",", songs);
                return result;
            }
        }
    }
}
