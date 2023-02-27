using Multitracks.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Xml.Linq;
using System.Configuration;

namespace Multitracks.Repository
{
    public interface ISongRepository
    {
        Task<List<Song>> GetAllSongs(int PageSize, int pageNumber);
    }
    public class SongRepository
    {
        public static List<Song> GetAllSongs()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["admin"].ConnectionString;
            List<Song> songs = new List<Song>();
            using (SqlConnection sqlConnectionm = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Song";
               
                SqlCommand cmd = new SqlCommand(sql, sqlConnectionm);

                sqlConnectionm.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                //testConnectiontext.Text = "Connection Open Successfully";
                //SqlDataAdapter da = new SqlDataAdapter(sql, sqlConnectionm);
                //DataTable dt = new DataTable();
                //da.Fill(dt);

                while (reader.Read())
                {
                    var song = new Song();
                    song.SongId = int.Parse(reader["songID"].ToString());
                    song.DateCreation = Convert.ToDateTime(reader["dateCreation"].ToString());
                    song.AlbumID = int.Parse(reader["albumID"].ToString());
                    song.ArtistId = int.Parse(reader["artistID"].ToString());
                    song.Title = reader["title"].ToString();
                    song.Bpm = Convert.ToDecimal(reader["bpm"].ToString());
                    song.TimeSignature = reader["timeSignature"].ToString();
                    song.Multitracks = Convert.ToBoolean(reader["multitracks"].ToString());
                    song.CustomMix = Convert.ToBoolean(reader["customMix"].ToString());
                    song.Chart = Convert.ToBoolean(reader["chart"].ToString());
                    song.RehearsalMix = Convert.ToBoolean(reader["rehearsalMix"].ToString());
                    song.Patches = Convert.ToBoolean(reader["patches"].ToString());
                    song.SongSpecificPatches = Convert.ToBoolean(reader["songSpecificPatches"].ToString());
                    song.ProPresenter = Convert.ToBoolean(reader["proPresenter"].ToString());

                    songs.Add(song);

                }
                reader.Close();
                sqlConnectionm.Close();

            }
            return songs;
        }
    }
}